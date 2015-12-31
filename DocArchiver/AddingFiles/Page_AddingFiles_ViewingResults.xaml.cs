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
        /// Interaction logic for Page_ViewingResults.xaml
        /// </summary>
        public partial class Page_ViewingResults : Page
        {
            public Page_ViewingResults(Process a_proc)
            {
                Process = a_proc;

                InitializeComponent();
            }

            private void btnOK_Click(object sender, RoutedEventArgs e)
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
                this.Process.ViewingResults.Prepare();
            }

            private void Page_Loaded(object sender, RoutedEventArgs e)
            {
                this.Process.LastStep = this.Process.ViewingResults;

                dgFolders.ItemsSource =
                  this.Process.ViewingResults.FileElm_List;
            }

        }
    //}
}
