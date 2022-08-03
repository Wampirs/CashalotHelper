using CashalotHelper.Data.Entities;
using System.Collections.Generic;
using System.IO;

namespace CashalotHelper.Services
{
    public class BranchControler : IBranchControler
    {
        private readonly IFSControler fs;
        public BranchControler(IFSControler _fs)
        {
            fs = _fs;
        }
        public List<CashalotBranch> GetRemoteBranches()
        {
            List<CashalotBranch> res = new List<CashalotBranch>();
            var dirs = Directory.GetDirectories(App.Settings.PathToBranchesFolder);
            foreach (var dir in dirs)
            {
                if (IsBranchFolder(dir))
                {
                    var branch = new CashalotBranch();
                    branch.RemoteFolderPath = dir;
                    branch.Name = new DirectoryInfo(dir).Name;
                    branch.Version = fs.GetFileVersion($"{dir}\\Cashalot.exe");
                    res.Add(branch);
                }
            }
            return res;
        }

        public bool IsBranchFolder(string path)
        {
            return fs.IsExists($"{path}\\Cashalot.exe") && fs.IsExists($"{path}\\zstart.bat");
        }

    }
}
