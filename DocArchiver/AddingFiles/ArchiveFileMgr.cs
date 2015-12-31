using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DocArchiver.Data;
//using System.Windows;

using System.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;


namespace DocArchiver.AddingFiles
{
    public class ArchiveFileMgr
    {
        public static void MoveCoreTo_BackupFolders()
        {
            //MoveAwayBadFiles();

            long nMaxSubSiz = 4500000000;
            //long nMaxSubSiz = 3000000;
            //long nMaxSubSiz = 4300000;

            string sArcPath = AppCfg.ArchivePath_Core;

            DirectoryInfo di_Cor = new DirectoryInfo(sArcPath);


            var fileColl_0 = di_Cor.GetFiles();

            if (fileColl_0.Length == 0)
                return;

            var dirColl_0 = di_Cor.GetDirectories();

            //var dirColl_1 = dirColl_0.OrderBy(d => d.Name);

            var dirColl_1 = dirColl_0.OrderBy(d => d.Name);

            DirectoryInfo di_Cur = null;
            int nCurDirNum = 0;


            long nRemDirSize = nMaxSubSiz;

            bool bCreateNewDir = false;

            if (dirColl_1.Count() > 0)
            {
                di_Cur = dirColl_1.Last();

                nCurDirNum = int.Parse(
                    di_Cur.Name.Substring(0, 10));

                long nCurDirSize = 0;

                var curDirFiles = di_Cur.GetFiles();

                foreach (FileInfo fi in curDirFiles)
                {
                    nCurDirSize += fi.Length;
                }

                nRemDirSize = nMaxSubSiz - nCurDirSize;
            }
            else
            {
                bCreateNewDir = true;
            }


            var fileColl_1 = fileColl_0.OrderBy(f => f.Name);

            FileInfo [] fi_Arr = fileColl_1.ToArray();

            int nofDoneFiles = 0;



            do
            {
                if (bCreateNewDir)
                {
                    bCreateNewDir = false;

                    nCurDirNum++;

                    string sDirName = nCurDirNum.ToString().PadLeft(10, '0');

                    //di_Cur = di_Cor.CreateSubdirectory(
                    //di_Cor.FullName + "\\" + sDirName);

                    di_Cur = di_Cor.CreateSubdirectory(sDirName);

                    nRemDirSize = nMaxSubSiz;
                }

                //nRemDirSize = nMaxSubSiz 

                long nAddedSize = 0;
                int nofAddedFiles = 0;

                int nIdx_1 = nofDoneFiles;

                string sFstFileName_NoEx =
                    fi_Arr[nIdx_1].Name.Substring(0, 10);

                nAddedSize += fi_Arr[nIdx_1].Length;
                nofAddedFiles++;

                int nIdx_2 = nofDoneFiles + 1;

                string sSndFileName_NoEx =
                    fi_Arr[nIdx_2].Name.Substring(0, 10);

                if (sSndFileName_NoEx == sFstFileName_NoEx)
                {
                    nAddedSize += fi_Arr[nIdx_2].Length;
                    nofAddedFiles++;
                }

                if (nRemDirSize - nAddedSize < 0)
                {

                    if (nRemDirSize != nMaxSubSiz)
                    {
                        bCreateNewDir = true;
                        continue;
                    }
                    else
                    {
                        di_Cur.MoveTo(di_Cur.FullName + "_Ex");
                    }
                }

                nRemDirSize -= nAddedSize;
                nofDoneFiles += nofAddedFiles;

                fi_Arr[nIdx_1].MoveTo(
                    di_Cur.FullName + "\\" + fi_Arr[nIdx_1].Name);

                if (nofAddedFiles > 1)
                {
                    fi_Arr[nIdx_2].MoveTo(
                        di_Cur.FullName + "\\" + fi_Arr[nIdx_2].Name);
                }


            }
            while (nofDoneFiles < fileColl_1.Count());





            //int a;
            //a = 0;



        }


        public static void MoveAwayBadFiles(
            //SearchOption a_so = SearchOption.TopDirectoryOnly)
            SearchOption a_so = SearchOption.AllDirectories)
        {
            string sCorePath = AppCfg.ArchivePath_Core;

            MoveAwayBadFiles_InFolder(sCorePath);

            if (a_so == SearchOption.AllDirectories)
            {
                DirectoryInfo di_Cor = new DirectoryInfo(sCorePath);

                var di_Coll_Subs = di_Cor.GetDirectories("*.*",
                    SearchOption.AllDirectories);

                foreach (DirectoryInfo di_Sub in di_Coll_Subs)
                {
                    MoveAwayBadFiles_InFolder(di_Sub.FullName);
                }
                
            }
        }


