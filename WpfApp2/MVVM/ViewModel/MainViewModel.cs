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
    public ICommand NavigateToSettingsViewCommand { get; set; }
    public ICommand MoveWindowCommand { get; set; }
    public ICommand MinimizeWindowCommand { get; set; }
    public ICommand MaximizeWindowCommand { get; set; }

    public MainViewModel(
        INavigationService navigationService)
    {
        _navigationService = navigationService;

        NavigateToHomeViewCommand = new RelayCommand(_ =>
            NavigationService.NavigationTo<HomeViewModel>());

        NavigateToSettingsViewCommand = new RelayCommand(_ =>
            NavigationService.NavigationTo<SettingsViewModel>());

        MoveWindowCommand = new RelayCommand(_ =>
            Application.Current.MainWindow!.DragMove());

        MinimizeWindowCommand = new RelayCommand(_ =>
            Application.Current.MainWindow!.WindowState = WindowState.Minimized);

        MaximizeWindowCommand = new RelayCommand(_ =>
        {
            var state = Application.Current.MainWindow!.WindowState;

            state = state == WindowState.Maximized 
                ? WindowState.Normal 
                : WindowState.Maximized;
        });
    }
}