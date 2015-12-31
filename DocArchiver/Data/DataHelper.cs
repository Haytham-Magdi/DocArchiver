using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
//using DocArchiver.Old;


namespace DocArchiver
{
    class DataHelper
    {
        public static string GetConnectionString()
        {
            string sRet = 
                //"Data Source=.;Initial Catalog=DocArchiverDB;User ID=sa;Password=123";
                //@"Data Source=.;AttachDbFilename=E:\HthmWork\Projects\VS-2010\DocArchiver-Stuff\CurrentDB\DocArchiverDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
                //@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\HthmWork\Projects\VS-2010\DocArchiver-Stuff\CurrentDB\DocArchiverDB.mdf;Integrated Security=True;Connect Timeout=30";
                //@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\HthmWork\Projects\VS-2010\DocArchiver-Stuff\CurrentDB\DocArchiverDB.mdf;Integrated Security=False;Connect Timeout=30;User Instance=False";
                
            //@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\HthmWork\Projects\VS-2010\DocArchiver-Stuff\CurrentDB\DocArchiverDB.mdf;Integrated Security=True;Connect Timeout=30";

                @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\HthmWork\Projects\VS-2010\DocArchiver-Stuff\CurrentDB\DocArchiverDB.mdf;Integrated Security=True;Connect Timeout=30";

            //"name=DocArchiver.Properties.Settings.DocArchiverDBConnectionString";
            //"name=DocArchiverDBEntities";
            //"DocArchiverDBEntities";

            //"DocArchiverDBConnectionString"


            return sRet;
        }


        public static IDataReader ExecuteSqlReader(string a_stmt)
        {
            IDataReader ret;

            SqlConnection dbCon = new SqlConnection(
                DataHelper.GetConnectionString());

            try
            {
                dbCon.Open();

                SqlCommand dbCmd1 = dbCon.CreateCommand();


                dbCmd1.CommandText = a_stmt;

                ret = dbCmd1.ExecuteReader();
            }
            finally
            {
                dbCon.Close();
            }


            return ret;
        }


        public static int ExecuteSqlNonQuery(string a_stmt)
        {
            SqlConnection dbCon = new SqlConnection(
                DataHelper.GetConnectionString());

            try
            {
                dbCon.Open();

                SqlCommand dbCmd1 = dbCon.CreateCommand();


                dbCmd1.CommandText = a_stmt;

                int nRet = dbCmd1.ExecuteNonQuery();

                return nRet;

                //nRet = nRet;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                dbCon.Close();
            }

        }

        public static DataTable ExecuteSqlCmd(string a_stmt)
        {

            //DocArchiverDBEntities aa = new DocArchiverDBEntities();
             //aa.DiskFolders.Context.Connection;

            //aa.DiskFolders.Context

            //SqlConnection dbCon = new SqlConnection("DocArchiverDBConnectionString");
            
            
            SqlDataAdapter dbAdp1 = new SqlDataAdapter(a_stmt,
                DataHelper.GetConnectionString());

            DataTable dbTbl1 = new DataTable();

            dbAdp1.Fill(dbTbl1);

            return dbTbl1;

            
            //SqlConnection dbCon = new SqlConnection("DocArchiverDBConnectionString");

            //try
            //{
            //    dbCon.Open();

            //    SqlCommand dbCmd1 = dbCon.CreateCommand();
                
                

            //    dbCmd1.CommandText = a_stmt;

            //}
            //finally
            //{
            //    dbCon.Close();
            //}

        }
    }

}
