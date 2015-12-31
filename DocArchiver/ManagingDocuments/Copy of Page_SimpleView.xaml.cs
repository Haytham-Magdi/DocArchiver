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
using Microsoft.Win32;
using System.IO;
using System.Data;
using BrendanGrant.Helpers.FileAssociation;
using DocArchiver.Data;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
//using iTextSharp.text.pdf.codec;

//using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

namespace DocArchiver.ManagingDocuments
{
    /// <summary>
    /// Interaction logic for Page_SimpleView.xaml
    /// </summary>
    public partial class Page_SimpleView : Page
    {
        public Page_SimpleView()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Page p = new Page_Main();

            this.NavigationService.Navigate(p);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData_FromDB();

            if(!(m_bFstLoad_Done))
            {
                NavigatingCancelEventHandler m_handler_NavigationService_Navigating =
                    new NavigatingCancelEventHandler(
                        this.NavigationService_Navigating);


                this.NavigationService.Navigating +=
                    m_handler_NavigationService_Navigating;

                App.Current.Exit += new ExitEventHandler(
                    this.App_Exit);



                m_bFstLoad_Done = true;
            }
        }
        bool m_bFstLoad_Done = false;


        Data.DsManagingDocuments dsViewingDocs =
            new Data.DsManagingDocuments();

        Data.DsManagingDocumentsTableAdapters.Vw_SimpleDocumentsViewTableAdapter
            m_adpt_Vw_SimpleDocumentsView =
            new Data.DsManagingDocumentsTableAdapters.Vw_SimpleDocumentsViewTableAdapter();

        Data.DsManagingDocumentsTableAdapters.ImportanceDegreesTableAdapter
            m_adpt_ImportanceDegrees =
            new Data.DsManagingDocumentsTableAdapters.ImportanceDegreesTableAdapter();

        Data.DsManagingDocumentsTableAdapters.DocumentCommentsTableAdapter
            m_adpt_DocumentComments =
            new Data.DsManagingDocumentsTableAdapters.DocumentCommentsTableAdapter();


        private void BindData_ToUI()
        {

            //dg_DocumentComments.ItemsSource =
                //dsViewingDocs.Relations["FK_Vw_SimpleDocumentsView_DocumentComments"].ChildTable.DefaultView;

            //dg_ImportanceDegrees.ItemsSource =
                //dsViewingDocs.Relations["Vw_SimpleDocumentsView_ImportanceDegrees"].ChildTable.DefaultView;

            //dg_Vw_SimpleDocumentsView.Columns["Priority"]

            //this.colPriority_1.ItemsSource = 
                //dsViewingDocs.

            colImportance.ItemsSource =
                dsViewingDocs.ImportanceDegrees;

            dg_Vw_SimpleDocumentsView.ItemsSource =
                dsViewingDocs.Vw_SimpleDocumentsView;

            //static bool bCB_Degs = true;


            //if (null == cbImportanceDegrees.ItemsSource)
            {
//                cbImportanceDegrees.ItemsSource =
                    //dsViewingDocs.ImportanceDegrees;
                    //"{Binding Path=ImpDegs}";
//                    this.ImpDegs;
            }

            //dg_Vw_SimpleDocumentsView.SetBinding(

            //cbImportanceDegrees.

            //cbImportanceDegrees.DisplayMemberPath = "ImportanceDegree_Desc";

            //cbImportanceDegrees.SelectedValuePath = "ImportanceDegree_Num";

        }


        //public CollectionView ImpDegs
        public IEnumerable<DataRow> ImpDegs
        {
            get
            {
                return dsViewingDocs.ImportanceDegrees.AsEnumerable();
            }

        }



