﻿using Microsoft.Extensions.DependencyInjection;
using WpfApp2.Core;
using WpfApp2.Helpers;
using WpfApp2.Interfaces;
using WpfApp2.MVVM.ViewModel;
using WpfApp2.Services;

namespace WpfApp2.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>(provider => new MainWindow()
        {
            DataContext = provider.GetRequiredService<MainViewModel>()
        });

        services.AddSingleton<Func<Type, ViewModel>>(provider =>
            viewModelType => (ViewModel)provider.GetRequiredService(viewModelType));

        services.AddSingleton<MainViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<HardwareViewModel>();

        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IHardwareInfoService, HardwareInfoService>();

        services.AddSingleton<HardwareDataProvider>();
    }
}