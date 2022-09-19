﻿using CashalotHelper.Infrastructure.Commands.Base;
using System.Windows;

namespace CashalotHelper.Infrastructure.Commands
{

    public class CloseWindowCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            ((parameter as Window)!).Close();
        }
    }
}