using WpfApp2.Core;
using WpfApp2.Interfaces;
using WpfApp2.MVVM.ViewModel;

namespace WpfApp2.Services;

public class NavigationService(
    Func<Type, ViewModel> viewModelFactory) : 
    ObservableObject,
    INavigationService
{
    private ViewModel _currentView =
        viewModelFactory.Invoke(typeof(HomeViewModel));

    public ViewModel CurrentView
    {
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public void NavigateTo<TViewModel>() where TViewModel : ViewModel
    {
        CurrentView = viewModelFactory.Invoke(typeof(TViewModel));
    }
}