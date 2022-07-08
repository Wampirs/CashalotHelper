using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CashalotHelper.ViewModels
{
    class ViewModelLocator
    {
        public static MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
        public static BackupManagerViewModel BackupManagerViewModel => App.Services.GetRequiredService<BackupManagerViewModel>();
        public static SettingsViewModel SettingsViewModel => App.Services.GetRequiredService<SettingsViewModel>();
        public static BranchManagerViewModel BranchManagerViewModel => App.Services.GetRequiredService<BranchManagerViewModel>();   
    }
}
