using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DocArchiver.Data;


namespace DocArchiver.AddingFiles.Steps
{
    public class ManagingFiles : Process.Step
    {        


        public ManagingFiles(Process a_proc)
        {
            m_proc = a_proc;
            
        }

        public void Prepare()
        {
            if (m_proc.LastStep != m_proc.ConfirmingPaths)
                throw new InvalidOperationException(
                    "m_proc.LastStep != m_proc.SettingPaths");


            Proceed();
        }

        public void Proceed()
        {
            PrepareFileElms();

            AssignEarlyRepeatedFiles();

            m_proc.Session = Session.Create(
                FileElm_List.Count, FileParent_List.Count);
            
            for (int i = 0; i < FileElm_List.Count; i++)
            {
                FileElm fe = FileElm_List[i];
                fe.ID = m_proc.Session.StartFile_ID + i;                
            }

            for (int i = 0; i < FileParent_List.Count; i++)
            {
                FileElm_Parent fp = FileParent_List[i];
                fp.ID = m_proc.Session.StartFolder_ID + i;
            }


            InsertParentFolders();

            InsertCandidateFiles();

            AssignRepeatedFiles_WithDB();

            AssignCoreFile_IDs_AndUpdate_DB();
            
        }


        public void AssignCoreFile_IDs_AndUpdate_DB()
        {
            List<FileElm> fe_Update_List = 
                new List<FileElm>(this.FileElm_List.Count);
            

            foreach (FileElm fe in this.FileElm_List)
            {
                if (fe.Status == FileStatus.Failed)
                {
                    continue;
                }
                else if (fe.Status == FileStatus.Ready)
                {
                    if (fe.CoreFile_ID == -1)
                    {
                        fe.CoreFile_ID = fe.ID;
                        fe_Update_List.Add(fe);
                    }
                }
                else if (fe.Status == FileStatus.Repeated)
                {
                    if (fe.CoreFile_ID == -1)
                    {
                        fe.CoreFile_ID = fe.Repeated_FileElm.CoreFile_ID;
                        fe_Update_List.Add(fe);
                    }
                }
                else
                {
                    throw new InvalidOperationException();
                }

            }

            SqlBatchMgr sbm1 = new SqlBatchMgr(
                SqlBatchMgr.ExecutionType.ExecNonQuery);

            //StringBuilder sb1 = new StringBuilder(
                //fe_Update_List.Count * 400);

            foreach (FileElm fe in fe_Update_List)
            {
                string updateStmt =

                    " Update CandidateFiles set " +
                    " CoreFile_ID = %CoreFile_ID " +
                    " where CandidateFile_ID = %CandidateFile_ID; ";

                updateStmt = updateStmt.Replace(
                    "%CoreFile_ID", fe.CoreFile_ID.ToString());

                updateStmt = updateStmt.Replace(
                    "%CandidateFile_ID", fe.ID.ToString());


                //sb1.Append(updateStmt);
                sbm1.AddStatment(updateStmt);
            }

            sbm1.ExecuteNonQuery();

            //if( fe_Update_List.Count > 0)
                //DataHelper.ExecuteSqlNonQuery(sb1.ToString());
        }


        public DataTable Exec_Sp_AssignRepeatedFiles(int a_nSession_ID)
        {


/*
            {
                string stmt = 

                    " exec AssignRepeatedFiles %Session_ID; " +

	                " SELECT     TOP (100) PERCENT CandidateFile_ID, CoreFile_ID " +
	                " FROM         dbo.CandidateFiles " +
                    " WHERE     (Session_ID = %Session_ID) AND (CoreFile_ID IS NOT NULL) " +
	                " ORDER BY CandidateFile_ID; ";


                stmt = stmt.Replace("%Session_ID",
                    a_nSession_ID.ToString());

                //DataHelper.ExecuteSqlNonQuery(
                  //  " exec AssignRepeatedFiles 1 ");

                DataTable t1 = DataHelper.ExecuteSqlCmd(stmt);


                return t1;
            }
 */





            {

                //int? nSession_ID = a_nSession_ID;

                Data.DsAddingFilesTableAdapters.QueriesTableAdapter adpt =
                    new Data.DsAddingFilesTableAdapters.QueriesTableAdapter();


                System.Data.SqlClient.SqlCommand cmd1 =
                    adpt.GetCommand("AssignRepeatedFiles");


                cmd1.Parameters["@Session_ID"].Value = a_nSession_ID;

                {
                    string stmt =

                        " exec AssignRepeatedFiles @Session_ID; " +

                        " SELECT     TOP (100) PERCENT CandidateFile_ID, CoreFile_ID, WasCoreMissing " +
                        " FROM         dbo.CandidateFiles " +
                        " WHERE     (Session_ID = @Session_ID) AND (CoreFile_ID IS NOT NULL) " +
                        " ORDER BY CandidateFile_ID; ";

                    cmd1.CommandText = stmt;

                    cmd1.CommandType = CommandType.Text;
                }




                DataTable t1 = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd1);

                try
                {
                    cmd1.Connection.Open();
                    da.Fill(t1);
                }
                finally
                {
                    cmd1.Connection.Close();
                }

                return t1;
            }

        }



