using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using DocArchiver.AddingFiles.Steps;


namespace DocArchiver.AddingFiles
{
    public class FolderStatus
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


        public static FolderStatus Unknown
        {
            get { return _Unknown; }
        }
        protected static readonly FolderStatus _Unknown =
            new FolderStatus { _Description = "Unknown", _Color = Colors.Black };

        public static FolderStatus Ready
        {
            get { return _Ready; }
        }
        protected static readonly FolderStatus _Ready =
            new FolderStatus { _Description = "Ready", _Color = Colors.Green };

        public static FolderStatus Repeated
        {
            get { return _Repeated; }
        }
        protected static readonly FolderStatus _Repeated =
            new FolderStatus { _Description = "Repeated", _Color = Colors.Blue };

        public static FolderStatus Invalid
        {
            get { return _Invalid; }
        }
        protected static readonly FolderStatus _Invalid =
            new FolderStatus { _Description = "Invalid", _Color = Colors.Red };

    }
}



