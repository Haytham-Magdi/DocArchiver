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
using BrendanGrant.Helpers.FileAssociation;




namespace Configure
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetFileAssociations();

            App.Current.Shutdown();
        }

        private void SetFileAssociations()
        {
            //  CodeFile1.txt

            try
            {
                //throw new Exception("Try Exception.");


                string sDocArc_ProgId = "DocArchiver.DocMarkReader";

                {
                    //FileAssociationInfo fai = new FileAssociationInfo(".bob");
                    //FileAssociationInfo fai = new FileAssociationInfo(".TryExt_2");
                    FileAssociationInfo fai = new FileAssociationInfo(".arcPdf");
                    if (fai.Exists)
                        fai.Delete();

                    //if (!(fai.Exists))
                    {
                        //fai.Create("MyProgramName");
                        //fai.Create("TryExt_2_FileManager_ProgId");
                        fai.Create(sDocArc_ProgId);


                        //Specify MIME type (optional)
                        //fai.ContentType = "application/myfile";
                        fai.ContentType = "DocArchiver/arcPdf_File";




                        //Programs automatically displayed in open with list
                        //fai.OpenWithList = new string[] { "notepad.exe", "wordpad.exe", "someotherapp.exe" };
                        //fai.OpenWithList = new string[] { "TryExt_FileManager.exe" };
                        fai.OpenWithList = new string[] { "DocMarkReader.exe" };
                    }
                }



                {
                    //FileAssociationInfo fai = new FileAssociationInfo(".bob");
                    //FileAssociationInfo fai = new FileAssociationInfo(".TryExt_2");
                    FileAssociationInfo fai = new FileAssociationInfo(".corPdf");
                    if (fai.Exists)
                        fai.Delete();

                    //if (!(fai.Exists))
                    {
                        //fai.Create("MyProgramName");
                        //fai.Create("TryExt_2_FileManager_ProgId");
                        //fai.Create(sDocArc_ProgId);
                        fai.Create("AcroExch.Document");


                        //Specify MIME type (optional)
                        //fai.ContentType = "application/myfile";
                        //fai.ContentType = "DocArchiver/arcPdf_File";
                        fai.ContentType = "application/pdf";
                        


                        //Programs automatically displayed in open with list
                        //fai.OpenWithList = new string[] { "notepad.exe", "wordpad.exe", "someotherapp.exe" };
                        //fai.OpenWithList = new string[] { "TryExt_FileManager.exe" };
                        fai.OpenWithList = new string[] { "AcroRd32.exe" };
                    }
                }



                //////////////////////////////////////////////////

                {
                    //ProgramAssociationInfo pai = new ProgramAssociationInfo(fai.ProgID);
                    ProgramAssociationInfo pai = new ProgramAssociationInfo(sDocArc_ProgId);

                    if (pai.Exists)
                        pai.Delete();


                    //if (!(pai.Exists))
                    {
                        pai.Create
                        (
                            //Description of program/file type
                        "DocArchiver's File Type",

                        new ProgramVerb
                             (
                            //Verb name
                             "Open",
                            //Path and arguments to use
                            //@"C:\SomePath\MyApp.exe %1"
                             @"E:\HthmWork\Projects\VS-2010\DocArchiver\DocMarkReader\bin\Debug\DocMarkReader.exe %1"
                             )
                           );

                        //optional
                        //pai.DefaultIcon = new ProgramIcon(@"C:\SomePath\SomeIcon.ico");
                        pai.DefaultIcon = new ProgramIcon(
                            //pai.Se.setde DefaultIcon = new ProgramIcon(
                            @"E:\HthmWork\Projects\VS-2010\DocArchiver\DocMarkReader\Icon1.ico");

                    }
                }



                MessageBox.Show("Success !");
            }
            catch
            {
                MessageBox.Show("Error!.. Probabliy security problem.\r\n\r\n" +
                    "Try to right click the application, and run it as administrator");
            }


        }
    }
}
