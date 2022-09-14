using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CashalotHelper.Models
{
    public class Cashalot : INotifyPropertyChanged
    {
        #region Fields
        private string name;
        private string folderPath;
        private bool forAllUsers;
        private int fileCount;
        private string version;
        private bool testVersion;
        #endregion

        #region Properties
        public String FolderPath 
        { 
            get { return folderPath; }
            set 
            {
                folderPath = value; 
                OnPropertyChanged("FolderPath");
            } 
        }
        public String Name 
        { 
            get { return name; }
            set
            { 
                name = value;
                OnPropertyChanged("Name");
            } 
        }
        public bool ForAllUsers 
        {
            get { return forAllUsers; }
            set
            {
                forAllUsers = value;
                OnPropertyChanged("ForAllUsers");
            }
        }
        public int FileCount 
        {
            get { return fileCount; }
            set 
            { 
                fileCount = value;
                OnPropertyChanged("FileCount");
            }
        }
        public string PathToExe 
        {
            get { return FolderPath + "\\Cashalot.exe"; } 
        }
        public String Version
        {
            get { return version; }
            set { version = value; OnPropertyChanged("Version"); }
        }
        public bool TestVersion
        {
            get { return testVersion; }
            set { testVersion = value; OnPropertyChanged("TestVersion"); }
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
