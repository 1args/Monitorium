using System.Collections.ObjectModel;
using WpfApp2.MVVM.Model;

namespace WpfApp2.MVVM.ViewModel;

public class HomeViewModel : Core.ViewModel
{
    public string UserName { get; set; } = Environment.UserName;
    public ObservableCollection<HardwareItemModel> HardwareDetails { get; set; } =
    [
        new HardwareItemModel() { Name = "Processor (CPU)" },
        new HardwareItemModel() { Name = "Graphics card (GPU)" },
        new HardwareItemModel() { Name = "Hard drive" },
        new HardwareItemModel() { Name = "Display" },
        new HardwareItemModel() { Name = "RAM" },
    ];
}