        public void AssignRepeatedFiles_WithDB()
        {
            //Data.DsAddingFilesTableAdapters.QueriesTableAdapter adpt =
            //    new Data.DsAddingFilesTableAdapters.QueriesTableAdapter();

            //int? nSession_ID = m_proc.Session.Session_ID;

            //object retObj = adpt.AssignRepeatedFiles(nSession_ID);

            DataTable t1 = Exec_Sp_AssignRepeatedFiles(
                m_proc.Session.Session_ID);

            {

                int i = 0;
                foreach (DataRow dr in t1.Rows)
                {
                    int nCandID = (int)dr["CandidateFile_ID"];

                    for (; i < FileElm_List.Count; i++)
                    {
                        if (FileElm_List[i].ID == nCandID)
                            break;
                    }

                    FileElm_List[i].Status = FileStatus.Repeated;

                    FileElm_List[i].CoreFile_ID = (int)dr["CoreFile_ID"];

                    FileElm_List[i].WasCoreMissing = (bool)dr["WasCoreMissing"];
                }

            }


        }




        public void AssignEarlyRepeatedFiles()
        {
            for (int i = 0; i < FileElm_List.Count; i++)
            {
                FileElm fe_I = FileElm_List[i];

                if (fe_I.Status != FileStatus.Ready)
                {
                    continue;
                }



                for (int j = i + 1; j < FileElm_List.Count; j++)
                {
                    FileElm fe_J = FileElm_List[j];

                    //if (fe_J.Status == FileStatus.Failed ||
                      //  fe_J.Status == FileStatus.Repeated)

                    if (fe_J.Status != FileStatus.Ready)
                    {
                        continue;
                    }

                    if (fe_J.Size == fe_I.Size &&
                         fe_J.UniqueNum_1 == fe_I.UniqueNum_1 &&
                         fe_J.UniqueNum_2 == fe_I.UniqueNum_2 &&
                         fe_J.UniqueNum_3 == fe_I.UniqueNum_3 &&
                         fe_J.UniqueNum_4 == fe_I.UniqueNum_4
                        )
                    {
                        fe_J.Status = FileStatus.Repeated;
                        fe_J.Repeated_FileElm = fe_I;
                    }

                }
            
            }


        }





        public void InsertParentFolders()
        {
            SqlBatchMgr sbm1 = new SqlBatchMgr(
                SqlBatchMgr.ExecutionType.ExecNonQuery);

            foreach (FileElm_Parent fp in FileParent_List)
            {
                string stmt = 

                    " INSERT INTO FileAdding_Folders " +
                        " (Folder_ID, Session_ID, FullName) " +
                    " VALUES " +
                        " (%Folder_ID, %Session_ID, '%FullName') ";

                stmt = stmt.Replace("%Folder_ID",
                    fp.ID.ToString());

                stmt = stmt.Replace("%Session_ID",
                    m_proc.Session.Session_ID.ToString());

                stmt = stmt.Replace("%FullName",
                    fp.DirectoryInfo.FullName.Replace("'", "''"));

                sbm1.AddStatment(stmt);
            }

            sbm1.ExecuteNonQuery();

        }



        public void InsertCandidateFiles()
        {
            SqlBatchMgr sbm1 = new SqlBatchMgr(
                SqlBatchMgr.ExecutionType.ExecNonQuery);


            foreach (FileElm fe in FileElm_List)
            {

                string stmt =

                    " INSERT INTO CandidateFiles " +
                        " (CandidateFile_ID ,Session_ID, CoreFile_ID, " +
                        " Name ,Folder_ID ,UniqueNum_1, UniqueNum_2, " +
                        " UniqueNum_3, UniqueNum_4, DateModified, " +
                        " Size, FileAdding_Status_ID, StatusMsg, " +
                        " MovingAction_ID) " +
                    " VALUES " +
                        " (%CandidateFile_ID ,%Session_ID, NULL, " +
                        " '%Name' ,%Folder_ID ,%UniqueNum_1, %UniqueNum_2, " +
                        " %UniqueNum_3, %UniqueNum_4, '%DateModified', " +
                        " %Size, %FileAdding_Status_ID, '%StatusMsg', " +
                        " %MovingAction_ID) ";


                stmt = stmt.Replace("%CandidateFile_ID", 
                    fe.ID.ToString());

                stmt = stmt.Replace("%Session_ID",
                    m_proc.Session.Session_ID.ToString());

                stmt = stmt.Replace("%Name",
                    fe.Name.Replace("'","''"));

                stmt = stmt.Replace("%Folder_ID",
                    fe.ParentFolder.ID.ToString());

                stmt = stmt.Replace("%UniqueNum_1",
                    ((long)fe.UniqueNum_1).ToString());

                stmt = stmt.Replace("%UniqueNum_2",
                    ((long)fe.UniqueNum_2).ToString());

                stmt = stmt.Replace("%UniqueNum_3",
                    ((long)fe.UniqueNum_3).ToString());

                stmt = stmt.Replace("%UniqueNum_4",
                    ((long)fe.UniqueNum_4).ToString());

                stmt = stmt.Replace("%DateModified",
                    fe.DateModified.ToString());

                stmt = stmt.Replace("%Size",
                    fe.Size.ToString());

                stmt = stmt.Replace("%FileAdding_Status_ID",
                    ((int)fe.Status.ID).ToString());

                stmt = stmt.Replace("%StatusMsg",
                    fe.StatusMsg);

                stmt = stmt.Replace("%MovingAction_ID",
                    ((int)fe.MovingAction.ID).ToString());


                sbm1.AddStatment(stmt);
            }

            sbm1.ExecuteNonQuery();
        }





