using CashalotHelper.Services;
using CashalotHelper.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashalotHelper.ViewModels
{
    public class SettingsViewModel : ViewModel
    {
        private Settings _settings;

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
