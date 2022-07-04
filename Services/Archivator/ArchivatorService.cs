using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using CashalotHelper.Models;
using CashalotHelper.Providers.FileSystem;
using CashalotHelper.Services.FsControler;
using CashalotHelper.Services.Interfaces;

namespace CashalotHelper.Services
{
    internal class ArchivatorService : IArchivatorService
    {
        private readonly IRepository<Backup> _backups;
        private readonly IFSControler fsControler;

        public ArchivatorService(IRepository<Backup> backups, IFSControler _fsControler)
        {
            _backups = backups;
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
            _backups.Add(backup);
        }

        public void UnpackBackup(Models.Cashalot program, Backup backup)
        {
            throw new NotImplementedException();
        }
    }
}
