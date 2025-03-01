using WpfApp2.Core;
using WpfApp2.Interfaces;

namespace WpfApp2.Services;

public class NavigationService(
    Func<Type, ViewModel> viewModelFactory) : 
    ObservableObject,
    INavigationService
{
    private ViewModel _currentView;

    public ViewModel CurrentView
    {
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public void NavigationTo<TViewModel>() where TViewModel : ViewModel
    {
        var viewModel = viewModelFactory.Invoke(typeof(TViewModel));
        CurrentView = _currentView;
    }
}