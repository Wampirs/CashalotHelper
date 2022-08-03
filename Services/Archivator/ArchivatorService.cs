using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using CashalotHelper.Models;
using CashalotHelper.Providers.FileSystem;
using CashalotHelper.Services.FsControler;
using CashalotHelper.Services.Interfaces;
using CashalotHelper.Views.Windows;
using CashBackup.Windows;
using System;
using System.ComponentModel;
using System.IO.Compression;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace CashalotHelper.Services
{
    internal class ArchivatorService : IArchivatorService
    {
        private readonly IRepository<Backup> backups;
        private readonly IFSControler fs;
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        public ArchivatorService(IRepository<Backup> _backups, IFSControler _fsControler)
        {
            backups = _backups;
            fs = _fsControler;
        }

        //public void PackBackup(Cashalot program)
        //{
        //    if (program == null) throw new ArgumentNullException(nameof(program));
        //    if (!fsControler.IsAccessibly(program.FolderPath)) throw new Exception($"Екземпляр програми {program.Name} недоступний. Можливе його використання іншою програмою");
        //    Backup backup = new Backup
        //    {
        //        Name = program.Name,
        //        Version = program.Version,
        //        FileCount = program.FileCount,
        //        CreateDate = DateTime.Now,
        //    };
        //    backup.Path = $"{FileSystem.BackupsDirectory}\\{backup.Name}_{backup.Id}";
        //    ZipFile.CreateFromDirectory(program.FolderPath, backup.Path, CompressionLevel.Fastest, false);
        //    backups.Add(backup);
        //}

        //public void UnpackBackup(Cashalot program, Backup backup)
        //{
        //    if (program == null) throw new ArgumentNullException(nameof(program));
        //    if (backup == null) throw new ArgumentNullException(nameof(backup));
        //    if (!fsControler.IsAccessibly(program.FolderPath)) throw new Exception($"Екземпляр програми {program.Name} недоступний. Можливе його використання іншою програмою");
        //    if (!fsControler.IsAccessibly(backup.Path)) throw new Exception($"Бекап {backup.Path} недоступний. Можливе його використання іншою програмою");
        //    fsControler.CleanDirectory(program.FolderPath);
        //    ZipFile.ExtractToDirectory(backup.Path,program.FolderPath);
        //    program.Version = backup.Version;
        //    program.FileCount = backup.FileCount;
        //}

        public void PackBackup(Cashalot program)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Worker_Pack;
            worker.RunWorkerAsync(program);
            while (worker.IsBusy)
            {
                var frame = new DispatcherFrame();
                Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                    new DispatcherOperationCallback(
                        delegate (object f)
                        {
                            ((DispatcherFrame)f).Continue = false;
                            return null;
                        }), frame);
                Dispatcher.PushFrame(frame);
            }
        }


        //Публічні методи
        /// <summary>
        /// Откатывает программу до состояния бекапа
        /// </summary>
        /// <param name="backup">Бекап для востановления</param>
        /// <param name="program">Программа, которая будет восстановлена</param>
        public void UnpackBackup(Cashalot program, Backup backup)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Worker_Unpack;
            worker.RunWorkerAsync(new UnpackSet(backup, program));
            while (worker.IsBusy)
            {
                var frame = new DispatcherFrame();
                Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                    new DispatcherOperationCallback(
                        delegate (object f)
                        {
                            ((DispatcherFrame)f).Continue = false;
                            return null;
                        }), frame);
                Dispatcher.PushFrame(frame);
            }
        }

        //BackgroundWorker задачі
        private void Worker_Unpack(object sender, DoWorkEventArgs e)
        {
            var waiter = Application.Current.Dispatcher.Invoke(() =>
            {
                WaitWindow dialog = new WaitWindow();
                dialog.StartWait("Розпакування бекапу");
                return dialog;
            });
            UnpackSet set = e.Argument as UnpackSet;
            try
            {
                Unpack(set.backup, set.program);
                Application.Current.Dispatcher.Invoke(() => waiter.EndWait());
                Application.Current.Dispatcher.Invoke(() => CustomMessageBox.Show("Розпакування бекапу пройшло вдало", MessageType.Success));
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() => waiter.EndWait());
                if (ex is ArgumentNullException)
                {
                    Application.Current.Dispatcher.Invoke(() => CustomMessageBox.Show(ex.Message, MessageType.Warning));
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(() => CustomMessageBox.Show(ex.Message, MessageType.Error));
                }
            }
        }
        private void Worker_Pack(object sender, DoWorkEventArgs e)
        {
            var waiter = Application.Current.Dispatcher.Invoke(() =>
            {
                WaitWindow dialog = new WaitWindow();
                dialog.StartWait("Створення бекапу");
                return dialog;
            });
            try
            {
                Pack(e.Argument as Cashalot);
                Application.Current.Dispatcher.Invoke(() => waiter.EndWait());
                Application.Current.Dispatcher.Invoke(() => CustomMessageBox.Show("Створення бекапу пройшло вдало", MessageType.Success));
                _resetEvent.Set();
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() => waiter.EndWait());
                if (ex is ArgumentNullException)
                {
                    Application.Current.Dispatcher.Invoke(() => CustomMessageBox.Show(ex.Message, MessageType.Warning));
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(() => CustomMessageBox.Show(ex.Message, MessageType.Error));
                }
            }
        }

        //Пакування та розпакування бекапів
        private void Pack(Cashalot program)
        {
            if (program != null)
            {
                if (fs.IsAccessibly(program.FolderPath))
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
                    return;
                }
                throw new Exception($"Папка {program.FolderPath} зайнята іншим процесом");
            }
            throw new ArgumentNullException(nameof(program));
        }
        private void Unpack(Backup backup, Cashalot program)
        {
            if (backup != null && program != null)
            {
                if (fs.IsAccessibly(program.FolderPath) && fs.IsAccessibly(backup.Path))
                {
                    fs.CleanDirectory(program.FolderPath);
                    ZipFile.ExtractToDirectory(backup.Path, program.FolderPath);
                    program.FileCount = backup.FileCount;
                    program.Version = backup.Version;
                    return;
                }
                throw new Exception($"Программа або бекап використовуються іншим процесом");
            }
            else if (backup == null)
            {
                throw new ArgumentNullException(nameof(backup));
            }
            else if (program == null)
            {
                throw new ArgumentNullException(nameof(program));
            }
        }


        //Внутрішній клас для передачі аргументів при розпаковці бекапу
        private class UnpackSet
        {
            public Backup backup;
            public Cashalot program;

            public UnpackSet(Backup _backup, Cashalot _program)
            {
                backup = _backup;
                program = _program;
            }
        }

    }
}
