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


namespace DocArchiver.AddingFiles
//namespace DocArchiver
{
    //namespace AddingFiles
    //{
        /// <summary>
        /// Interaction logic for Page_ConfirmingPaths.xaml
        /// </summary>
        public partial class Page_ConfirmingPaths : Page
        {
            public Page_ConfirmingPaths(Process a_proc)
            {
                Process = a_proc;

                InitializeComponent();
            }

            private void btnNext_Click(object sender, RoutedEventArgs e)
            {
                Page_ManagingFiles p = new Page_ManagingFiles(this.Process);

                

                Cursor oldCurs = this.Cursor;

                this.Cursor = Cursors.Wait;


                p.PrepareStep();

                this.Cursor = oldCurs;



                this.NavigationService.Navigate(p);
            }

            private void btnPrevious_Click(object sender, RoutedEventArgs e)
            {
                this.NavigationService.GoBack();
            }

            private void btnCancel_Click(object sender, RoutedEventArgs e)
            {
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
                this.Process.ConfirmingPaths.Prepare();
            }

            private void Page_Loaded(object sender, RoutedEventArgs e)
            {
                this.Process.LastStep = this.Process.ConfirmingPaths;

                dgFolders.ItemsSource =
                  this.Process.ConfirmingPaths.FolderInfo_List;
            }
        }
    //}
}
