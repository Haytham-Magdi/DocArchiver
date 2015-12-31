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
    public class ViewingResults : Process.Step
    {        

        public ViewingResults(Process a_proc)
        {
            m_proc = a_proc;
            
        }

        public void Prepare()
        {
            if (m_proc.LastStep != m_proc.ManagingFiles)
                throw new InvalidOperationException(
                    "m_proc.LastStep != m_proc.SettingPaths");

            FileElm_List = m_proc.ManagingFiles.FileElm_List;

            Proceed();
        }

        public void Proceed()
        {
            WriteMarkFiles_And_CopyFiles();

            //WriteMarkFiles_To_OrgFolders();

            //CopyFilesTo_Archive();

            Finish_DB_Work();

            ArchiveFileMgr.MoveAwayBadFiles(
                SearchOption.TopDirectoryOnly);

            DocArchiver.AddingFiles.ArchiveFileMgr.InspectDocs(
                SearchOption.TopDirectoryOnly);

            ArchiveFileMgr.MoveCoreTo_BackupFolders();

        }



        public void WriteMarkFiles_And_CopyFiles()
        {
            int nCnt1 = -1;

            bool bShutDown = false;

            foreach (FileElm fe in FileElm_List)
            {
                nCnt1++;

                if (fe.Status == FileStatus.Failed)
                    continue;

                try
                {
                    if (fe.WriteMarkFile_To_SourceFolder)
                    {

                        FileInfo fi = fe.FileInfo;

                        string sDestFullName = fe.FolderPath +
                            "\\" + fi.Name;


                        //sDestFullName = sDestFullName.ToLower().Replace(".pdf", ".arcPdf");

                        sDestFullName = Util.Set_FileExtension(sDestFullName, 
                            ".arcPdf");
                            
                        
                        MarkFileWriter.Save(fe, sDestFullName);
                    }

                    string sCoreFileName = fe.CoreFile_ID.ToString().PadLeft(10, '0');

                    if (fe.Status == FileStatus.Ready ||
                        fe.Status == FileStatus.Repeated && fe.WasCoreMissing)
                    {
                        FileInfo fi = fe.FileInfo;

                        string sDestFullName_Cmn = AppCfg.ArchivePath_Core +
                            "\\" + sCoreFileName;

                        string sDestFullName_Cor = sDestFullName_Cmn + ".corPdf";

                        string sDestFullName_Mrk = sDestFullName_Cmn + ".arcPdf";

                        MarkFileWriter.Save(fe, sDestFullName_Mrk);

                        Util.Safe_CopyFileTo(fi, sDestFullName_Cor);

                        if (fe.DeleteSourceFile_AfterCapture)
                        {
                            //fi.MoveTo(sDestFullName_Cor);

                            fi.Delete();
                            
                            fe.MovingAction = FileMovingAction.Move;
                        }
                        else
                        {
                            //fi.CopyTo(sDestFullName_Cor, true);

                            fe.MovingAction = FileMovingAction.Copy;
                        }


                        if (fe.Status == FileStatus.Ready )
                            fe.Status = FileStatus.Complete;
                    }
                    else if (fe.Status == FileStatus.Repeated)
                    {
                        if (fe.DeleteSourceFile_AfterCapture)
                        {
                            fe.FileInfo.Delete();
                            fe.MovingAction = FileMovingAction.Move;
                        }
                        else
                        {
                            fe.MovingAction = FileMovingAction.Copy;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }


                    //  hthm tmp
                    //if (nCnt1 > 0)
                    //if (true)
                    if (false)
                    {
                        bShutDown = true;
                        goto ShutDown;
                        break;

                        //App.Current.ShutdownMode = 
                            //System.Windows.ShutdownMode.OnExplicitShutdown;



                        //App.Current.Shutdown();
                        //App.Current.MainWindow.Close();
                        
                        //return;
                    }

                }
                catch (Exception exp)
                {
                    fe.Status = FileStatus.Failed;
                    fe.StatusMsg = exp.Message;
                }



            }

            System.Threading.Thread.Sleep(2000);


ShutDown:

            if (bShutDown)
            {
                throw new Exception("ShutDown!");
            }


        }




        public void Finish_DB_Work()
        {
            //StringBuilder sb1 = new StringBuilder(
            //FileElm_List.Count * 400);

            //  hthm tmp
            //return;

            SqlBatchMgr sbm1 = new SqlBatchMgr(
                SqlBatchMgr.ExecutionType.ExecNonQuery);


            //bool bHasValue = false;

            foreach (FileElm fe in FileElm_List)
            {
                //if (fe.Status != FileStatus.Ready)
                //continue;

                string stmt =

                    " update CandidateFiles " +
                    " set FileAdding_Status_ID = %FileAdding_Status_ID, " +
                        " StatusMsg = '%StatusMsg', " +
                        " MovingAction_ID = %MovingAction_ID " +
                    //" where Session_ID = %Session_ID and ";
                    " where CandidateFile_ID = %CandidateFile_ID ";


                stmt = stmt.Replace("%FileAdding_Status_ID",
                    ((int)(fe.Status.ID)).ToString());

                stmt = stmt.Replace("%StatusMsg",
                    fe.StatusMsg.Replace("'", "''"));

                stmt = stmt.Replace("%MovingAction_ID",
                    ((int)(fe.MovingAction.ID)).ToString());

                //stmt = stmt.Replace("%Session_ID",
                    //m_proc.Session.Session_ID.ToString());

                stmt = stmt.Replace("%CandidateFile_ID",
                    fe.ID.ToString());


                sbm1.AddStatment(stmt);
            }

            {
                string sTmp = string.Format(
                    " EXEC Sp_AssignFailed_RepeatedFiles {0} ",
                    m_proc.Session.Session_ID);

                sbm1.AddStatment(sTmp);
            }

            {
                string sTmp = string.Format(
                    " EXEC Sp_Finish_FileAdding_Session {0} ",
                    m_proc.Session.Session_ID);

                sbm1.AddStatment(sTmp);
            }

            sbm1.ExecuteNonQuery();
        }




        public List<FileElm> FileElm_List
        {
            get;
            set;
        }


        private readonly Process m_proc;
    }
}