        public void FillCandidateFileRow(
            AddingFiles.Data.DsAddingFiles.CandidateFilesRow dr, FileElm fe)
        {
            dr.CandidateFile_ID = fe.ID;

            dr.Session_ID = m_proc.Session.Session_ID;

            dr.Name = fe.Name;

            dr.FolderPath = fe.FolderPath;

            dr.CandidateFile_ID = fe.ID;

            dr.UniqueNum_1 = (long)fe.UniqueNum_1;

            dr.UniqueNum_2 = (long)fe.UniqueNum_2;

            dr.UniqueNum_3 = (long)fe.UniqueNum_3;

            dr.UniqueNum_4 = (long)fe.UniqueNum_4;

            dr.DateModified = fe.DateModified;

            dr.Size = fe.Size;

            dr.CandidateFile_ID = fe.ID;

            dr.FileAdding_Status_ID = (int)fe.Status.ID;

            dr.StatusMsg = fe.StatusMsg;

            dr.MovingAction_ID = (int)fe.MovingAction.ID;

        }

        public void PrepareFileElms()
        {


            List<FolderInfo> foldInf_List = new List<FolderInfo>(
                m_proc.ConfirmingPaths.FolderInfo_List);

            FileElm_List = new List<FileElm>(100000);

            FileParent_List = new List<FileElm_Parent>(100000);


            List<FileElm_Parent> fe_Parent_List = 
                new List<FileElm_Parent>(10000);


            //foreach (FolderInfo foldInf in foldInf_List)
            for(int i=0; i < foldInf_List.Count; i++)
            {
                FolderInfo foldInf = foldInf_List[i];

                if (foldInf.Status != FolderStatus.Ready)
                    continue;

                fe_Parent_List.Add(new FileElm_Parent
                {
                    DirectoryInfo = foldInf.DirectoryInfo
                });

                if (foldInf.IncludeSubFolders)
                {
                    DirectoryInfo[] di_List = null;

                    try
                    {
                        di_List = foldInf.DirectoryInfo.GetDirectories(
                            //"*.*", SearchOption.AllDirectories);
                            "*.*", SearchOption.TopDirectoryOnly);
                    }
                    catch
                    {
                        continue;
                    }

                    foreach (DirectoryInfo di in di_List)
                    {
                        //fe_Parent_List.Add(new FileElm_Parent
                        //{
                        //    DirectoryInfo = di
                        //});

                        foldInf_List.Add(new FolderInfo
                        {
                            DirectoryInfo = di,
                            Path = di.FullName, 
                            IncludeSubFolders = true,
                            Status = FolderStatus.Ready
                        });
                    }

                }

            }

            foreach (FileElm_Parent fe_Parent in fe_Parent_List)
                fe_Parent.TestWriteAccess();

            foreach (FileElm_Parent fe_Parent in fe_Parent_List)
            {
                FileInfo[] fiColl = null;

                try
                {
                    fiColl = fe_Parent.DirectoryInfo.GetFiles(
                        "*.pdf", SearchOption.TopDirectoryOnly);
                }
                catch
                {
                    continue;
                }

                foreach (FileInfo fi in fiColl)
                {
                    string sLast_4 = Util.Get_FileExtension(fi.Name);

                    if (sLast_4.ToLower() != ".pdf")
                        continue;

                    FileElm fiElm = new FileElm { 
                        FileInfo = fi, ParentFolder = fe_Parent };

                    FileElm_List.Add(fiElm);

                    fiElm.PrepareUniqueNums();
                }

                if (fiColl.Length > 0)
                    FileParent_List.Add(fe_Parent);
            }

        }



        public List<FileElm> FileElm_List
        {
            get;
            set;
        }


        public List<FileElm_Parent> FileParent_List
        {
            get;
            set;
        }


        private readonly Process m_proc;
        
    }
}
