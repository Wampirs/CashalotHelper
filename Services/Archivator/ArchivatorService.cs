using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using CashalotHelper.Models;
using CashalotHelper.Providers.FileSystem;
using System;
using System.IO.Compression;

namespace CashalotHelper.Services
{
    internal class ArchivatorService : IArchivatorService
    {
        private readonly IRepository<Backup> backups;
        private readonly IFSControler fsControler;

        public ArchivatorService(IRepository<Backup> _backups, IFSControler _fsControler)
        {
            backups = _backups;
            fsControler = _fsControler;
        }

        public void PackBackup(Cashalot program)
        {
            if (program == null) throw new ArgumentNullException(nameof(program));
            if (!fsControler.IsAccessibly(program.FolderPath)) throw new Exception($"Екземпляр програми {program.Name} недоступний. Можливе його використання іншою програмою");
            Backup backup = new Backup
            {
                Name = program.Name,
                Version = program.Version,
                FileCount = program.FileCount,
                CreateDate = DateTime.Now,
            };
            backup.Path = $"{FileSystem.BackupsDirectory}\\{backup.Name}_{backup.Id}";
            ZipFile.CreateFromDirectory(program.FolderPath, backup.Path, CompressionLevel.Fastest, false);
            backups.Add(backup);
        }

        public void UnpackBackup(Cashalot program, Backup backup)
        {
            if (program == null) throw new ArgumentNullException(nameof(program));
            if (backup == null) throw new ArgumentNullException(nameof(backup));
            if (!fsControler.IsAccessibly(program.FolderPath)) throw new Exception($"Екземпляр програми {program.Name} недоступний. Можливе його використання іншою програмою");
            if (!fsControler.IsAccessibly(backup.Path)) throw new Exception($"Бекап {backup.Path} недоступний. Можливе його використання іншою програмою");
            fsControler.CleanDirectory(program.FolderPath);
            ZipFile.ExtractToDirectory(backup.Path, program.FolderPath);
            program.Version = backup.Version;
            program.FileCount = backup.FileCount;
        }
    }
}
