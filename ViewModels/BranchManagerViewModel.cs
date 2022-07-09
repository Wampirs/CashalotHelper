using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using CashalotHelper.Infrastructure.Commands;
using CashalotHelper.ViewModels.Base;
using CashalotHelper.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        private ICommand selectBranchCommand;
        public ICommand SelectBranchCommand => selectBranchCommand ??=
            new RelayCommand(OnSelectBranchCommandExecuted,CanSelectBranchCommandExecute);

        private void OnSelectBranchCommandExecuted (object o)
        {
            BranchSelector.OpenWindow();
        }
        private bool CanSelectBranchCommandExecute(object o) => true;
    }
}
