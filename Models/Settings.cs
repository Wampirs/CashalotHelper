using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CashalotHelper.Models
{
    public class Settings
    {
        private IConfigRepository<Configuration> _configRepository;
        private Configuration _pathToMasterBranch;
        private Configuration _pathToBranchesFolder;
        private Configuration _pathToNonReleaseFiles;

        public Configuration PathToMasterBranch 
        { 
            get => _pathToMasterBranch;
            set
            {
                _pathToMasterBranch = value;
                SaveChangesToDb();
            }
        }
        public Configuration PathToBranchesFolder 
        { 
            get => _pathToBranchesFolder;
            set
            {
                _pathToBranchesFolder = value;
                 SaveChangesToDb();
            } 
        }
        public Configuration PathToNonReleaseFiles 
        {
            get => _pathToNonReleaseFiles;
            set
            {
                _pathToNonReleaseFiles = value;
                SaveChangesToDb();
            }
        }

        public Settings(IConfigRepository<Configuration> configRepository)
        {
            _configRepository = configRepository;
        }
        private void SaveChangesToDb([CallerMemberName] string paramName = "_-_")
        {
            _configRepository.UpdateOrCreate(paramName);
        }
      
    }
}
