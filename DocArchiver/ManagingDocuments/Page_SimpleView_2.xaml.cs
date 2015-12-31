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
using BrendanGrant.Helpers.FileAssociation;
using DocArchiver.Data;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
//using iTextSharp.text.pdf.codec;

//using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

using DocArchiver.ManagingDocuments.Data;
using System.Management;


//using System.Data;
//using System.Data.EntityClient;
//using System.Data.Objects;




namespace DocArchiver.ManagingDocuments
{
    /// <summary>
    /// Interaction logic for Page_SimpleView_2.xaml
    /// </summary>
    public partial class Page_SimpleView_2 : Page
    {
        public Page_SimpleView_2()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Page p = new Page_Main();

            this.NavigationService.Navigate(p);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData_Vw_SimpleDocumentsView();
        }





        Data.DsManagingDocuments dsViewingDocs =
            new Data.DsManagingDocuments();

        Data.DsManagingDocumentsTableAdapters.Vw_SimpleDocumentsViewTableAdapter
            m_adpt_Vw_SimpleDocumentsViewTableAdapter =
            new Data.DsManagingDocumentsTableAdapters.Vw_SimpleDocumentsViewTableAdapter();

        public class Comparer_Vw_SimpleDocumentsView : 
            IEqualityComparer<Vw_SimpleDocumentsView>
        {
            public int GetHashCode(
                Vw_SimpleDocumentsView arg1)
            {
                return arg1.GetHashCode();
            }

            public bool Equals(
                Vw_SimpleDocumentsView a_arg1, Vw_SimpleDocumentsView a_arg2)
            {
                if (a_arg1.CoreFile_ID == a_arg2.CoreFile_ID)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        Ents_ManagingDocuments m_dataEnts = null;
            

        private void LoadData_Vw_SimpleDocumentsView()
        {

            //m_adpt_Vw_SimpleDocumentsViewTableAdapter.Fill(
            //    dsViewingDocs.Vw_SimpleDocumentsView);

            //dg_Vw_SimpleDocumentsView_0.ItemsSource =
            //    dsViewingDocs.Vw_SimpleDocumentsView;

            {
                m_dataEnts = new Ents_ManagingDocuments();

                //m_dataEnts.

                //ObjectQuery<Vw_SimpleDocumentsView> viewData =
                var viewData =
                    m_dataEnts.Vw_SimpleDocumentsView;

                //var query =

                //    (from viewData1 in viewData
                //    //where viewData1.NofPages > 5
                //     select viewData1).Distinct().ToList();
                ////    select new
                ////    {
                ////        CoreFile_ID = viewData1.CoreFile_ID,
                ////        Size = viewData1.Size,
                ////        Num = 50
                ////    };

                //var query_2 =

                //    (from viewData1 in viewData
                //    orderby viewData1.CoreFile_ID
                //     //select viewData1).Distinct().ToList();
                //     select viewData1).ToList().Distinct(
                //        new Comparer_Vw_SimpleDocumentsView());
                //     //select viewData1).Distinct();

                //dg_vw_SimpleDocumentsView.ItemsSource = query;
                //dg_vw_SimpleDocumentsView.ItemsSource = query_2;

                //var query_3 =

                //    //from viewData1 in viewData.Distinct()
                //    from viewData1 in viewData
                //    select viewData;

                dg_vw_SimpleDocumentsView.ItemsSource = viewData;
                //dg_vw_SimpleDocumentsView.ItemsSource = viewData.ToList();
                //dg_vw_SimpleDocumentsView.ItemsSource = viewData.Distinct();
                //dg_vw_SimpleDocumentsView.ItemsSource = query_2;

                



            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData_Vw_SimpleDocumentsView();
        }


        private void btnOpenDocument_Click(object sender, RoutedEventArgs e)
        {
            object obj1 = null;

            obj1 = ((Control)sender).Parent;

            obj1 = ((FrameworkElement)sender).DataContext;

            Vw_SimpleDocumentsView ent1 = (Vw_SimpleDocumentsView)obj1;

            int nCoreFile_ID = ent1.CoreFile_ID;

            string sCoreFile_Name = nCoreFile_ID.ToString().PadLeft(
                10, '0') + ".corPdf";

            string sCorPath = AppCfg.ArchivePath_Core;

            DirectoryInfo di_Cor = new DirectoryInfo(sCorPath);

            FileInfo fi = di_Cor.GetFiles(
                sCoreFile_Name, SearchOption.AllDirectories)[0];

            System.Diagnostics.Process.Start(fi.FullName);


            //string sPdfText = ReadPdfFile(fi.FullName);

        }

        private void dg_vw_SimpleDocumentsView_Sorting(object sender, DataGridSortingEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //m_dataEnts.Refresh(System.Data.Objects.RefreshMode.ClientWins,

            //m_dataEnts.Vw_SimpleDocumentsView.

            m_dataEnts.SaveChanges(
                System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave |
                System.Data.Objects.SaveOptions.DetectChangesBeforeSave); 

        }




        






    }
}
