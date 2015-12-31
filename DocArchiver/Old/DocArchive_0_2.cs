using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace DocArchiver
{
    class DocArchive_0_2
    {
        public DocArchive_0_2(string a_arcFileName)
        {
            this.ArcFileName = a_arcFileName;

            QueryDocs();
        }

        public XmlDocument XmlDoc
        {
            get;
            set;
        }

        public void QueryDocs()
        {





            //XDocument xdoc = XDocument.Load(this.ArcFileName);

            XmlDocument xdoc_Org = new XmlDocument();
            xdoc_Org.Load(this.ArcFileName);

            XmlDocument xdoc = (XmlDocument)xdoc_Org.Clone();

            this.XmlDoc = xdoc;

            {
                {
                    XmlDocument xdoc_5 = new XmlDocument();

                    xdoc_5.Load(
                        @"E:\HthmWork\Projects\VS 2010\DocArchiver\DocArchiver\Data\xdoc.xml");

                    //var all_Files = xdoc_5.SelectNodes(".//*/Inner_Files/File");
                    var all_Files = xdoc_5.SelectNodes(".//Inner_Files/File");
                    //var all_Files = xdoc_5.SelectNodes(".//*[name()='Inner_Files']");
                    //var all_Files = xdoc_5.SelectNodes(".//*[name()='Inner_Files']/*");
                    //var all_Files = xdoc_5.SelectNodes(".//*[name()='Inner_Files']/File");
                }


                var ndFolder_Proto = xdoc.SelectSingleNode(".//Prototypes/Folder");

                var ndFile_Proto = xdoc.SelectSingleNode(".//Prototypes/File");

                //ndFile_Proto.s


                var Fst_Folders_ = xdoc.SelectNodes(".//FolderColl/Folder");

                Queue<XmlNode> folderQue = new Queue<XmlNode>(1000);

                foreach (XmlNode ndFstFolder in Fst_Folders_)
                    folderQue.Enqueue(ndFstFolder);

                while (folderQue.Count > 0)
                {
                    XmlNode ndFolder = folderQue.Dequeue();

                    DirectoryInfo dir = new DirectoryInfo(
                        ndFolder.SelectSingleNode("Path").InnerText);

                    {
                        var ndInr_Folders = ndFolder.SelectSingleNode("Inner_Folders");

                        var dirInfo_Coll = dir.GetDirectories();

                        foreach (DirectoryInfo di in dirInfo_Coll)
                        {
                            var ndFolder_New = ndFolder_Proto.Clone();

                            //ndFolder_New.SelectSingleNode("Path").InnerText = @"C:\";

                            ndFolder_New.SelectSingleNode("Name"
                                ).InnerText = di.Name;

                            ndFolder_New.SelectSingleNode("Path"
                                ).InnerText = di.FullName;

                            ndInr_Folders.AppendChild(ndFolder_New);

                            folderQue.Enqueue(ndFolder_New);
                        }
                    }

                    {
                        var ndInr_Files = ndFolder.SelectSingleNode("Inner_Files");

                        var fileInfo_Coll = dir.GetFiles("*.pdf");

                        foreach (FileInfo fi in fileInfo_Coll)
                        {
                            var ndFile_New = ndFile_Proto.Clone();

                            ndFile_New.SelectSingleNode("Name"
                                ).InnerText = fi.Name;

                            ndFile_New.SelectSingleNode("Size"
                                ).InnerText = fi.Length.ToString();

                            ndInr_Files.AppendChild(ndFile_New);
                        }
                    }


                }

                xdoc.Save("xdoc.xml");
            }  
        }


        public List<FileInfoEx> DocList
        {
            get
            {
                return m_docList;
            }
            set
            {
                m_docList = value;
            }


            //private set;
            //get;
        }
        List<FileInfoEx> m_docList;

        public readonly string ArcFileName;

        //public string ArcFileName_0
        //{
        //    public get;
        //}


        //private IEnumerable<System.IO.FileInfo> QueryFolder(string sFolder)
        //private var QueryFolder(string sFolder)
        private List<FileInfoEx> QueryFolder(string sFolder)
        {



            //string startFolder = @"c:\program files\Microsoft Visual Studio 9.0\";

            //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(sFolder);

            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles(
                //"*.*", System.IO.SearchOption.AllDirectories);
                "*.pdf", System.IO.SearchOption.AllDirectories);

            System.IO.FileInfo fi_1 = fileList.First();


            //List<FileInfoEx> retList = new List<FileInfoEx>( fileList.co
            List<FileInfoEx> retList = new List<FileInfoEx>();

            foreach (FileInfo fi in fileList)
            {
                FileInfoEx fi_Ex = new FileInfoEx();
                fi_Ex.FileInfo = fi;

                retList.Add(fi_Ex);
            }

            return retList;

            /*
                        IEnumerable<System.IO.FileInfo> fileQuery =
                            from file in fileList
                            where file.Extension == ".pdf"
                            orderby file.Name
                            select file;

                        List<System.IO.FileInfo> fileList_2 =
                            new List<System.IO.FileInfo>();

                        foreach (System.IO.FileInfo fi in fileQuery)
                        {
                            //Console.WriteLine(fi.FullName);
                            fileList_2.Add(fi);
                        }



                        var newestFile =
                            (from file in fileQuery
                             orderby file.CreationTime
                             select new { file.FullName, file.CreationTime })
                            .Last();

                        //Console.WriteLine("\r\nThe newest .txt file is {0}. Creation time: {1}",
                        //newestFile.FullName, newestFile.CreationTime);


                        return fileList_2; * 
             */



        }



    }
}
