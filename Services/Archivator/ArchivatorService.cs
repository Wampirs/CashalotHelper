using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using CashalotHelper.Models;
using CashalotHelper.Providers.FileSystem;
using CashalotHelper.Services.FsControler;
using CashalotHelper.Services.Interfaces;
using CashalotHelper.Views.Windows;
using CashBackup.Windows;
using System;
using System.IO.Compression;
using System.Threading.Tasks;

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

        public async Task<bool> PackBackup(Cashalot program)
        {
            if (program == null) throw new ArgumentNullException(nameof(program));
            if (!fsControler.IsAccessibly(program.FolderPath)) throw new Exception($"Екземпляр програми {program.Name} недоступний. Можливе його використання іншою програмою");

            WaitWindow waiter = new WaitWindow();
            waiter.StartWait("Створення бекапу");

            Task task = new Task(() =>
            {
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
            }); ;
            task.Start();
            await task;
            waiter.EndWait();
            CustomMessageBox.Show("Бекап успішно створено", MessageType.Success);
            return true;
        }

        public async Task<bool> UnpackBackup(Cashalot program, Backup backup)
        {
            if (program == null) throw new ArgumentNullException(nameof(program));
            if (backup == null) throw new ArgumentNullException(nameof(backup));
            if (!fsControler.IsAccessibly(program.FolderPath)) throw new Exception($"Екземпляр програми {program.Name} недоступний. Можливе його використання іншою програмою");
            if (!fsControler.IsAccessibly(backup.Path)) throw new Exception($"Бекап {backup.Path} недоступний. Можливе його використання іншою програмою");

            WaitWindow waiter = new WaitWindow();
            waiter.StartWait("Відновлення бекапу");

            Task task = new Task(() =>
            {
                fsControler.CleanDirectory(program.FolderPath);
                ZipFile.ExtractToDirectory(backup.Path, program.FolderPath);
                program.Version = backup.Version;
                program.FileCount = backup.FileCount;
            }); ;
            task.Start();
            await task;
            waiter.EndWait();
            CustomMessageBox.Show("Бекап успішно відновлено", MessageType.Success);
            return true;
        }
    }
}
