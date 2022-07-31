using CashalotHelper.Data.Entities;
using System.Collections.Generic;

namespace CashalotHelper.Services
{
    public interface IBranchControler
    {
        public bool IsBranchFolder(string path);

        public List<CashalotBranch> GetRemoteBranches();
    }
}
