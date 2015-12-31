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
using System.IO;

namespace DocArchiver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnQueryFolder_Click(object sender, RoutedEventArgs e)
        {
            string sArcPath =

                //@"E:\HthmWork\Projects\VS 2010\DocArchiver\DocArchiver\DocArchiver_File.xml";
                //@"E:\HthmWork\Projects\VS 2010\DocArchiver\DocArchiver\DocArchiver_File_2.xml";
            @"E:\HthmWork\Projects\VS 2010\DocArchiver\DocArchiver\DocArchiver_File_3.xml";


            //DocArchive da = new DocArchive(sArcPath);
            DocArchive_0_2 da = new DocArchive_0_2(sArcPath);

            this.DocArchive = da;

            MessageBox.Show("Success!");

            //this.dgFiles.DataContext = this.DocArchive.XmlDoc;
            //this.dgFiles.ItemsSource = "{Binding XPath=.//Inner_Files/File}";
        }

        //public DocArchive_0_2 DocArchive
        DocArchive_0_2 DocArchive
        {
            get;
            set;
        }



    }
}
