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
        private static MainWindowViewModel mainWindowVM;
        private static BackupManagerViewModel backupManagerVM;
        private static SettingsViewModel settingsVM;
        private static BranchManagerViewModel branchManagerVM;
        public static MainWindowViewModel MainWindowViewModel => mainWindowVM ??= App.Services.GetRequiredService<MainWindowViewModel>();
        public static BackupManagerViewModel BackupManagerViewModel => backupManagerVM ??= App.Services.GetRequiredService<BackupManagerViewModel>();
        public static SettingsViewModel SettingsViewModel => settingsVM ??= App.Services.GetRequiredService<SettingsViewModel>();
        public static BranchManagerViewModel BranchManagerViewModel => branchManagerVM ??= App.Services.GetRequiredService<BranchManagerViewModel>();
    }
}