        public static void MoveAwayBadFiles_InFolder(string a_sFolserPath)
        {

            //{
            //string sArcPath = AppCfg.ArchivePath_Core;

            string sFolderPath = a_sFolserPath;



            //string sFolderPath = AppCfg.ArchivePath +
            //"\\CoreFiles-Org";

            DirectoryInfo arcDi = new DirectoryInfo(sFolderPath);



            var fi_Coll_Core_0 = arcDi.GetFiles("*.*",
                SearchOption.TopDirectoryOnly);



            if (fi_Coll_Core_0.Length == 0)
                return;


            var fi_Coll_Core =
                fi_Coll_Core_0.OrderBy(f => f.Name);


            List<FileInfo> fi_Coll_Bad =
                new List<FileInfo>(10000);

            List<FileInfo> fi_Coll_Bad_2 =
                new List<FileInfo>(10000);

            List<FileInfo> fi_Coll_Good =
                new List<FileInfo>(10000);


            FileInfo[] fi_Arr_Core = fi_Coll_Core.ToArray();

            for (int i = 0; i < fi_Arr_Core.Count(); i++)
            {
                int nIdx_1 = i;

                string sFileName_1_NoEx =
                    fi_Arr_Core[nIdx_1].Name.Substring(0, 10);

                if (sFileName_1_NoEx == "0000003567")
                    i = i;


                if (i == fi_Arr_Core.Count() - 1)
                {
                    fi_Coll_Bad.Add(fi_Arr_Core[nIdx_1]);
                    continue;
                }


                FileInfo fi_Core = null;

                //if (Util.LastSubstring(
                //fi_Arr_Core[nIdx_1].Name, 7) == ".corPdf")

                if (Util.Get_FileExtension(
                    fi_Arr_Core[nIdx_1].Name) == ".corPdf")
                {
                    fi_Core = fi_Arr_Core[nIdx_1];
                }


                int nIdx_2 = i + 1;

                string sFileName_2_NoEx =
                    fi_Arr_Core[nIdx_2].Name.Substring(0, 10);


                if (sFileName_2_NoEx != sFileName_1_NoEx)
                {
                    if (fi_Core == null)
                        fi_Coll_Bad.Add(fi_Arr_Core[nIdx_1]);

                    continue;
                }

                i++;

                if (fi_Core != null)
                {
                    //  fi_Core is fi_Arr_Core[nIdx_1];


                }
                if (Util.Get_FileExtension(
                    fi_Arr_Core[nIdx_2].Name) == ".corPdf")
                {
                    fi_Core = fi_Arr_Core[nIdx_2];
                }
                else
                {
                    throw new InvalidDataException();
                }

                if (fi_Core.Length < 120)
                //if (fi_Core.Length == 93)
                {
                    fi_Coll_Bad.Add(fi_Arr_Core[nIdx_1]);
                    fi_Coll_Bad.Add(fi_Arr_Core[nIdx_2]);
                    continue;
                }


                //if (fi_Core.Length < 120)
                ////if (fi_Core.Length == 93)
                //{
                //    if (fi_Core.Length > 93)
                //        fi_Core = fi_Core;

                //    fi_Coll_Bad_2.Add(fi_Arr_Core[nIdx_1]);
                //    fi_Coll_Bad_2.Add(fi_Arr_Core[nIdx_2]);
                //    continue;
                //}


                //fi_Coll_Good.Add(fi_Arr_Core[nIdx_1]);
                //fi_Coll_Good.Add(fi_Arr_Core[nIdx_2]);
            }

            {
                string sBadPath = AppCfg.ArchivePath_Bad;

                DirectoryInfo di_Bad = new DirectoryInfo(sBadPath);

                var fi_Coll_OldBad = di_Bad.GetFiles();

                foreach (FileInfo fi in fi_Coll_OldBad)
                {
                    fi.Delete();
                }


                int k = 0;
                foreach (FileInfo fi in fi_Coll_Bad)
                {
                    string sDest_FullName =
                        sBadPath + "\\" + fi.Name.Insert(
                        fi.Name.Length - 7, "_" + k.ToString());

                    fi.MoveTo(sDest_FullName);

                    k++;
                }
            }


            //sFolderPath = sFolderPath;




            //}






        }




