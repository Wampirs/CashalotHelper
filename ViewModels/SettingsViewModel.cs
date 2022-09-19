using CashalotHelper.Providers.Settings;
using CashalotHelper.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;

namespace CashalotHelper.ViewModels
{
    public class SettingsViewModel : ViewModel
    {
        private ISettingsProvider settings;

        public string PathToNonRelease
        {
            get { return settings.PathToNonReleaseFiles; }
            set { settings.PathToNonReleaseFiles = value; }
        }
        public string PathToMaster
        {
            get { return settings.PathToMasterBranch; }
            set { settings.PathToMasterBranch = value; }
        }
        public string PathToBrances
        {
            get { return settings.PathToBranchesFolder; }
            set { settings.PathToBranchesFolder = value; }
        }

        public SettingsViewModel()
        {
            settings = App.Services.GetRequiredService<ISettingsProvider>();
        }

    }
}
