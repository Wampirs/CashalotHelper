using System.Windows;
using CashalotHelper.Infrastructure.Commands.Base;

namespace CashalotHelper.Infrastructure.Commands;

public class MinimizeWindowCommand : Command
{
    public override bool CanExecute(object parameter) => true;

    public override void Execute(object parameter)
    {
        ((parameter as Window)!).WindowState = WindowState.Minimized;
    }
}