using WpfApp2.Core;

namespace WpfApp2.Interfaces;

public interface INavigationService
{
    ViewModel? CurrentView { get; }
    void NavigationTo<TViewModel>() where TViewModel : ViewModel;
}