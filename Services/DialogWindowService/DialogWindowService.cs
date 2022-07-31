using CashalotHelper.Views.Windows;

namespace CashalotHelper.Services
{
    public class DialogWindowService : IDialogWindowService
    {
        public bool? ShowDialog(object vm)
        {
            DialogWindow win = new DialogWindow();
            win.DataContext = vm;
            return win.ShowDialog();
        }
    }
}
