using CashalotHelper.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CashalotHelper.ViewModels.Base
{

    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(value, field)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}