using System.Windows;
using System.Windows.Input;
using WpfApp2.Core;
using WpfApp2.Interfaces;

namespace WpfApp2.MVVM.ViewModel;

public class MainViewModel : Core.ViewModel
{
    private INavigationService _navigationService;

    public INavigationService NavigationService
    {
        get => _navigationService;
        set
        {
            _navigationService = value;
            OnPropertyChanged();
        }
    }

    public ICommand NavigateToHomeViewCommand { get; set; }
    public ICommand NavigateToHardwareViewCommand { get; set; }
    public ICommand MoveWindowCommand { get; set; }
    public ICommand MinimizeWindowCommand { get; set; }
    public ICommand MaximizeWindowCommand { get; set; }
    public ICommand CloseWindowCommand { get; set; }

    public MainViewModel(
        INavigationService navigationService)
    {
        _navigationService = navigationService;

        var mainWindow = Application.Current.MainWindow!;

        mainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

        NavigateToHomeViewCommand = new RelayCommand(_ =>
            NavigationService.NavigateTo<HomeViewModel>());

        NavigateToHardwareViewCommand = new RelayCommand(_ =>
            NavigationService.NavigateTo<HardwareViewModel>());

        MoveWindowCommand = new RelayCommand(_ =>
            mainWindow.DragMove());

        MinimizeWindowCommand = new RelayCommand(_ =>
            mainWindow.WindowState = WindowState.Minimized);

        MaximizeWindowCommand = new RelayCommand(_ =>
        {
            mainWindow.WindowState = mainWindow.WindowState == WindowState.Maximized 
                ? WindowState.Normal 
                : WindowState.Maximized;
        });
 
        CloseWindowCommand = new RelayCommand(_ =>
            Application.Current.Shutdown());
    }
}