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
}