using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocArchiver.Data;


namespace DocArchiver.ManagingDocuments
{
    class Document_DB_Selector
    {
        public string CoreSelStmt
        {
            get
            {
                string stmt =

" select distinct CoreFile_ID, @Sel_ID " +
" from " +
" ( " +

" SELECT     TOP (100) PERCENT dbo.CoreFiles.CoreFile_ID, dbo.CoreFiles.Size, dbo.Documents.NofPages, dbo.Documents.ImportanceDegree_Num, dbo.CoreFiles.IsMissing, " +
"                       dbo.Documents.IsCorrupted, dbo.Documents.IsInspected, dbo.Documents.DocumentTopic_ID, dbo.FileAdding_CompleteFiles.Name AS OrgFileName,  " +
"                       dbo.FileAdding_Sessions.SessionDate AS AddingDate, dbo.FileAdding_CompleteFiles.DateModified AS OrgFile_DateModified,  " +
"                       dbo.FileAdding_Folders.FullName AS OrgFolderName " +
" FROM         dbo.CoreFiles INNER JOIN " +
"                       dbo.FileAdding_CompleteFiles ON dbo.CoreFiles.CoreFile_ID = dbo.FileAdding_CompleteFiles.CoreFile_ID INNER JOIN " +
"                       dbo.FileAdding_Folders ON dbo.FileAdding_CompleteFiles.Folder_ID = dbo.FileAdding_Folders.Folder_ID INNER JOIN " +
"                       dbo.Documents ON dbo.CoreFiles.CoreFile_ID = dbo.Documents.Document_ID INNER JOIN " +
"                       dbo.FileAdding_Sessions ON dbo.FileAdding_CompleteFiles.Session_ID = dbo.FileAdding_Sessions.Session_ID " +

" ^WHERE " +

" ) as t1 ";

                return stmt;
            }

            set { }
        }


        public void Proceed()
        {
            SqlBatchMgr sbm1 = new SqlBatchMgr(
                SqlBatchMgr.ExecutionType.ExecNonQuery);

            string stmt =

    " declare @Sel_ID int " +
    " Set @Sel_ID = 1 " +

    " delete from Documents_Sel " +
    " where Sel_ID = @Sel_ID " +

    " insert into Documents_Sel " +
    " (Document_ID, Sel_ID) ";

            stmt += this.CoreSelStmt;

            string sWhere = PrepareWhereStuff();

            stmt = stmt.Replace(
                //"^WHERE", " ");
                //"^WHERE", " WHERE CoreFiles.CoreFile_ID = 95 ");
                "^WHERE", sWhere);            
            
            sbm1.AddStatment(stmt);

            sbm1.ExecuteNonQuery();
        }

        public void AddCondition(string a_sCond)
        {
            m_list_Conditions.Add(a_sCond);
        }

        protected string PrepareWhereStuff()
        {
            StringBuilder sb1 = new StringBuilder(3000);

            sb1.Append(" ");

            if (m_list_Conditions.Count > 0)
            {
                sb1.Append(" WHERE " + 
                    m_list_Conditions[0] + " ");
            }

            for (int i = 1; i < m_list_Conditions.Count; i++)
            {
                sb1.Append(" AND " +
                    m_list_Conditions[i] + " ");
            }

            string sRet = sb1.ToString();
            return sRet;
        }

        protected List<string> m_list_Conditions = new List<string>(70);



    }
}
