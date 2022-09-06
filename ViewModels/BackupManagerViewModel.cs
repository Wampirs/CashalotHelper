using CashalotHelper.Data.Interfaces;
using CashalotHelper.Infrastructure.Commands;
using CashalotHelper.Models;
using CashalotHelper.Providers.Interfaces;
using CashalotHelper.Services.FsControler;
using CashalotHelper.Services.Interfaces;
using CashalotHelper.ViewModels.Base;
using CashalotHelper.Views.Windows;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CashalotHelper.ViewModels;

public class BackupManagerViewModel : ViewModel
{
    private readonly IRepository<Data.Entities.Backup> backupsRepository;
    private readonly ICashalotProvider cashalotProvider;
    private readonly IArchivatorService archivator;
    private readonly IFSControler fSControler;

    #region SelectedBackup

    private Data.Entities.Backup? _selectedBackup;
    /// <summary>
    /// Вибраний бекап зі списку бекапів 
    /// </summary>
    public Data.Entities.Backup? SelectedBackup
    {
        get => _selectedBackup;
        set => Set(ref _selectedBackup, value);
    }

    #endregion

    #region SelectedProgram

    private Cashalot? _selectedProgram;
    /// <summary>
    /// Вибрана програма зі списку встановлених
    /// </summary>
    public Cashalot? SelectedProgram
    {
        get => _selectedProgram ??= Programs.ElementAtOrDefault(0);
        set => Set(ref _selectedProgram, value);
    }

    #endregion

    #region ProgramsViewCollection

    private ObservableCollection<Cashalot> _programs = null!;
    /// <summary>
    /// Колекція встановлених програм 
    /// </summary>
    public ObservableCollection<Cashalot> Programs
    {
        get => _programs;
        private set => Set(ref _programs, value);
    }

    #endregion

    #region BackupsViewCollection

    private ObservableCollection<Data.Entities.Backup> _backups;
    /// <summary>
    /// Колекція наявних бекапів
    /// </summary>
    public ObservableCollection<Data.Entities.Backup> Backups
    {
        get => _backups;
        private set => Set(ref _backups, value);
    }

    #endregion

    #region Commands

    #region CreateBackupCommand



    private ICommand _createBackupCommand;

    public ICommand CreateBackupCommand => _createBackupCommand ??=
        new RelayCommand(OnCreateBackupCommandExecuted, CanCreateBackupCommandExecute);

    private async void OnCreateBackupCommandExecuted(object o)
    {
        try
        {
            await archivator.PackBackup(SelectedProgram).ConfigureAwait(false);
            Backups = new ObservableCollection<Data.Entities.Backup>(backupsRepository.Items);
        }
        catch (Exception ex) { CustomMessageBox.Show(ex.Message, MessageType.Error); }
    }

    private bool CanCreateBackupCommandExecute(object o)
    {
        if (SelectedProgram != null) return true;
        return false;
    }

    #endregion

    #region RestoreBackupCommand

    /// <summary>
    /// Відновлює обрану програму до стану обраного бекапу
    /// </summary>

    private ICommand _restoreBackupCommand;
    public ICommand RestoreBackupCommand => _restoreBackupCommand ??=
        new RelayCommand(OnRestoreBackupCommandExecuted, CanRestoreBackupCommandExecute);
    private async void OnRestoreBackupCommandExecuted(object o)
    {
        try
        {
            await archivator.UnpackBackup(SelectedProgram, SelectedBackup).ConfigureAwait(false);
        }
        catch (Exception ex) { CustomMessageBox.Show(ex.Message, MessageType.Error); }
    }

    private bool CanRestoreBackupCommandExecute(object o)
    {
        if (SelectedProgram != null && SelectedBackup != null) return true;
        return false;
    }

    #endregion

    #region DeleteBackupCommand

    private ICommand deleteBackupCommand;


    public ICommand DeleteBackupCommand => deleteBackupCommand ??=
        new RelayCommand(OnDeleteBackupCommandExecuted, CanDeleteBackupCommandExecute);
    private void OnDeleteBackupCommandExecuted(object o)
    {
        fSControler.DeleteFile(SelectedBackup.Path);
        backupsRepository.Remove(SelectedBackup.Id);
        Backups.Remove(SelectedBackup);
        SelectedBackup = null;
    }
    private bool CanDeleteBackupCommandExecute(object o) => SelectedBackup != null;

    #endregion

    #region OpenProgramFolderCommand
    private ICommand openProgramFolder;
    public ICommand OpenProgramFolderCommand => openProgramFolder ??
        new RelayCommand(OnOpenProgramFolderCommandExecuted, CanOpenProgramFolderCommandExecute);

    private void OnOpenProgramFolderCommandExecuted(object o)
    {
        try
        {
            System.Diagnostics.Process.Start(SelectedProgram.FolderPath);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private bool CanOpenProgramFolderCommandExecute(object o) => SelectedProgram != null;
    #endregion

    #endregion


    public BackupManagerViewModel(IRepository<Data.Entities.Backup> backups,
        ICashalotProvider programs,
        IArchivatorService archivator,
        IFSControler fSControler)
    {
        backupsRepository = backups;
        Backups = new ObservableCollection<Data.Entities.Backup>(backupsRepository.Items);
        cashalotProvider = programs;
        Programs = new ObservableCollection<Cashalot>(cashalotProvider.Programs);
        this.archivator = archivator;
        this.fSControler = fSControler;
    }


}