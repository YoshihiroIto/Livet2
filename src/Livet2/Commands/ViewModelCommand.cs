using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Livet.Commands
{
    public sealed class ViewModelCommand : Command, ICommand, INotifyPropertyChanged
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public ViewModelCommand(Action execute) : this(execute, null) { }

        public ViewModelCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute => _canExecute?.Invoke() ?? true;

        public void Execute()
        {
            _execute();
        }

        void ICommand.Execute(object parameter)
        {
            Execute();
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
