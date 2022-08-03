using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using CashalotHelper.Infrastructure.Commands;
using CashalotHelper.Providers.FileSystem;
using CashalotHelper.Services;
using CashalotHelper.ViewModels.Base;
using System;
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
        private readonly IFSControler fs;

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


        public BranchSelectorViewModel(IBranchControler _branchControler, IRepository<CashalotBranch> _repository, IFSControler _fs)
        {
            branchControler = _branchControler;
            repository = _repository;
            fs = _fs;
            BranchList = new ObservableCollection<CashalotBranch>(branchControler.GetRemoteBranches());
        }

        private ICommand addCommand;
        public ICommand AddCommand => addCommand ??= new RelayCommand(OnAddCommandExecuted, CanAddCommandExecute);
        private void OnAddCommandExecuted(object o)
        {
            var branch = SelectedBranch;
            branch.Note = NoteTextBoxValue;
            branch.LocalFolderPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Branch_CLs\\{branch.Name}";
            branch.LocalBatFile = $"{FileSystem.BranchesDirectory}\\{branch.Name}.lnk";
            branch.LocalExeFile = $"{branch.LocalFolderPath}\\Cashalot.exe";
            fs.CreateShortcut($"{branch.RemoteFolderPath}\\zstart.bat", branch.Name);
            repository.Add(branch);
            App.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive).Close();
        }
        private bool CanAddCommandExecute(object o) => SelectedBranch != null;


        private ICommand cancelCommand;
        public ICommand CancelCommand => cancelCommand ??= new RelayCommand(OnCancelCommandExecuted, CanCancelCommandExecute);
        private void OnCancelCommandExecuted(object o)
        {
            App.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive).Close();
        }
        private bool CanCancelCommandExecute(object o) => true;
    }
}
