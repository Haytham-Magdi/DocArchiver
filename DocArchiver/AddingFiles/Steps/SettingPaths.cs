using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.IO;
using DocArchiver.Data;



namespace DocArchiver.AddingFiles.Steps
{
    public class SettingPaths : Process.Step
    {
        class CoreFile
        {
            public int ID;
            public FileInfo FileInfo;
        };


        public SettingPaths(Process a_proc)
        {
            m_proc = a_proc;
            
        }

        public void Prepare()
        {
            RepairIncompleteSessions();

            ArchiveFileMgr.AssignMissingFiles();

            //m_proc.LastStep = this;

            FolderInfo_List = new List<FolderInfo>(1000);
/*
            FolderInfo_List.Add(new FolderInfo
            {
                Path =
                    @"E:\HthmWork\Papers\Papers-10Dec11",
                IncludeSubFolders = false,
                //Status = FolderStatus.Unknown
                //Status = FolderStatus.Ready
            });

            FolderInfo_List.Add(new FolderInfo
            {
                Path = @"E:\HthmWork\FolderTry"
            });
*/

/*
            FolderInfo_List.Add(new FolderInfo 
            {
                Path = @"E:\HthmWork\FolderTry\Fld_1" 
            });

            FolderInfo_List.Add(new FolderInfo 
            {
                Path = @"E:\HthmWork\FolderTry\Fld_1_1" 
            });

            FolderInfo_List.Add(new FolderInfo 
            {
                Path = @"E:\HthmWork\FolderTry\Fld_1_1\Fld_1_1_1" 
            });

            FolderInfo_List.Add(new FolderInfo 
            {
                Path = @"E:\HthmWork\FolderTry\Fld_1\Fld_1_2" 
            });
*/

/*
            FolderInfo_List.Add(new FolderInfo 
            {
                //Path = @"E:\HthmWork\Papers\Papers-10Dec11" 
                Path = @"E:\HthmWork\Papers\Papers-10Dec11\Folder_2" 
            });
                        
            FolderInfo_List.Add(new FolderInfo
            {
                //Path = @"E:\HthmWork\Papers\Papers-10Dec11" 
                Path = @"E:\HthmWork\Papers\Papers-10Dec11\Folder_3"
            });

            FolderInfo_List.Add(new FolderInfo
            {
                //Path = @"E:\HthmWork\Papers\Papers-10Dec11" 
                Path = @"E:\HthmWork\Papers\Papers-10Dec11\Folder_4"
            });
 */

            FolderInfo_List.Add(new FolderInfo
            {
                Path = @"D:\"
            });





        }


        protected void RepairIncompleteSessions()
        {
            ArchiveFileMgr.MoveAwayBadFiles();

            string sArcPath = AppCfg.ArchivePath_Core;

            DirectoryInfo arcDi = new DirectoryInfo(sArcPath);

            FileInfo[] file_Arr = arcDi.GetFiles("*.cor*", 
                SearchOption.TopDirectoryOnly).OrderBy(f => f.Name).ToArray();

            //if (file_Arr.Length > 0)
              //  throw new Exception("Error! .. Some incomplete sessions found!");

            //Array.CreateInstance(

            SqlBatchMgr sbm1 = new SqlBatchMgr(
                SqlBatchMgr.ExecutionType.ExecNonQuery);

            sbm1.AddStatment(" Delete from Incomplete_CoreFiles ");

            CoreFile [] coreFile_Arr = new CoreFile[file_Arr.Length];

            for (int i = 0; i < file_Arr.Length; i++)
            {
                string sName = file_Arr[i].Name;

                int nID = int.Parse(sName.Substring(0, 10));

                coreFile_Arr[i] = new CoreFile
                {
                    FileInfo = file_Arr[i],
                    ID = nID
                };


                string stmt =

                    " INSERT INTO Incomplete_CoreFiles " +
                        " (Incomplete_CoreFile_ID, Name) " +
                    " VALUES " +
                        " (%Incomplete_CoreFile_ID, '%Name') ";


                stmt = stmt.Replace("%Incomplete_CoreFile_ID", nID.ToString());

                stmt = stmt.Replace("%Name", sName);

                sbm1.AddStatment(stmt);
            }

            sbm1.AddStatment(" exec Sp_FixLast_FileAddingSession ");            

            sbm1.ExecuteNonQuery();


            ArchiveFileMgr.MoveCoreTo_BackupFolders();
        }


        //public readonly List<FolderInfo> FolderInfo_List =
        //    new List<FolderInfo>(1000);

        public List<FolderInfo> FolderInfo_List
        {
            get;
            set;
        }


        private readonly Process m_proc;
        
    }
}
