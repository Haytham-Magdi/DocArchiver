using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using DocArchiver.AddingFiles.Steps;


namespace DocArchiver.AddingFiles
{
    public enum FileMovingAction_ID
    {
        Unknown = 0,
        Copy = 1,
        Move = 2
    }

    public class FileMovingAction
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

        public FileMovingAction_ID ID
        {
            get { return _ID; }
        }
        protected FileMovingAction_ID _ID;
        


/////////////////////////////

        public static FileMovingAction Unknown
        {
            get { return _Unknown; }
        }
        protected static readonly FileMovingAction _Unknown =
            new FileMovingAction { _Description = "Unknown",
                             _Color = Colors.Black,
                             _ID = FileMovingAction_ID.Unknown
            };

        public static FileMovingAction Copy
        {
            get { return _Copy; }
        }
        protected static readonly FileMovingAction _Copy =
            new FileMovingAction
            {
                _Description = "Copy",
                _Color = Colors.Yellow,
                _ID = FileMovingAction_ID.Copy
            };

        public static FileMovingAction Move
        {
            get { return _Move; }
        }
        protected static readonly FileMovingAction _Move =
            new FileMovingAction
            {
                _Description = "Move",
                _Color = Colors.Orange,
                _ID = FileMovingAction_ID.Move
            };

    }
}



