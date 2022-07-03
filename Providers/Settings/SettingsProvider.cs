using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;

namespace CashalotHelper.Providers.Settings
{
    public class SettingsProvider : ISettingsProvider
    {
        private IConfigRepository<Configuration> _configRepository;
        private Configuration _pathToMasterBranch;
        private Configuration _pathToBranchesFolder;
        private Configuration _pathToNonReleaseFiles;

        public string PathToMasterBranch 
        {
            get => _pathToMasterBranch.Value;
            set
            {
                _pathToMasterBranch.Value = value;
                SaveChangesToDb(_pathToMasterBranch);
            }
        }
        public string PathToBranchesFolder 
        { 
            get => _pathToBranchesFolder.Value;
            set
            {
                _pathToBranchesFolder.Value = value;
                 SaveChangesToDb(_pathToBranchesFolder);
            } 
        }
        public string PathToNonReleaseFiles 
        {
            get => _pathToNonReleaseFiles.Value;
            set
            {
                _pathToNonReleaseFiles.Value = value;
                SaveChangesToDb(_pathToNonReleaseFiles);
            }
        }

        public SettingsProvider(IConfigRepository<Configuration> configRepository)
        {
            _configRepository = configRepository;
            InitializeProperties();
        }
        private void SaveChangesToDb(Configuration conf)
        {
            _configRepository.UpdateOrCreate(conf);
        }
      
        private void InitializeProperties()
        {
            if (_configRepository.Get("PathToMasterBranch") == null)
            {
                _pathToMasterBranch = new Configuration { Property = "PathToMasterBranch", Value = "" };
                SaveChangesToDb(_pathToMasterBranch);
            }
            else _pathToMasterBranch = _configRepository.Get("PathToMasterBranch");


            if (_configRepository.Get("PathToBranchesFolder") == null)
            {
                _pathToBranchesFolder = new Configuration { Property = "PathToBranchesFolder", Value = "" };
                SaveChangesToDb(_pathToBranchesFolder);
            }
            else _pathToBranchesFolder = _configRepository.Get("PathToBranchesFolder");


            if (_configRepository.Get("PathToNonReleaseFiles") == null)
            {
                _pathToNonReleaseFiles = new Configuration { Property = "PathToNonReleaseFiles", Value = "" };
                SaveChangesToDb(_pathToNonReleaseFiles);
            }
            else _pathToNonReleaseFiles = _configRepository.Get("PathToNonReleaseFiles");
        }
    }
}
