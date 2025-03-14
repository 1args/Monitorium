```
 ___ ___   ___   ____   ____  ______   ___   ____   ____  __ __  ___ ___ 
|   |   | /   \ |    \ |    ||      | /   \ |    \ |    ||  |  ||   |   |
| _   _ ||     ||  _  | |  | |      ||     ||  D  ) |  | |  |  || _   _ |
|  \_/  ||  O  ||  |  | |  | |_|  |_||  O  ||    /  |  | |  |  ||  \_/  |
|   |   ||     ||  |  | |  |   |  |  |     ||    \  |  | |  :  ||   |   |
|   |   ||     ||  |  | |  |   |  |  |     ||  .  \ |  | |     ||   |   |
|___|___| \___/ |__|__||____|  |__|   \___/ |__|\_||____| \__,_||___|___|
```
                                          
# Monitorium (WPF App)

Used:
- MVVM Pattern
- Command operation via RelayCommand, ObservableObject via INotifyPropertyChanged
- DependencyInjection
- Own navigation service
- Splitting into separate styles
- .NET 9

The project contains an example of clean architecture through the use of modern, relevant solutions. MainWindow is used as the main window. Pages are represented by UserControl elements. The interface may not look great, because I'm not very creative. The project contains a simple logic: the application receives data about the hardware.

Added nuget packages:
- Microsoft.Extensions.DependencyInjection
- MahApps.Metro.IconPacks
- System.Management

[**[>] Result (Video)**](https://youtu.be/1lxdulQuZ-M)
