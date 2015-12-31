using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.IO;
using DocArchiver;



namespace DocMarkReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ProcessMarkFile();
        }

        public void ProcessMarkFile()
        {

            try
            {

                string sCurDir = Environment.CurrentDirectory;

                string[] argArr = Environment.GetCommandLineArgs();


                /*
                            string sMsg = string.Format("{0}\r\n\r\n", argArr.Length);

                            foreach (string sArg in argArr)
                            {
                                sMsg += "\r\n\r\n" + sArg;
                            }

                            MessageBox.Show(sMsg);
                */

                //if (argArr.Length < 1)
                //    throw new Exception("Error! .. No document given. ");

                //string sMarkFilePath = argArr[1];

                string sMarkFilePath =
                    @"E:\HthmWork\Papers\Papers-10Dec11\Folder_2\viewcontent.arcPdf";

                {
                    string[] cmdArg_Arr = Environment.GetCommandLineArgs();


                    string[] cmdArg_2_Arr;
                    {
                        string cmdArg_Tot = cmdArg_Arr[0];

                        for (int i = 1; i < cmdArg_Arr.Length; i++)
                        {
                            cmdArg_Tot += " " + cmdArg_Arr[i];
                        }

                        int nStart = 0;
                        int nIndex;

                        List<int> list_Indexes = new List<int>(100);

                        do
                        {
                            nIndex = cmdArg_Tot.IndexOf(@":\", nStart);
                            list_Indexes.Add(nIndex);

                            nStart = nIndex + 2;

                        } while (nIndex >= 0);

                        //MessageBox.Show(list_Indexes.Count.ToString());

                        if (list_Indexes.Count != 2 + 1)
                            throw new Exception("list_Indexes.Count != 2");

                        cmdArg_2_Arr = new string[list_Indexes.Count];

                        cmdArg_2_Arr[0] = cmdArg_Tot.Substring(
                            list_Indexes[0] - 1,
                            list_Indexes[1] - list_Indexes[0]);

                        //MessageBox.Show(cmdArg_2_Arr[0]);

                        cmdArg_2_Arr[1] = cmdArg_Tot.Substring(
                            list_Indexes[1] - 1);

                        //MessageBox.Show(cmdArg_2_Arr[1]);
                    }

                    sMarkFilePath = "";

                    //if (cmdArg_Arr.Length > 1)
                    //    sMarkFilePath = cmdArg_Arr[1];

                    sMarkFilePath = cmdArg_2_Arr[1];

                    //if (cmdArg_Arr.Length > 2)
                    if (false)
                    {
                        //for (int i = 1; i < cmdArg_Arr.Length; i++)
                        //for (int i = 2; i < cmdArg_Arr.Length; i++)
                        for (int i = 0; i < cmdArg_Arr.Length; i++)
                        {
                            sMarkFilePath += " ,, " + cmdArg_Arr[i];
                        }

                        MessageBox.Show(sMarkFilePath);
                    }

                    //return;

                }


                MarkFileMgr mfm1 = MarkFileMgr.Load(sMarkFilePath);


                string sCoreArchivePath_Core =
                    @"D:\HthmWork_D\DocArchiver_Archive\CoreFiles";

                string sCoreFileName = mfm1.CoreFile_ID.ToString().PadLeft(10, '0');

                sCoreFileName += ".corPdf";

                DirectoryInfo di = new DirectoryInfo(sCoreArchivePath_Core);

                FileInfo fi = di.GetFiles(sCoreFileName,
                    SearchOption.AllDirectories)[0];

                System.Diagnostics.Process.Start(fi.FullName);



                //int a = 0;

                //a = 1;

                App.Current.Shutdown();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        

        }
    }
}
