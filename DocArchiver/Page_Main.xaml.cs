using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using Microsoft.Win32;
using System.IO;
using BrendanGrant.Helpers.FileAssociation;
using DocArchiver.Data;



namespace DocArchiver
{
    /// <summary>
    /// Interaction logic for Page_Main.xaml
    /// </summary>
    public partial class Page_Main : Page
    {
        public Page_Main()
        {
            InitializeComponent();
        }

        private void btnAddFiles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddingFiles.Page_SettingPaths p = new AddingFiles.Page_SettingPaths(
                    new AddingFiles.Process());

                p.PrepareStep();

                this.NavigationService.Navigate(p);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }



        }

        private void btnTry1_Click(object sender, RoutedEventArgs e)
        {
            {
                string sLibPath =

                    @"D:\HthmWork_D\OpenCV-2.3.1-win-superpack\opencv\build\x86\vc10\staticlib";



                DirectoryInfo di_Lib = new DirectoryInfo(sLibPath);

                var fi_Coll = di_Lib.GetFiles("*d.lib");

                string sLibLine = "";

                foreach (FileInfo fi in fi_Coll)
                {
                    sLibLine += fi.Name + ";";
                }

            }

            return;


            {
                string sFileName_1 = "abcd.pdf";
                string sFileName_2 = "abcd.PDF";
                string sFileName_3 = "abcd.Pdf";

                string sRes = Util.Get_FileExtension(
                    sFileName_1);

                sRes = Util.Set_FileExtension(
                    sFileName_1, ".arcPdf");

                sRes = Util.Set_FileExtension(
                    sFileName_2, ".arcPdf");

                sRes = Util.Set_FileExtension(
                    sFileName_3, ".arcPdf");



            }

            return;





            //{
            //    string sArcPath = AppCfg.ArchivePath_Core;

            //    DirectoryInfo arcDi = new DirectoryInfo(sArcPath);

            //    string sFileName = "396".PadLeft(10, '0') + ".corPdf";

            //    FileInfo fi_93 = arcDi.GetFiles(sFileName,
            //        SearchOption.AllDirectories)[0];



            //    MarkFileMgr mfm1 = MarkFileMgr.Load(fi_93.FullName);


            //    mfm1 = mfm1;
            //}














            //string acrobatPath = Registry.GetValue(
            //   @"HKEY_CLASSES_ROOT\Applications\AcroRD32.exe\shell\Read\command", 
            //   "", 0).ToString();


            //string sDocPath =
            //    @"D:\HthmWork_D\DocArchiver_Archive\CoreFiles\0000000001.corPdf";

            //System.Diagnostics.Process.Start(sDocPath);

            //App.Current.Shutdown();


        }

        private void btnTry2_Click(object sender, RoutedEventArgs e)
        {
            DocArchiver.AddingFiles.ArchiveFileMgr.InspectDocs();


            //DocArchiver.AddingFiles.ArchiveFileMgr.MoveAwayBadFiles(
                //SearchOption.AllDirectories);

            //DocArchiver.AddingFiles.ArchiveFileMgr.AssignMissingFiles();

            MessageBox.Show("Success!");


            return;


            //{
            //    //string sArcPath = AppCfg.ArchivePath_Core;

            //    //string sCorePath = AppCfg.ArchivePath_Core;
            //    string sCorePath = AppCfg.ArchivePath + 
            //        "\\CoreFiles-Org";

            //    DirectoryInfo arcDi = new DirectoryInfo(sCorePath);



            //    var fi_Coll_Core_0 = arcDi.GetFiles("*.*", 
            //        SearchOption.AllDirectories);

            //    if (fi_Coll_Core_0.Length == 0)
            //        return;


            //    var fi_Coll_Core = 
            //        fi_Coll_Core_0.OrderBy(f => f.Name);


            //    List<FileInfo> fi_Coll_Bad =
            //        new List<FileInfo>(10000);

            //    List<FileInfo> fi_Coll_Bad_2 =
            //        new List<FileInfo>(10000);

            //    List<FileInfo> fi_Coll_Good =
            //        new List<FileInfo>(10000);


            //    FileInfo [] fi_Arr_Core = fi_Coll_Core.ToArray();

            //    for (int i = 0; i < fi_Arr_Core.Count(); i++)
            //    {
            //        int nIdx_1 = i;

            //        string sFileName_1_NoEx =
            //            fi_Arr_Core[nIdx_1].Name.Substring(0, 10);


            //        if (i == fi_Arr_Core.Count() - 1)
            //        {
            //            fi_Coll_Bad.Add(fi_Arr_Core[nIdx_1]);
            //            continue;
            //        }

                                        
            //        int nIdx_2 = i + 1;

            //        string sFileName_2_NoEx =
            //            fi_Arr_Core[nIdx_2].Name.Substring(0, 10);


            //        if (sFileName_2_NoEx != sFileName_1_NoEx)
            //        {
            //            fi_Coll_Bad.Add(fi_Arr_Core[nIdx_1]);
            //            continue;
            //        }

            //        i++;

            //        FileInfo fi_Core = null;

            //        if (Util.Get_FileExtension(
            //            fi_Arr_Core[nIdx_1].Name) == ".corPdf")
            //        {
            //            fi_Core = fi_Arr_Core[nIdx_1];
            //        }
            //        else if (Util.Get_FileExtension(
            //            fi_Arr_Core[nIdx_2].Name) == ".corPdf")
            //        {
            //            fi_Core = fi_Arr_Core[nIdx_2];
            //        }
            //        else
            //        {
            //            i = i;
            //            throw new InvalidDataException();
            //        }

            //        //if (fi_Core.Length < 120)
            //        if (fi_Core.Length == 93)
            //        {
            //            fi_Coll_Bad.Add(fi_Arr_Core[nIdx_1]);
            //            fi_Coll_Bad.Add(fi_Arr_Core[nIdx_2]);
            //            continue;
            //        }


            //        if (fi_Core.Length < 120)
            //        //if (fi_Core.Length == 93)
            //        {
            //            if (fi_Core.Length > 93)
            //                fi_Core = fi_Core;

            //            fi_Coll_Bad_2.Add(fi_Arr_Core[nIdx_1]);
            //            fi_Coll_Bad_2.Add(fi_Arr_Core[nIdx_2]);
            //            continue;
            //        }


            //        fi_Coll_Good.Add(fi_Arr_Core[nIdx_1]);
            //        fi_Coll_Good.Add(fi_Arr_Core[nIdx_2]);                    
            //    }


            //    sCorePath = sCorePath;




            //}



            {
                DirectoryInfo di_1 = new DirectoryInfo(
                    @"D:\HthmWork_D\Fold-1");

                DirectoryInfo di_2 = new DirectoryInfo(
                    @"D:\HthmWork_D\Fold-2");


                {

                    FileInfo[] fi_Coll_2 = di_2.GetFiles("*.*");

                    foreach (FileInfo fi in fi_Coll_2)
                    {
                        fi.Delete();
                    }

                }

                FileInfo[] fi_Coll_1 = di_1.GetFiles("*.*");

                List<long> ms_List = new List<long>(10000);

                foreach (FileInfo fi in fi_Coll_1)
                {
                    string sDest_FullName = di_2.FullName + "\\" +
                        fi.Name;

                    Util.Safe_CopyFileTo(fi, sDest_FullName);

                    //fi.CopyTo(sDest_FullName);
                    ////fi.MoveTo(sDest_FullName);

                    //long nCntMs = 0;

                    //while (true)
                    //{
                    //    //FileSystemWatcher fsw1 = new FileSystemWatcher(
                        
                    //    FileInfo fi_2 = new FileInfo(sDest_FullName);

                    //    //nCntMs += 100;
                    //    nCntMs ++;

                    //    if (fi_2.Length == fi.Length)
                    //    {
                    //        using (FileStream fs1 = new FileStream(
                    //            sDest_FullName, FileMode.Open))
                    //        {

                    //            nCntMs = nCntMs;
                    //        }


                    //        break;
                    //    }

                    //    //if (nCntMs > 7000)
                    //    if (nCntMs > 70)
                    //            break;

                    //    System.Threading.Thread.Sleep(100);
                    //}

                    //ms_List.Add(nCntMs);

                    //for (int j = 0; j < 1000000; j++)
                        //j = j;
                }


                int a = 0;

                a = 1;

                //throw new Exception();
            }




            //{
            //    string sDirPath = @"E:\HthmWork\Papers\Papers-10Dec11";
            //    //string sDirPath = @"E:\HthmWork\Papers\Papers-10Dec11\Folder_3";

            //    //string sDirPath = @"G:";


            //    DirectoryInfo di = new DirectoryInfo(sDirPath);

            //    AddingFiles.FileElm_Parent fep =
            //        new AddingFiles.FileElm_Parent { DirectoryInfo = di };

            //    fep.TestWriteAccess();

            //    var var_1 = di.GetAccessControl();

            //    //var_1.
            //}
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();            
        }

        private void btnTry_AssFileType_Click(object sender, RoutedEventArgs e)
        {
            //  CodeFile1.txt

            bool bDelFai = false;

            //FileAssociationInfo fai = new FileAssociationInfo(".bob");
            FileAssociationInfo fai = new FileAssociationInfo(".TryExt_2");
            if (!(fai.Exists))
            {
                //fai.Create("MyProgramName");
                fai.Create("TryExt_2_FileManager_ProgId");


                //Specify MIME type (optional)
                //fai.ContentType = "application/myfile";
                fai.ContentType = "TryExt_2_FileManager/TryExt_2_File";




                //Programs automatically displayed in open with list
                //fai.OpenWithList = new string[] { "notepad.exe", "wordpad.exe", "someotherapp.exe" };
                fai.OpenWithList = new string[] { "TryExt_FileManager.exe" };
            }
            else
            {
                bDelFai = true;
            }


//////////////////////////////////////////////////


            ProgramAssociationInfo pai = new ProgramAssociationInfo(fai.ProgID);
            if (!(pai.Exists))
            {
                pai.Create
                (
                    //Description of program/file type
                "TryExt_FileManager's File Type",

                new ProgramVerb
                     (
                    //Verb name
                     "Open",
                    //Path and arguments to use
                     //@"C:\SomePath\MyApp.exe %1"
                     @"E:\HthmWork\Projects\VS 2010\DocArchiver\TryExt_FileManager\bin\Debug\TryExt_FileManager.exe %1"
                     )
                   );

                //optional
                //pai.DefaultIcon = new ProgramIcon(@"C:\SomePath\SomeIcon.ico");
                pai.DefaultIcon = new ProgramIcon(
                //pai.Se.setde DefaultIcon = new ProgramIcon(
                    @"E:\HthmWork\Projects\VS 2010\DocArchiver\TryExt_FileManager\Icon1.ico");


                bDelFai = false;
            }
            else
            {
                pai.Delete();
                bDelFai = true;
            }

            if (bDelFai)
            {
                fai.Delete();
            }


            MessageBox.Show("Success !");


        }

        private void btnTryBackupMgr_Click(object sender, RoutedEventArgs e)
        {
            AddingFiles.ArchiveFileMgr.MoveCoreTo_BackupFolders();
        }

        private void btnTrySqlBatchMgr_Click(object sender, RoutedEventArgs e)
        {
            SqlBatchMgr sbm1 = new SqlBatchMgr(
                SqlBatchMgr.ExecutionType.ExecQuery);

            {
                string delStmt = 

                    " delete from Table_1 ";

                sbm1.AddStatment(delStmt);

            }

            //for (int i = 0; i < 10; i++)
            //for (int i = 0; i < 70000; i++)
            for (int i = 0; i < 30000; i++)
            {
                string stmt =

                    " insert into Table_1 " +
                    "     (Tabel_1_ID) " +
                    " Values " +
                    "     (%Tabel_1_ID) ";

                stmt = stmt.Replace("%Tabel_1_ID", 
                    i.ToString());

                sbm1.AddStatment(stmt);
            }

            {
                string stmt =

                    " select * from Table_1 ";

                sbm1.AddStatment(stmt);
            }


            sbm1.Execute();
        }

        private void btnFixProblem_10Feb12_Click(object sender, RoutedEventArgs e)
        {
            string sArcPath = AppCfg.ArchivePath_Core;

            DirectoryInfo arcDi = new DirectoryInfo(sArcPath);


            var fileColl_All = arcDi.GetFiles("*.corPdf", 
                SearchOption.AllDirectories);

            if (fileColl_All.Length == 0)
                return;



            List<FileInfo> fileColl_93 = new List<FileInfo>(10000);

            SqlBatchMgr sbm1 = new SqlBatchMgr(
                SqlBatchMgr.ExecutionType.ExecNonQuery);

            sbm1.AddStatment(
                " delete from BadCoreFiles ");


            foreach (FileInfo fi in fileColl_All)
            {
                if(fi.Length != 93)
                    continue;

                fileColl_93.Add(fi);

                int nBadCoreFile_ID = 
                    int.Parse(fi.Name.Substring(0, 10));

                string stmt =

                    " insert into BadCoreFiles " +
                        " (BadCoreFile_ID, Name, ParentFullName) " +
                    " Values " +
                        " (%BadCoreFile_ID, '%Name', '%ParentFullName') ";

                stmt = stmt.Replace("%BadCoreFile_ID",
                    nBadCoreFile_ID.ToString());

                stmt = stmt.Replace("%Name",
                    fi.Name.Replace("'", "''"));

                stmt = stmt.Replace("%ParentFullName",
                    fi.DirectoryName.Replace("'", "''"));


                sbm1.AddStatment(stmt);

            }

            sbm1.ExecuteNonQuery();



            int a;
            a = 0;









        }

        private void btnRenameRestoredBads_Click(object sender, RoutedEventArgs e)
        {

            List<string> srcPath_List = new List<string>(200);


            srcPath_List.Add(
                @"C:\Recovered-Pdf-Files-D");

            srcPath_List.Add(
                @"C:\Recovered-Pdf-Files-E-2");

            srcPath_List.Add(
                @"C:\Recovered-Pdf-Files-F-2");

            srcPath_List.Add(
                @"D:\Recovered-Pdf-Files-E");

            srcPath_List.Add(
                @"D:\Recovered-Pdf-Files-F");


            foreach (string sSrcPath in srcPath_List)
            {

                //string sSrcPath = @"C:\Recovered-Pdf-Files-E-2";

                DirectoryInfo di_Src = new DirectoryInfo(sSrcPath);

                var fi_Coll_Src = di_Src.GetFiles(
                    "*.pdf", SearchOption.AllDirectories);


                foreach (FileInfo fi in fi_Coll_Src)
                {
                    if (fi.Length > 120)
                        continue;

                    string sDest_FullName =

                        sDest_FullName = Util.Set_FileExtension(fi.FullName,
                            ".badPdf");

                    fi.MoveTo(sDest_FullName);

                }
            }


            MessageBox.Show("Success!");

        }

        private void btnManageDocumens_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ManagingDocuments.Page_SimpleView p =
                    new ManagingDocuments.Page_SimpleView();

                //ManagingDocuments.Page_SimpleView_2 p =
                  //  new ManagingDocuments.Page_SimpleView_2();

                this.NavigationService.Navigate(p);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }


    }
}
