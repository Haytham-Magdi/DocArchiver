using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
//using System.Data;
//using System.Data.Sql;
//using System.Data.SqlClient;


namespace DocArchiver
{
    public class MarkFileMgr
    {
        private MarkFileMgr()
        {

            //  DocArchiver Instance ID
            {
                for (int k = 0; k < _Rt_AppInstanceMark.Length; k++)
                    _Rt_AppInstanceMark[k] = 0;
            }

        }


        public static string Rt_AppMark
        {
            get{ return "DocArchiver Mark"; }
        }

        public string AppMark
        {
            get { return _AppMark; }
        }
        string _AppMark;


        public static byte[] Rt_AppInstanceMark
        {
            get { return _Rt_AppInstanceMark; }
        }
        static byte[] _Rt_AppInstanceMark = new byte[16];


        public byte[] AppInstanceMark
        {
            get { return _AppInstanceMark; }
        }
        byte[] _AppInstanceMark = new byte[16];


        public static string Rt_SessionFile_Extension
        {
            get { return "pdf"; }
        }


        public string SessionFile_Extension
        {
            get { return _SessionFile_Extension; }
        }
        string _SessionFile_Extension;


        public static double Rt_Version
        {
            get{ return 1.1; }
        }


        public double Version
        {
            get { return _Version; }
        }
        double _Version;


        public int SessionFile_ID
        {
            get { return _SessionFile_ID; }
        }
        int _SessionFile_ID;


        public int CoreFile_ID
        {
            get { return _CoreFile_ID; }
        }
        int _CoreFile_ID;


        public long Size
        {
            get { return _Size; }
        }
        long _Size;


        public ulong UniqueNum_1
        {
            get { return _UniqueNum_1; }
        }
        ulong _UniqueNum_1;


        public ulong UniqueNum_2
        {
            get { return _UniqueNum_2; }
        }
        ulong _UniqueNum_2;


        public ulong UniqueNum_3
        {
            get { return _UniqueNum_3; }
        }
        ulong _UniqueNum_3;


        public ulong UniqueNum_4
        {
            get { return _UniqueNum_4; }
        }
        ulong _UniqueNum_4;


/////////////////////



        public static MarkFileMgr Load(string a_filePath)
        {
            using (FileStream fs1 = new FileStream(a_filePath, FileMode.Open))
            {
                MarkFileMgr mfm1 = new MarkFileMgr();

                using (BinaryReader br1 = new BinaryReader(fs1))
                {
                    mfm1._AppMark = br1.ReadString();

                    if (mfm1.AppMark != MarkFileMgr.Rt_AppMark)
                        throw new InvalidDataException();
                                        

                    mfm1._AppInstanceMark = br1.ReadBytes(16);

                    mfm1._SessionFile_Extension = br1.ReadString();

                    if (mfm1.SessionFile_Extension != MarkFileMgr.Rt_SessionFile_Extension)
                        throw new InvalidDataException();
                                        

                    mfm1._Version = br1.ReadDouble(); //   Ver

                    if (mfm1.Version != MarkFileMgr.Rt_Version)
                        throw new InvalidDataException();
                                        

                    mfm1._SessionFile_ID = br1.ReadInt32();

                    mfm1._CoreFile_ID = br1.ReadInt32();

                    mfm1._Size = br1.ReadInt64();

                    mfm1._UniqueNum_1 = br1.ReadUInt64();

                    mfm1._UniqueNum_2 = br1.ReadUInt64();

                    mfm1._UniqueNum_3 = br1.ReadUInt64();

                    mfm1._UniqueNum_4 = br1.ReadUInt64();

                }

                return mfm1;

            }

        }







    }
}