        private void LoadData_FromDB()
        {
            Data.DsManagingDocumentsTableAdapters.QueriesTableAdapter qta1 =
                new Data.DsManagingDocumentsTableAdapters.QueriesTableAdapter();

            int ? SelID = -1;

            qta1.Sp_Prepare_Sel_Documents(
                //ref SelID, -1, 99999, "%", "%", -100, 100);
                //ref SelID, -1, 99999, "%Image%", "%", -100, 100);
                //ref SelID, -1, 99999, "%", @"%E:\HthmWork\Papers%", -100, 100);
                ref SelID, 
                
                0,
                //99999,
                150, 

                string.Format( "%{0}%",
                    txtDocFileName.Text ), 
                    
                string.Format( "%{0}%",
                    txtDocFolderPath.Text ),

                -100, 
                100);


            dsViewingDocs.DocumentComments.Clear();

            dsViewingDocs.Vw_SimpleDocumentsView.Clear();

            dsViewingDocs.ImportanceDegrees.Clear();


            m_adpt_ImportanceDegrees.Fill(
                dsViewingDocs.ImportanceDegrees);

            m_adpt_Vw_SimpleDocumentsView.Fill(
                dsViewingDocs.Vw_SimpleDocumentsView, SelID.Value);

            m_adpt_DocumentComments.Fill(
                dsViewingDocs.DocumentComments, SelID.Value);


            //dsViewingDocs.AcceptChanges();

            BindData_ToUI();
        }


        public DataTable ImportanceDegree_List
        {
            get
            {
                return dsViewingDocs.ImportanceDegrees;
            }
        }
 

        private void Expand_Loaded_DBData()
        {
            //DataTable t0 = dsViewingDocs.Vw_SimpleDocumentsView;

            //dsViewingDocs.Vw_SimpleDocumentsView.Distinct(
              //  ).CopyToDataTable();





        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            CheckDataSaved();
            LoadData_FromDB();
        }

        private void btnOpenDocument_Click(object sender, RoutedEventArgs e)
        {
            object obj1 = null;

            obj1 = ((Control)sender).Parent;

            obj1 = ((FrameworkElement)sender).DataContext;

            System.Data.DataRowView dvr1 = (System.Data.DataRowView)
                ((FrameworkElement)sender).DataContext;

            System.Data.DataRow dr1 = dvr1.Row;

            int nCoreFile_ID = (int)dr1["CoreFile_ID"];

            string sCoreFile_Name = nCoreFile_ID.ToString().PadLeft(
                10, '0') + ".corPdf";

            string sCorPath = AppCfg.ArchivePath_Core;

            DirectoryInfo di_Cor = new DirectoryInfo(sCorPath);

            FileInfo fi = di_Cor.GetFiles(
                sCoreFile_Name, SearchOption.AllDirectories)[0];

            System.Diagnostics.Process.Start(fi.FullName);


            //string sPdfText = ReadPdfFile(fi.FullName);

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            m_adpt_Vw_SimpleDocumentsView.Update(
                dsViewingDocs);

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            dsViewingDocs.RejectChanges();

            //dsViewingDocs.Reset();

            //BindData_ToUI();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigating -=
            //    new NavigatingCancelEventHandler(
            //        this.NavigationService_Navigating);
        }

        private void Grid_LostFocus(object sender, RoutedEventArgs e)
        {

        }



        NavigatingCancelEventHandler m_handler_NavigationService_Navigating;

        void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (!(this.IsLoaded))
                return;

            //  Has no effect!
            //this.NavigationService.Navigating -=
                //m_handler_NavigationService_Navigating;

            CheckDataSaved();

        }


        private void App_Exit(object sender, ExitEventArgs e)
        {
            if (!(this.IsLoaded))
                return;


            CheckDataSaved();
        }




        void CheckDataSaved()
        {
            if (dsViewingDocs.HasChanges())
            {
                MessageBoxResult mbr =
                    //MessageBox.Show("Warnning.. Changes were not saved!");
                    MessageBox.Show("Save Changes ?", 
                    this.Title,
                    MessageBoxButton.YesNo);


                if (mbr == MessageBoxResult.Yes)
                {
                    SaveData();
                }

                //e.Handled = fa
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            object obj_1 = cbImportanceDegrees.SelectedValue;

            cbImportanceDegrees.SelectedValue = 2;
        }



        






    }
}
