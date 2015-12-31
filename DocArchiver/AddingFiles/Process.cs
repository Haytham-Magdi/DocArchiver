using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using DocArchiver.AddingFiles.Steps;


namespace DocArchiver.AddingFiles
{
    public class Process
    {
        public abstract class Step
        {
        }

        public Process()
        {
            SettingPaths = new SettingPaths(this);
         
            ConfirmingPaths = new ConfirmingPaths(this);

            ManagingFiles = new ManagingFiles(this);

            ViewingResults = new ViewingResults(this);            
        }

        public Session Session
        {
            get;
            set;
        }

                
        public SettingPaths SettingPaths
        {
            get;
            set;
        }


        public ConfirmingPaths ConfirmingPaths
        {
            get;
            set;
        }


        public ManagingFiles ManagingFiles
        {
            get;
            set;
        }


        public ViewingResults ViewingResults
        {
            get;
            set;
        }

        public Step LastStep
        {
            get;
            set;
        }

    }
}
