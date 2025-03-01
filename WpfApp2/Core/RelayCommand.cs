using System.Windows.Input;

namespace WpfApp2.Core;

public class RelayCommand(
    Action<object> execute,
    Func<object, bool> canExecute = null) : 
    ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object parameter) =>
        canExecute == null || CanExecute(parameter);

    public void Execute(object parameter) =>
        execute(parameter);
}