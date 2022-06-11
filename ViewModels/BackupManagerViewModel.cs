﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CashalotHelper.Data.Interfaces;
using CashalotHelper.Infrastructure.Commands;
using CashalotHelper.Models;
using CashalotHelper.Services;
using CashalotHelper.ViewModels.Base;
using Microsoft.EntityFrameworkCore;

namespace CashalotHelper.ViewModels;

public class BackupManagerViewModel : ViewModel
{

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

    private Cashalot? _selectedProgram;
    /// <summary>
    /// Вибрана програма зі списку встановлених
    /// </summary>
    public Cashalot? SelectedProgram
    {
        get => _selectedProgram;
        set => Set(ref _selectedProgram, value);
    }

    #endregion

    #region Programs

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

    #region Backups

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

    /// <summary>
    /// Створює новий бекап на основі обраної програми
    /// </summary>

    private ICommand _createBackupCommand;

    public ICommand CreateBackupCommand => _createBackupCommand ??=
        new RelayCommand(OnCreateBackupCommandExecuted, CanCreateBackupCommandExecute);

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

    private ICommand _restoreBackupCommand;
    public ICommand RestoreBackupCommand => _restoreBackupCommand ??= 
        new RelayCommand(OnRestoreBackupCommandExecuted, CanRestoreBackupCommandExecute);
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


    public BackupManagerViewModel(IRepository<Data.Entities.Backup> backups )
    {
        
    }


}