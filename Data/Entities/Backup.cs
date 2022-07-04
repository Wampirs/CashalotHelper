using System;
using CashalotHelper.Data.Entities.Base;
using CashalotHelper.Models;
using CashalotHelper.Providers.FileSystem;

namespace CashalotHelper.Data.Entities
{
    public class Backup : Entity
    {
        public string Name { get; set; } = "NotSet";
        public string Path { get; set; } = "NotSet";
        public DateTime CreateDate { get; set; } = DateTime.MinValue;
        public string Version { get; set; } = "NotSet";
        public int FileCount { get; set; } = -1;
        public string Note { get; set; } = string.Empty;

        public Backup() { }
        public Backup(Cashalot prog)
        {
            Name = prog.Name;
            Path = FileSystem.BackupsDirectory + "\\" + prog.Name + Id.ToString() + ".zip";
            CreateDate = DateTime.Now;
            //ProgramVer = FSControler.GetFileVersion(prog.PathToExe);
            //FileCount = FSControler.GetFileNumber(prog.FolderPath);
            //IncludeBase = FSControler.FileExists(prog.FolderPath + "\\Cash.lot");
        }
    }
}
