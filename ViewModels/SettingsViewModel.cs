using CashalotHelper.ViewModels.Base;
using CashalotHelper.Providers.Settings;

namespace CashalotHelper.ViewModels
{
    public class SettingsViewModel : ViewModel
    {
        private SettingsProvider _settings;

        public string PathToNonRelease 
        {
            get { return App.Settings.PathToNonReleaseFiles; } 
            set { App.Settings.PathToNonReleaseFiles = value; } 
        }
        public string PathToMaster 
        {
            get { return App.Settings.PathToMasterBranch; } 
            set { App.Settings.PathToMasterBranch = value;}
        }
        public string PathToBrances
        { 
            get { return App.Settings.PathToBranchesFolder; }
            set { App.Settings.PathToBranchesFolder = value;} }

    }
}
