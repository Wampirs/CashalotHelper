using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CashalotHelper.Infrastructure.Commands;
using CashalotHelper.Models;
using CashalotHelper.Services;
using CashalotHelper.ViewModels.Base;
using Microsoft.EntityFrameworkCore;

namespace CashalotHelper.ViewModels;

public class BackupManagerViewModel : ViewModel
{
    private readonly DbService _db;

    #region SelectedBackup

    private Backup? _selectedBackup;
    /// <summary>
    /// Вибраний бекап зі списку бекапів 
    /// </summary>
    public Backup? SelectedBackup 
    { 
        get => _selectedBackup;
        set => Set(ref _selectedBackup, value);
    }

    #endregion

    #region SelectedProgram

    private Program? _selectedProgram;
    /// <summary>
    /// Вибрана програма зі списку встановлених
    /// </summary>
    public Program? SelectedProgram
    {
        get => _selectedProgram;
        set => Set(ref _selectedProgram, value);
    }

    #endregion

    #region Programs

    private ObservableCollection<Program> _programs = null!;
    /// <summary>
    /// Колекція встановлених програм 
    /// </summary>
    public ObservableCollection<Program> Programs
    {
        get => _programs;
        private set => Set(ref _programs, value);
    }

    #endregion

    #region Backups

    private ObservableCollection<Backup> _backups = null!;
    /// <summary>
    /// Колекція наявних бекапів
    /// </summary>
    public ObservableCollection<Backup> Backups
    {
        get => _backups;
        private set => Set(ref _backups, value);
    }

    #endregion

    #region Commands

    #region CreateBackupCommand
    /// <summary>
    /// Створює новий бекап на основі обраної програми
    /// </summary>
    public ICommand CreateBackupCommand { get; }

    private void OnCreateBackupCommandExecuted(object o)
    {
        MessageBox.Show("Create backup");
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
    public ICommand RestoreBackupCommand { get; }
    private void OnRestoreBackupCommandExecuted(object o)
    {
        MessageBox.Show("RestoreBackup");
    }

    private bool CanRestoreBackupCommandExecute(object o)
    {
        if (SelectedProgram!=null && SelectedBackup!=null) return true;
        return false;
    }

    #endregion

    #endregion


    public BackupManagerViewModel()
    {
        _db = new DbService();
        _db.Backups.Load();
        Backups = _db.Backups.Local.ToObservableCollection();
        CreateBackupCommand = new RelayCommand(OnCreateBackupCommandExecuted, CanCreateBackupCommandExecute);
        RestoreBackupCommand = new RelayCommand(OnRestoreBackupCommandExecuted, CanRestoreBackupCommandExecute);
    }


}