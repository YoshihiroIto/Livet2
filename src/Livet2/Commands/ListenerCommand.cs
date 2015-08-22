using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Livet.Commands
{
    public sealed class ListenerCommand<T> : Command, ICommand, INotifyPropertyChanged
    {
        private readonly Action<T> _execute;
        private readonly Func<bool> _canExecute;

        public ListenerCommand(Action<T> execute) : this(execute, null) { }

        public ListenerCommand(Action<T> execute, Func<bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute => _canExecute?.Invoke() ?? true;

        public void Execute(T parameter)
        {
            _execute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            if (parameter == null)
            {
                Execute(default(T));
            }
            else
            {
                Execute((T)parameter);
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged() => 
            PropertyChanged?.Invoke(this, EventArgsFactory.GetPropertyChangedEventArgs(nameof(CanExecute)));


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        public void RaiseCanExecuteChanged()
        {
            OnPropertyChanged();
            OnCanExecuteChanged();
        }

    }
}