        public static void AssignMissingFiles()
        {
            DataTable tbl_CoreFiles = null;

            {
                string stmt = " select * from CoreFiles ";

                tbl_CoreFiles = DataHelper.ExecuteSqlCmd(stmt);
            }

            if (tbl_CoreFiles.Rows.Count == 0)
                return;



            string sCorePath = AppCfg.ArchivePath_Core;

            //string sCorePath = AppCfg.ArchivePath +
            //"\\CoreFiles-Org";

            DirectoryInfo di_Cor = new DirectoryInfo(sCorePath);


            var fi_Coll_Core_0 = di_Cor.GetFiles("*.corPdf",
                SearchOption.AllDirectories);
            //a_so);


            if (fi_Coll_Core_0.Length == 0)
                return;


            var fi_Coll_Core =
                fi_Coll_Core_0.OrderBy(f => f.Name);



            FileInfo[] fi_Arr_Core = fi_Coll_Core.ToArray();

            int[] coreID_Disk_Arr = new int[fi_Arr_Core.Length];

            for (int i = 0; i < fi_Arr_Core.Length; i++)
            {
                coreID_Disk_Arr[i] = int.Parse(
                    fi_Arr_Core[i].Name.Substring(0, 10));
            }



            List<DataRow> rowUpdate_List = new List<DataRow>(10000);

            int nCnt_Row = 0;

            int nCnt_Disk = 0;

            while (nCnt_Row < tbl_CoreFiles.Rows.Count &&
                nCnt_Disk < fi_Arr_Core.Length)
            {
                DataRow dr = tbl_CoreFiles.Rows[nCnt_Row];

                int nID_Row = (int)dr["CoreFile_ID"];

                int nID_Disk = coreID_Disk_Arr[nCnt_Disk];

                object obj1 = dr["IsMissing"];

                bool bIsMissing_Org = (bool)dr["IsMissing"];

                bool bIsMissing_New;

                if (nID_Row == nID_Disk)
                {
                    bIsMissing_New = false;

                    nCnt_Row++;
                    nCnt_Disk++;
                }
                else if (nID_Row < nID_Disk)
                {
                    bIsMissing_New = true;

                    nCnt_Row++;
                }
                else if (nID_Row > nID_Disk)
                {
                    throw new Exception("Invalid nID_Disk");
                }
                else
                {
                    throw new InvalidOperationException();
                }


                if (bIsMissing_Org != bIsMissing_New)
                {
                    dr["IsMissing"] = bIsMissing_New;

                    rowUpdate_List.Add(dr);
                }
            }


            for (; nCnt_Row < tbl_CoreFiles.Rows.Count; nCnt_Row++)
            {
                DataRow dr = tbl_CoreFiles.Rows[nCnt_Row];

                dr["IsMissing"] = false;

                rowUpdate_List.Add(dr);
            }



            SqlBatchMgr sbm1 = new SqlBatchMgr(
                SqlBatchMgr.ExecutionType.ExecNonQuery);

            foreach (DataRow dr in rowUpdate_List)
            {
                string stmt =

                    " update CoreFiles set " +
                    " IsMissing = '%IsMissing' " +
                    " where CoreFile_ID = %CoreFile_ID ";

                stmt = stmt.Replace("%IsMissing",
                    dr["IsMissing"].ToString());

                stmt = stmt.Replace("%CoreFile_ID",
                    dr["CoreFile_ID"].ToString());

                sbm1.AddStatment(stmt);
            }

            sbm1.ExecuteNonQuery();



        }


        public static void InspectDocs(
            SearchOption a_so = SearchOption.AllDirectories)
        {

            string sCorePath = AppCfg.ArchivePath_Core;

            DirectoryInfo di_Cor = new DirectoryInfo(sCorePath);


            var fi_Coll_Core_0 = di_Cor.GetFiles("*.corPdf",
                //SearchOption.AllDirectories);
                a_so);


            if (fi_Coll_Core_0.Length == 0)
                return;


            var fi_Coll_Core =
                fi_Coll_Core_0.OrderBy(f => f.Name);


            DataTable tbl_Docs = null;
            {
                string stmt =

                    " SELECT     Document_ID, IsInspected " +
                    " FROM         dbo.Documents " +
                    " WHERE     (IsInspected = 0) " +
                    " Order by Document_ID ";

                tbl_Docs = DataHelper.ExecuteSqlCmd(stmt);
            }


            SqlBatchMgr sbm1 = new SqlBatchMgr(
                SqlBatchMgr.ExecutionType.ExecNonQuery);

            int nIdx_Row = 0;

            foreach (FileInfo fi in fi_Coll_Core)
            {
                int nDocument_ID = int.Parse(
                    fi.Name.Substring(0, 10));

                for (; nIdx_Row < tbl_Docs.Rows.Count; nIdx_Row++)
                {
                    int nDocID_Row = 
                        (int)tbl_Docs.Rows[nIdx_Row]["Document_ID"];

                    if (nDocID_Row < nDocument_ID)
                        continue;
                    else if (nDocID_Row > nDocument_ID)
                        break;


                    //if (nIdx_Row >= tbl_Docs.Rows.Count)
                        //break;



                    //  hthm tmp
                    //if (nDocument_ID < 394)
                    //continue;

                    int nofPages = -1;

                    bool bIsCorrupted = true;

                    PdfReader pdfReader = null;

                    try
                    {
                        pdfReader = new PdfReader(fi.FullName);

                        nofPages = pdfReader.NumberOfPages;

                        bIsCorrupted = false;

                        //pdfReader.Close(); 
                    }
                    catch (Exception exp)
                    {

                    }
                    finally
                    {
                        if (pdfReader != null)
                            pdfReader.Close();
                    }

                    {
                        string stmt =

                            " update Documents set " +
                            " NofPages = %NofPages, " +
                            " IsCorrupted = '%IsCorrupted', " +
                            " IsInspected = 'True' " +
                            " where Document_ID = %Document_ID ";

                        stmt = stmt.Replace("%NofPages",
                            nofPages.ToString());

                        stmt = stmt.Replace("%IsCorrupted",
                            bIsCorrupted.ToString());

                        stmt = stmt.Replace("%Document_ID",
                            nDocument_ID.ToString());

                        sbm1.AddStatment(stmt);
                    }
                }


            }

            sbm1.ExecuteNonQuery();

        }
    
    
    
    }
}
