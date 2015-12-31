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
using DocArchiver;
using DocArchiver.AddingFiles.Steps;
using System.IO;


namespace DocArchiver.AddingFiles
//namespace DocArchiver
{
    //namespace AddingFiles
    //{
        /// <summary>
        /// Interaction logic for Page_ManagingFiles.xaml
        /// </summary>
        public partial class Page_ManagingFiles : Page
        {
            public Page_ManagingFiles(Process a_proc)
            {
                Process = a_proc;

                InitializeComponent();
            }

            private void btnFinish_Click(object sender, RoutedEventArgs e)
            {
                Page_ViewingResults p = new Page_ViewingResults(this.Process);

                p.PrepareStep();

                this.NavigationService.Navigate(p);
            }

            private void btnPrevious_Click(object sender, RoutedEventArgs e)
            {
                this.NavigationService.GoBack();
            }

            private void btnCancel_Click(object sender, RoutedEventArgs e)
            {
                {
                    int nSesID = this.Process.Session.Session_ID;

                    string stmt =

                        string.Format(
                            " exec Sp_FileAdding_Cancel_Session {0} ", nSesID);

                    DataHelper.ExecuteSqlNonQuery(stmt);
                }




                Page p = new Page_Main();

                this.NavigationService.Navigate(p);
            }

            

            public Process Process
            {
                get;
                set;
            }

            public void PrepareStep()
            {
                this.Process.ManagingFiles.Prepare();
            }

            private void Page_Loaded(object sender, RoutedEventArgs e)
            {
                this.Process.LastStep = this.Process.ManagingFiles;

                dgFolders.ItemsSource =
                  this.Process.ManagingFiles.FileElm_List;
            }

            private void btnTry1_Click(object sender, RoutedEventArgs e)
            {
                FileElm fe1 = null;

                List<FileElm> fe_List = 
                    this.Process.ManagingFiles.FileElm_List;

                for (int i = 0; i < fe_List.Count; i++)
                {
                    fe1 = fe_List[i];

                    if (fe1.Status == FileStatus.Ready)
                        break;
                }

                DirectoryInfo di_1 = fe1.FileInfo.Directory;

                DirectoryInfo di_2 = new DirectoryInfo(                    
                    fe1.FileInfo.Directory.FullName);

                bool b1 = (di_1 == di_2);

            }

            private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
            {
                List<FileElm> fe_List =
                    this.Process.ManagingFiles.FileElm_List;

                foreach (FileElm fe1 in fe_List)
                {
                    if (fe1.CanWrite_To_ParentFolder)
                        fe1.DeleteSourceFile_AfterCapture = true;                        
                }

                dgFolders.ItemsSource = null;
                dgFolders.ItemsSource = fe_List;
            }

            private void btnKeepAll_Click(object sender, RoutedEventArgs e)
            {
                List<FileElm> fe_List =
                    this.Process.ManagingFiles.FileElm_List;

                foreach (FileElm fe1 in fe_List)
                {
                    //if (fe1.CanWrite_To_ParentFolder)
                        fe1.DeleteSourceFile_AfterCapture = false;
                }

                dgFolders.ItemsSource = null;
                dgFolders.ItemsSource = fe_List;
            }
        }
    //}
}
