using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocArchiver.AddingFiles.Data;
using DocArchiver.AddingFiles.Data.DsAddingFilesTableAdapters;


namespace DocArchiver.AddingFiles
{
    public class Session
    {
        private Session()
        {
        }

        public static Session Create(int a_nofFiles, int a_nofFolders)
        {
            Session newSes = new Session { 
                _NofFiles = a_nofFiles, _NofFolders = a_nofFolders };
            

            QueriesTableAdapter adpt = new QueriesTableAdapter();

            int? nSession_ID = null;

            int? nStartFile_ID = null;
            int? nStartFolder_ID = null;

            adpt.CreateFileAddingSession(ref nSession_ID,
                ref nStartFile_ID, a_nofFiles,
                ref nStartFolder_ID, a_nofFolders);

            newSes._Session_ID = (int)nSession_ID;

            newSes._StartFile_ID = (int)nStartFile_ID;
            newSes._StartFolder_ID = (int)nStartFolder_ID;
            

            return newSes;
        }

        public int Session_ID
        {
            get { return _Session_ID; }
        }
        protected int _Session_ID;


        public int StartFile_ID
        {
            get { return _StartFile_ID; }
        }
        protected int _StartFile_ID;


        public int NofFiles
        {
            get { return _NofFiles; }
        }
        protected int _NofFiles;


        public int StartFolder_ID
        {
            get { return _StartFolder_ID; }
        }
        protected int _StartFolder_ID;


        public int NofFolders
        {
            get { return _NofFolders; }
        }
        protected int _NofFolders;

    }
}
