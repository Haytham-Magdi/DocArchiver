using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace DocArchiver
{
    class DocArchive_3
    {
        public DocArchive_3()
        {
            QueryDocs();
        }


        public void QueryDocs()
        {


            var srcFoldPaths = new List<string>();
            {
                srcFoldPaths.Add(
                    @"E:\HthmWork\FolderTry\Fld_1");

                srcFoldPaths.Add(
                    //@"E:\HthmWork\FolderTry");
                    @"E:\HthmWork\FoldTry");

                srcFoldPaths.Add(
                    @"D:\Microsoft-Stuff");
            }

            srcFoldPaths = GetUniqueRoots(srcFoldPaths);



            List<DirectoryInfo> dirInfoList = new List<DirectoryInfo>(1000);

            foreach (string sPath in srcFoldPaths)
            {
                DirectoryInfo dir1 = new DirectoryInfo(sPath);

                dirInfoList.Add(dir1);
            }

            //foreach (string sPath in srcFoldPaths)
            for(int i=0; i < dirInfoList.Count; i++)
            {
                DirectoryInfo dir1 = dirInfoList[i];

                //dirInfoList.Add(dir1);

                if (dir1.Exists)
                    dirInfoList.AddRange(dir1.GetDirectories());
                //else
                    //dir1 = dir1;
            }

            List<DbDiskFolder> foldList_New = 
                GenDbFolderList_From_DirInfoList(dirInfoList);
            

            List<DbDiskFolder> foldList_Db = GenDbFolderList_From_DB(srcFoldPaths);

            SetValid_New(foldList_New, foldList_Db);



            object obj1 = 0;



        }


        public void SetValid_New(List<DbDiskFolder> foldList_New, List<DbDiskFolder> foldList_Db)
        {
            List<string> pathList = new List<string>(500);
            foreach (DbDiskFolder f_New in foldList_New)
            {
                pathList.Add(f_New.Path);
            }

            foreach (DbDiskFolder f_DB in foldList_Db)
            {
                f_DB.IsValid_New = false;

                foreach (DbDiskFolder f_New in foldList_New)
                {
                    if (!f_New.IsValid_New)
                        continue;

                    if (f_DB.Path == f_New.Path)
                    {
                        f_DB.IsValid_New = true;
                        
                        f_New.IsValid_Org = true;

                        break;
                    }
                }
            }

        }

        public List<DbDiskFolder> GenDbFolderList_From_DB(List<string> a_rootPaths)
        {
            List<DbDiskFolder> ret0 = new List<DbDiskFolder>(1000);


            string stmt =

                //" SELECT     DiskFold_ID, Path, IsValid " +
                " SELECT     * " +
               " FROM         dbo.DiskFolders ";

            DataTable t1 = DataHelper.ExecuteSqlCmd(stmt);

            foreach (DataRow dr1 in t1.Rows)
            {
                ret0.Add(new DbDiskFolder()
                {
                    ID = (int)dr1["DiskFolder_ID"],
                    Path = (string)dr1["Path"],
                    IsValid_Org = (bool)dr1["IsValid"],
                    IsValid_New = false,
                    IsRoot_New = false
                });
            }

            List<DbDiskFolder> ret2 = new List<DbDiskFolder>(ret0.Count);

            foreach (DbDiskFolder df in ret0)
            {
                foreach (string sRP in a_rootPaths)
                {
                    if (df.Path.Length < sRP.Length)
                        continue;

                    if (df.Path.Substring(0, sRP.Length) == sRP)
                    {
                        ret2.Add(df);
                        break;
                    }
                }
            }


            return ret2;
        }




        public List<DbDiskFolder> GenDbFolderList_From_DirInfoList(
            List<DirectoryInfo> a_diList)
        {
            List<DbDiskFolder> ret = new List<DbDiskFolder>(a_diList.Count);

            foreach (DirectoryInfo di in a_diList)
            {
                ret.Add(new DbDiskFolder()
                {
                    ID = -1,
                    Path = di.FullName,
                    IsValid_Org = false,
                    IsValid_New = di.Exists,
                    IsRoot_New = false
                });
            }

            return ret;
        }

        public List<string> GetUniqueRoots(List<string> a_list)
        {
            {
                List<string> list0 = new List<string>(a_list.Count);
                list0.AddRange(a_list);
                a_list = list0;
            }

            List<string> ret = new List<string>(a_list.Count);


            while (a_list.Count > 0)
            {
                int nMLI = 0;

                for (int j = 0; j < a_list.Count; j++)
                {
                    if (a_list[j].Length < a_list[nMLI].Length)
                        nMLI = j;
                }

                string sMinLen = a_list[nMLI];
                int nMinLen = sMinLen.Length;

                ret.Add(sMinLen);

                a_list.RemoveAt(nMLI);

                for (int j = 0; j < a_list.Count; j++)
                {
                    if (sMinLen ==
                        a_list[j].Substring(0, nMinLen))
                    {
                        a_list.RemoveAt(j);
                        j--;
                    }
                }

            }// while

            a_list = ret;


            return ret;
        }
    }
}
