using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DocArchiver.Data
{
    public class SqlBatchMgr
    {
        public SqlBatchMgr(ExecutionType a_execType)
        {
            m_execType = a_execType;
        }

        public enum ExecutionType
        {
            ExecQuery,
            ExecNonQuery
        }

        public void AddStatment(string a_addedStmt)
        {
            int nNewSize = m_stmtBuilder.Length + a_addedStmt.Length;

            if (nNewSize > m_stmtBuilder.Capacity)
            {
                if (m_execType == ExecutionType.ExecQuery)
                {
                    Execute();
                }
                else if (m_execType == ExecutionType.ExecNonQuery)
                {
                    ExecuteNonQuery();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            m_stmtBuilder.Append(";");

            m_stmtBuilder.AppendLine(a_addedStmt);
        }

        public int ExecuteNonQuery()
        {
            if (m_execType != ExecutionType.ExecNonQuery)
                throw new InvalidOperationException();

            if (m_stmtBuilder.Length > 0)
            {
                m_nRetVal = DataHelper.ExecuteSqlNonQuery(
                    m_stmtBuilder.ToString());

                m_stmtBuilder.Clear();
            }


            return m_nRetVal;
        }

        public DataTable Execute()
        {
            if (m_execType != ExecutionType.ExecQuery)
                throw new InvalidOperationException();

            if (m_stmtBuilder.Length > 0)
            {
                m_resTable = DataHelper.ExecuteSqlCmd(
                    m_stmtBuilder.ToString());

                m_stmtBuilder.Clear();
            }


            return m_resTable;
        }


        public int LastRetVal
        {
            get { return m_nRetVal; }
        }
        int m_nRetVal = -1;


        public DataTable LastQueryTable
        {
            get { return m_resTable; }
        }
        DataTable m_resTable = null;


        StringBuilder m_stmtBuilder = new StringBuilder(30000);
        readonly ExecutionType m_execType;
    }
}
