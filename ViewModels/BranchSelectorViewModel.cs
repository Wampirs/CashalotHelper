using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using CashalotHelper.Infrastructure.Commands;
using CashalotHelper.Services;
using CashalotHelper.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CashalotHelper.ViewModels
{
    public class BranchSelectorViewModel : ViewModel
    {
        private readonly IBranchControler branchControler;
        private readonly IRepository<CashalotBranch> repository;
        private ObservableCollection<CashalotBranch> branchList;
        private CashalotBranch selectedBranch;
        public string Title => "BranchSelector";
        public string NoteTextBoxValue { get; set; } = string.Empty;
        public ObservableCollection<CashalotBranch> BranchList
        {
            get => branchList;
            set => Set(ref branchList, value);
        }
        public CashalotBranch SelectedBranch
        {
            get => selectedBranch;
            set => Set(ref selectedBranch, value);
        }


        public BranchSelectorViewModel(IBranchControler _branchControler, IRepository<CashalotBranch> _repository)
        {
            branchControler = _branchControler;
            repository = _repository;
            BranchList = new ObservableCollection<CashalotBranch>(branchControler.GetRemoteBranches());
        }

        private ICommand addCommand;
        public ICommand AddCommand => addCommand ??= new RelayCommand(OnAddCommandExecuted, CanAddCommandExecute);
        private void OnAddCommandExecuted(object o)
        {
            var branch = SelectedBranch;
            branch.Note = NoteTextBoxValue;
            branch.LocalFolderPath = "";
            branch.LocalBatFile = "";
            branch.LocalExeFile = "";
            repository.Add(branch);
            App.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive).Close();
        }
        private bool CanAddCommandExecute(object o) => SelectedBranch != null;
    }
}
