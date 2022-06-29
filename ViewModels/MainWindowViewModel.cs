using System.Windows;
using System.Windows.Input;
using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using CashalotHelper.Infrastructure.Commands;
using CashalotHelper.ViewModels.Base;

namespace CashalotHelper.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private readonly IRepository<Backup> _backupRepository;

    #region Title
    private string _title = "Cashalot Test Helper";
    /// <summary>
    /// Заголовок окна
    /// </summary>
    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }
    #endregion

    #region PinButton ImageSource


    private string _pinImage = "/CashalotHelper;component/Resources/Images/PinDisabled.png";
    public string PinImage
    {
        get => _pinImage;
        set => Set(ref _pinImage, value);
    }

    #endregion

    #region ChildViewModels

    private ViewModel _backupManagerVM;
    private ViewModel _settingsVM;
    public ViewModel BackupManagerVM =>_backupManagerVM??= new BackupManagerViewModel(_backupRepository);
    public ViewModel SettingsVM => _settingsVM ??= new SettingsViewModel();

    #endregion

    #region Commands

    #region PinWindowCommand

    private ICommand _pinWindowCommand;
    public ICommand PinWindowCommand => _pinWindowCommand ??= new RelayCommand(OnPinWindowCommandExecuted, CanPinWindowCommandExecute);

    private void OnPinWindowCommandExecuted(object o)
    {
        if (((o as Window)!).Topmost)
        {
            ((o as Window)!).Topmost = false;
            PinImage = "/CashalotHelper;component/Resources/Images/PinDisabled.png";
            return;
        }
        ((o as Window)!).Topmost = true;
        PinImage = "/CashalotHelper;component/Resources/Images/PinEnabled.png";
    }

    private bool CanPinWindowCommandExecute(object o) => true;

    #endregion

    #endregion

    public MainWindowViewModel(IRepository<Backup> BackupRepository)
    {
        _backupRepository = BackupRepository;
    }
}