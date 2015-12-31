using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace DocArchiver
{
    class MarkFileWriter
    {
        private MarkFileWriter() { }


        public static void Save(
            AddingFiles.FileElm a_fe, string a_filePath)
        {
            {
                //string sEnd = a_filePath.Substring(
                  //  a_filePath.Length - 7, 7);

                string sEnd = Util.Get_FileExtension(a_filePath);

                if (sEnd != ".arcPdf")
                    throw new InvalidDataException();
            }

            using (FileStream fs1 = new FileStream(a_filePath, FileMode.Create))
            {
                using (BinaryWriter bw1 = new BinaryWriter(fs1))
                {
                    bw1.Write(MarkFileMgr.Rt_AppMark);

                    bw1.Write(MarkFileMgr.Rt_AppInstanceMark);

                    bw1.Write(MarkFileMgr.Rt_SessionFile_Extension);

                    bw1.Write((double)MarkFileMgr.Rt_Version); //   Ver

                    bw1.Write((Int32)a_fe.ID);

                    bw1.Write((Int32)a_fe.CoreFile_ID);

                    bw1.Write((long)a_fe.Size);

                    bw1.Write((ulong)a_fe.UniqueNum_1);

                    bw1.Write((ulong)a_fe.UniqueNum_2);

                    bw1.Write((ulong)a_fe.UniqueNum_3);

                    bw1.Write((ulong)a_fe.UniqueNum_4);
                }
            }

        }


        
    }
}
