using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocArchiver
{
    class AppCfg
    {
        public static string ArchivePath
        {
            get { return @"D:\HthmWork_D\DocArchiver_Archive"; }
        }

        public static string ArchivePath_Core
        {
            get { return ArchivePath + "\\CoreFiles"; }
        }

        public static string ArchivePath_Bad
        {
            get { return ArchivePath + "\\BadFiles"; }
        }
    }
}
