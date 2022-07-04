//using CashalotHelper.Services;
//using System;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;

//namespace CashalotHelper.Models
//{
//    public class Backup : INotifyPropertyChanged
//    {
//        #region Fields

//        private long id;
//        private string name = String.Empty;
//        private string path = String.Empty;
//        private string createDate = " 00:00 00.00.00";
//        private string programVer = "0.0.0";
//        private int fileCount = -1;
//        private bool includeBase = true;
//        private string note = String.Empty;
//        #endregion

//        #region Properties
//        public long Id
//        {
//            get { return id; }
//            set
//            {
//                id = value;
//                OnPropertyChanged("Id");
//            }
//        }
//        public string Name
//        {
//            get { return name; }
//            set
//            {
//                name = value;
//                OnPropertyChanged("Name");
//            }
//        }
//        public String Path
//        {
//            get { return path; }
//            set
//            {
//                path = value;
//                OnPropertyChanged("Path");
//            }
//        }
//        public string CreateDate
//        {
//            get { return createDate; }
//            set
//            {
//                createDate = value;
//                OnPropertyChanged("CreateDate");
//            }
//        }
//        public String ProgramVer
//        {
//            get
//            {
//                return programVer;
//            }
//            set
//            {
//                if (value != null)
//                {
//                    //programVer = String.Empty;
//                    //string[] ver = value.Split('.');
//                    //for (int i = 0; i < 3; i++)
//                    //{
//                    //    programVer += ver[i];
//                    //    if (i != 2)
//                    //    {
//                    //        programVer += ".";
//                    //    }
//                    //}
//                    programVer = value;
//                    OnPropertyChanged("ProgramVer");
//                    return;
//                }
//                programVer = "0.0.0";
//                OnPropertyChanged("ProgramVer");
//            }
//        }
//        public int FileCount
//        {
//            get { return fileCount; }
//            set
//            {
//                fileCount = value;
//                OnPropertyChanged("FileCount");
//            }
//        }
//        public bool IncludeBase
//        {
//            get { return includeBase; }
//            set
//            {
//                includeBase = value;
//                OnPropertyChanged("IncludeBase");
//            }
//        }
//        public String Note
//        {
//            get { return note; }
//            set
//            {
//                note = value;
//                OnPropertyChanged("Note");
//            }
//        }
//        #endregion

//        #region Constructors
//        public Backup(Cashalot prog)
//        {
//            Id = DateTime.Now.Ticks;
//            Name = prog.Name;
//            //Path = FSControler.backupFolderPath + "\\" + prog.Name + Id.ToString() + ".zip";
//            CreateDate = DateTime.Now.ToString("HH:mm dd.MM.yyyy");
//            //ProgramVer = FSControler.GetFileVersion(prog.PathToExe);
//            //FileCount = FSControler.GetFileNumber(prog.FolderPath);
//            //IncludeBase = FSControler.FileExists(prog.FolderPath + "\\Cash.lot");
//        }
//        #endregion

//        public event PropertyChangedEventHandler PropertyChanged;
//        public void OnPropertyChanged([CallerMemberName] string prop = "")
//        {
//            if (PropertyChanged != null)
//                PropertyChanged(this, new PropertyChangedEventArgs(prop));
//        }
//    }
//}
