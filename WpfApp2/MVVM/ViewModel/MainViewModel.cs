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

    public MainViewModel(
        INavigationService navigationService)
    {
        _navigationService = navigationService;

        NavigateToHomeViewCommand = new RelayCommand(
            _ => NavigationService.NavigationTo<HomeViewModel>());

        NavigateToSettingsViewCommand = new RelayCommand(
            _ => NavigationService.NavigationTo<SettingsViewModel>());

    }
}