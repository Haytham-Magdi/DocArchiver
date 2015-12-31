using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocArchiver
{
    class DbDiskFolder
    {
        public int ID
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }

        public bool IsValid_Org
        {
            get;
            set;
        }

        public bool IsValid_New
        {
            get;
            set;
        }

        public bool IsRoot_New
        {
            get;
            set;
        }
    }
}
