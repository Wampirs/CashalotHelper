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

    #region PinState and PinButton ImageSource

    private bool _isPined = false;
    public bool IsPined
    {
        get => _isPined;
        set => Set(ref _isPined, value);
    }

    public string PinImage
    {
        get
        {
            if (IsPined) return "/CashalotHelper;component/Resources/Images/PinEnabled.png";
            return "/CashalotHelper;component/Resources/Images/PinDisabled.png";
        }
    }

    #endregion 
}