using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.IO;


namespace DocArchiver.AddingFiles
{
    public class FolderInfo
    {
        public FolderInfo()
        {
            IncludeSubFolders = true;
            Status = FolderStatus.Unknown;
        }
            

        public string Path
        {
            get;
            set;
        }

        public bool IncludeSubFolders
        {
            get;
            set;
        }

        public FolderStatus Status
        {
            get;
            set;
        }

        public DirectoryInfo DirectoryInfo
        {
            get;
            set;
        }
    }

}