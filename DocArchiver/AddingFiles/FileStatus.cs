using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using DocArchiver.AddingFiles.Steps;


namespace DocArchiver.AddingFiles
{
    public enum FileStatus_ID
    {
        Failed = -1,
        Unknown = 0,
        Complete = 1,
        Ready = 2,
        Repeated = 3
    }

    public class FileStatus
    {

        public string Description
        {
            get { return _Description; }
        }
        protected string _Description;

        public override string ToString()
        {
            return this.Description;
            //return this.Color.ToString();
            //return "Green";
        }

        public Color Color
        {
            get { return _Color; }
        }
        protected Color _Color;

        public FileStatus_ID ID
        {
            get { return _ID; }
        }
        protected FileStatus_ID _ID;
        


/////////////////////////////

        public static FileStatus Unknown
        {
            get { return _Unknown; }
        }
        protected static readonly FileStatus _Unknown =
            new FileStatus { _Description = "Unknown",
                             _Color = Colors.Black,
                             _ID = FileStatus_ID.Unknown
            };

        public static FileStatus Failed
        {
            get { return _Failed; }
        }
        protected static readonly FileStatus _Failed =
            new FileStatus { _Description = "Failed",
                             _Color = Colors.Red,
                             _ID = FileStatus_ID.Failed
            };

        public static FileStatus Repeated
        {
            get { return _Repeated; }
        }
        protected static readonly FileStatus _Repeated =
            new FileStatus { _Description = "Repeated",
                             _Color = Colors.Blue,
                             _ID = FileStatus_ID.Repeated
            };

        public static FileStatus Ready
        {
            get { return _Ready; }
        }
        protected static readonly FileStatus _Ready =
            new FileStatus { _Description = "Ready",
                             _Color = Colors.Green,
                             _ID = FileStatus_ID.Ready
            };

        public static FileStatus Complete
        {
            get { return _Complete; }
        }
        protected static readonly FileStatus _Complete =
            new FileStatus { _Description = "Complete",
                             _Color = Colors.LightGreen,
                             _ID = FileStatus_ID.Complete
            };

    }
}



