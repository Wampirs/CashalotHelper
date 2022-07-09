using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using CashalotHelper.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashalotHelper.ViewModels
{
    public class BranchManagerViewModel : ViewModel
    {
        private readonly IRepository<CashalotBranch> branchRepository;


        private ObservableCollection<CashalotBranch> localBranches;
        public ObservableCollection<CashalotBranch> LocalBranches => localBranches;
        private CashalotBranch selectedBranch;
        public CashalotBranch SelectedBranch
        {
            get => selectedBranch;
            set => Set(ref selectedBranch, value);
        }

        public BranchManagerViewModel(IRepository<CashalotBranch> _branchRepository)
        {
            branchRepository = _branchRepository;
            localBranches = new ObservableCollection<CashalotBranch>(branchRepository.Items);
        }
    }
}
