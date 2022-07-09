using CashalotHelper.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CashalotHelper.Data.Entities
{
    public class CashalotBranch : Entity, INotifyPropertyChanged
    {
        private string note;
        public string Name { get; set; }
        public string Note 
        {
            get => note;
            set
            {
                note = value;
                OnPropertyChanged();
            }
        } 
        public string RemoteFolderPath { get; set; } 

        public string LocalFolderPath { get; set; }
        public string LocalBatFile { get; set; }
        public string LocalExeFile { get; set; }
        public string Version { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
