using System.Windows;
using System.Windows.Input;
using CashalotHelper.Infrastructure.Commands;
using CashalotHelper.ViewModels.Base;

namespace CashalotHelper.ViewModels;

public class MainWindowViewModel : ViewModel
{
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

    private BackupManagerViewModel _backupManagerVM = new BackupManagerViewModel();

    public BackupManagerViewModel BackupManagerVM => _backupManagerVM;

    #region Commands

    #region PinWindowCommand

    public ICommand PinWindowCommand { get; }

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

    public MainWindowViewModel()
    {
        PinWindowCommand = new RelayCommand(OnPinWindowCommandExecuted, CanPinWindowCommandExecute);
    }
}