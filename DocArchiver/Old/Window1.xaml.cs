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
using System.Windows.Shapes;
using DocArchiver.Old;


namespace DocArchiver
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private System.Data.Objects.ObjectQuery<DiskFolder> GetDiskFoldersQuery(DocArchiverDBEntities docArchiverDBEntities)
        {
            // Auto generated code

            System.Data.Objects.ObjectQuery<DocArchiver.Old.DiskFolder> diskFoldersQuery = docArchiverDBEntities.DiskFolders;
            // Returns an ObjectQuery.
            return diskFoldersQuery;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DocArchiver.Old.DocArchiverDBEntities docArchiverDBEntities = new DocArchiver.Old.DocArchiverDBEntities();
            // Load data into DiskFolders. You can modify this code as needed.
            System.Windows.Data.CollectionViewSource diskFoldersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diskFoldersViewSource")));
            System.Data.Objects.ObjectQuery<DocArchiver.Old.DiskFolder> diskFoldersQuery = this.GetDiskFoldersQuery(docArchiverDBEntities);
            diskFoldersViewSource.Source = diskFoldersQuery.Execute(System.Data.Objects.MergeOption.AppendOnly);
        }
    }
}
