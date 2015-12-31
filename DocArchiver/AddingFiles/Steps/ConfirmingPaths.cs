using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocArchiver.AddingFiles.Steps
{
    public class ConfirmingPaths : Process.Step
    {        


        public ConfirmingPaths(Process a_proc)
        {
            m_proc = a_proc;
            
        }

        public void Prepare()
        {
            if (m_proc.LastStep != m_proc.SettingPaths)
                throw new InvalidOperationException(
                    "m_proc.LastStep != m_proc.SettingPaths");

            //m_proc.LastStep = this;

            FolderInfo_List = m_proc.SettingPaths.FolderInfo_List;

            Proceed();
        }

        public void Proceed()
        {
            //  REmoving empty entries.
            for(int i = 0; i < this.FolderInfo_List.Count; i++)
            {
                FolderInfo fi = this.FolderInfo_List[i];

                //if (string.IsNullOrEmpty(fi.Path.Trim()))
                if (fi.Path == null || fi.Path.Trim() == "")
                {
                    this.FolderInfo_List.RemoveAt(i);
                    i--;
                }

            }

            {
                List<FolderInfo> fi_List_1 =
                    new List<FolderInfo>(this.FolderInfo_List);

                List<FolderInfo> fi_List_2 =
                    new List<FolderInfo>(this.FolderInfo_List.Count);

                while (fi_List_1.Count > 0)
                {
                    int nMLI = 0;

                    for (int j = 0; j < fi_List_1.Count; j++)
                    {
                        if (fi_List_1[j].Path.Length < fi_List_1[nMLI].Path.Length)
                            nMLI = j;
                    }

                    FolderInfo fi_MinLen = fi_List_1[nMLI];
                    int nMinLen = fi_MinLen.Path.Length;

                    fi_MinLen.Status = FolderStatus.Ready;

                    fi_List_2.Add(fi_MinLen);
                    fi_List_1.RemoveAt(nMLI);

                    for (int j = 0; j < fi_List_1.Count; j++)
                    {
                        if (
                            fi_MinLen.IncludeSubFolders == false &&
                            fi_MinLen.Path.Length != fi_List_1[j].Path.Length)
                            continue;

                        if (fi_MinLen.Path ==
                            fi_List_1[j].Path.Substring(0, nMinLen))
                        {
                            {
                                int nIndex1 = fi_List_1[j].Path.IndexOf('\\', nMinLen - 1);

                                if (nIndex1 == -1 &&
                                    fi_MinLen.Path.Length != fi_List_1[j].Path.Length)
                                {
                                    continue;
                                }
                                else if( nIndex1 != fi_MinLen.Path.Length )
                                {
                                    continue;
                                }

                            }



                            fi_List_1[j].Status = FolderStatus.Repeated;

                            fi_List_2.Add(fi_List_1[j]);
                            fi_List_1.RemoveAt(j);

                            j--;
                        }
                    }

                }
            }

            foreach (FolderInfo fi in this.FolderInfo_List)
            {
                fi.DirectoryInfo = new System.IO.DirectoryInfo(fi.Path);
                if (fi.DirectoryInfo.Exists == false)
                    fi.Status = FolderStatus.Invalid;
            }


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
