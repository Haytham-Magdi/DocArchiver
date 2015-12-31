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
        /// Interaction logic for Page_SettingPaths.xaml
        /// </summary>
        public partial class Page_SettingPaths : Page
        {
            public Page_SettingPaths(Process a_proc)
            {
                Process = a_proc;

                InitializeComponent();
            }

            private void btnNext_Click(object sender, RoutedEventArgs e)
            {
                Page_ConfirmingPaths p = new Page_ConfirmingPaths(this.Process);

                p.PrepareStep();

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
                this.Process.SettingPaths.Prepare();
            }

            private void Page_Loaded(object sender, RoutedEventArgs e)
            {
                this.Process.LastStep = this.Process.SettingPaths;

                dgFolders.ItemsSource =
                  this.Process.SettingPaths.FolderInfo_List;

                dgFolders.Items.Refresh();

                dgFolders.CanUserAddRows = true;
                dgFolders.CanUserDeleteRows = true;

                //dgFolders.UpdateLayout();
            }

        }
    //}
}
