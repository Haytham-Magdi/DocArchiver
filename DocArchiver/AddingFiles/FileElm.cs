﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.IO;


namespace DocArchiver.AddingFiles
{
    public class FileElm
    {
        public FileElm()
        {
            Should_RemOrg = true;

            //Status = FileStatus.Unknown;
            Status = FileStatus.Ready;

            MovingAction = FileMovingAction.Unknown;

            CoreFile_ID = -1;

            StatusMsg = "";
        }


        public FileElm Repeated_FileElm
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public int CoreFile_ID
        {
            get;
            set;
        }

        public string Name
        {
            get { return this.FileInfo.Name; }
        }

        public string FolderPath
        {
            get { return this.FileInfo.DirectoryName; }
        }

        public long Size
        {
            get { return this.FileInfo.Length; }
        }

        public DateTime DateModified
        {
            get { return this.FileInfo.LastWriteTime; }
        }

        //public bool Should_RemOrg_____3
        //{
        //    get { return this.FileInfo.Directory.GetAccessControl(); }
        //}

        public FileInfo FileInfo
        {
            get;
            set;
        }

        public FileStatus Status
        {
            get;
            set;
        }

        public FileMovingAction MovingAction
        {
            get;
            set;
        }


        //public bool IsFailed
        //{
        //    get;
        //    set;
        //}

        public string StatusMsg
        {
            get;
            set;
        }

        public bool Should_RemOrg
        {
            get;
            set;
        }

        public ulong UniqueNum_1
        {
            get;
            set;
        }
                
        public ulong UniqueNum_2
        {
            get;
            set;
        }

        public ulong UniqueNum_3
        {
            get;
            set;
        }

        public ulong UniqueNum_4
        {
            get;
            set;
        }

        public FileElm_Parent ParentFolder
        {
            get;
            set;
        }

        public bool CanWrite_To_ParentFolder
        {
            get
            {
                return this.ParentFolder.IsWriteAccessible;
            }
        }

        public bool Cannot_Write_To_ParentFolder
        {
            get
            {
                return !(this.ParentFolder.IsWriteAccessible);
            }
        }


        public bool DeleteSourceFile_AfterCapture
        {
            get
            {
                if (this.CanWrite_To_ParentFolder == false)
                    return false;
                else
                    return _DeleteSourceFile_AfterCapture;
            }
            set
            {
                if (this.CanWrite_To_ParentFolder == false)
                    _DeleteSourceFile_AfterCapture = false;
                else
                    _DeleteSourceFile_AfterCapture = value;
            }
        }
        bool _DeleteSourceFile_AfterCapture = false;
        //bool _DeleteSourceFile_AfterCapture = true;


        public bool WasCoreMissing
        {
            get;
            set;
        }


        public bool WriteMarkFile_To_SourceFolder
        {
            get
            {
                if (this.CanWrite_To_ParentFolder == false)
                    return false;
                else
                    return _WriteMarkFile_To_SourceFolder;
            }
            set
            {
                if (this.CanWrite_To_ParentFolder == false)
                    _WriteMarkFile_To_SourceFolder = false;
                else
                    _WriteMarkFile_To_SourceFolder = value;
            }
        }
        bool _WriteMarkFile_To_SourceFolder = true;


        public void PrepareUniqueNums()
        {
            try
            {
                const int nBufSiz_0 = 1000000;

                const int nBufSiz = nBufSiz_0 - (nBufSiz_0 % 32);

                byte[] uniqueArr = new byte[32];

                for (int i = 0; i < uniqueArr.Length; i++)
                    uniqueArr[i] = 0;

                FileStream fs = this.FileInfo.OpenRead();

                byte[] readBuf = new byte[nBufSiz];

                int nReadCnt = fs.Read(readBuf, 0, readBuf.Length);

                while (nReadCnt > 0)
                {
                    int nRemCnt = (32 - nReadCnt % 32) % 32;

                    for (int i = 0; i < nRemCnt; i++)
                        readBuf[nReadCnt + i] = 0;

                    int nofCycles = nReadCnt / 32;
                    if (nReadCnt % 32 > 0)
                        nofCycles++;

                    for (int i = 0; i < nofCycles; i++)
                    {
                        int nBgn = i * 32;

                        for (int j = 0; j < 32; j++)
                        {
                            uniqueArr[j] ^= readBuf[nBgn + j];
                        }
                    }

                    nReadCnt = fs.Read(readBuf, 0, readBuf.Length);
                }   //  while

                {
                    ulong nUnq_1 = 0;

                    for (int i = 0; i < 8; i++)
                    {
                        nUnq_1 = nUnq_1 | ((ulong)(uniqueArr[i]) << (i * 8));
                    }

                    this.UniqueNum_1 = nUnq_1;
                }

                {
                    ulong nUnq_2 = 0;

                    for (int i = 0; i < 8; i++)
                    {
                        nUnq_2 = nUnq_2 | ((ulong)(uniqueArr[i + 8]) << (i * 8));
                    }

                    this.UniqueNum_2 = nUnq_2;
                }

                {
                    ulong nUnq_3 = 0;

                    for (int i = 0; i < 8; i++)
                    {
                        nUnq_3 = nUnq_3 | ((ulong)(uniqueArr[i + 16]) << (i * 8));
                    }

                    this.UniqueNum_3 = nUnq_3;
                }

                {
                    ulong nUnq_4 = 0;

                    for (int i = 0; i < 8; i++)
                    {
                        nUnq_4 = nUnq_4 | ((ulong)(uniqueArr[i + 24]) << (i * 8));
                    }

                    this.UniqueNum_4 = nUnq_4;
                }


                //  Hthm Temp
                //this.UniqueNum_1 ^= this.UniqueNum_3;
                //this.UniqueNum_2 ^= this.UniqueNum_4;


            }
            catch (Exception exp)
            {
                this.Status = FileStatus.Failed;
                this.StatusMsg = exp.Message;
            }
        }

    }

}

