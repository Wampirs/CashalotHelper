using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CashalotHelper.Services;

namespace CashalotHelper.Models
{
    public class Program : INotifyPropertyChanged
    {
        #region Fields
        private string name;
        private string folderPath;
        private string pathToExe;
        private bool forAllUsers;
        private int fileCount;
        private string version;
        #endregion

        #region Properties
        public String FolderPath 
        { 
            get { return folderPath; }
            private set 
            {
                folderPath = value; 
                OnPropertyChanged("FolderPath");
            } 
        }
        public String Name 
        { 
            get { return name; }
            private set
            { 
                name = value;
                OnPropertyChanged("Name");
            } 
        }
        public bool ForAllUsers 
        {
            get { return forAllUsers; }
            private set
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
            get { return pathToExe; } 
            private set 
            {
                pathToExe = value;
                OnPropertyChanged("PathToExe");
            }
        }
        public String Version
        {
            get { return version; }
            set { version = value; OnPropertyChanged("Version"); }
        }
        #endregion

        #region Constructors
        public Program(string _name, string _path, bool _forAllUsers)
        {
            FolderPath = _path;
            Name = _name;
            ForAllUsers = _forAllUsers;
            FileCount = FSControler.GetFileNumber(folderPath);
            PathToExe = FolderPath+"\\Cashalot.exe";
            Version = FSControler.GetFileVersion(pathToExe);
        }
        public Program(Program prog)
        {
            FolderPath = prog.FolderPath;
            Name = prog.Name;
            ForAllUsers = prog.ForAllUsers;
            FileCount = FSControler.GetFileNumber(folderPath);
            PathToExe = FolderPath + "\\Cashalot.exe";
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
