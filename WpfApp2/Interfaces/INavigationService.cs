using WpfApp2.Core;

namespace WpfApp2.Interfaces;

public interface INavigationService
{
    ViewModel? CurrentView { get; }
    void NavigateTo<TViewModel>() where TViewModel : ViewModel;
}