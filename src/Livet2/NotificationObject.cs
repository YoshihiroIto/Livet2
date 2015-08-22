using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Livet
{
    public class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "") => 
            PropertyChanged?.Invoke(this, EventArgsFactory.GetPropertyChangedEventArgs(propertyName));
    }
}
