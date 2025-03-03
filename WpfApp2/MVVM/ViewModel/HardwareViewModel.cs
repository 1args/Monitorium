using System.Collections.ObjectModel;
using WpfApp2.Interfaces;
using WpfApp2.MVVM.Model;

namespace WpfApp2.MVVM.ViewModel;

public class HardwareViewModel : Core.ViewModel
{
    public string SystemName { get; set; } = Environment.MachineName;
    public ObservableCollection<HardwareItemModel> HardwareDetails { get; set; } = [];

    private readonly IHardwareInfoService _hardwareInfoService;

    public HardwareViewModel(IHardwareInfoService hardwareInfoService)
    {
        _hardwareInfoService = hardwareInfoService;
        LoadHardwareDetailsAsync();
    }

    private async void LoadHardwareDetailsAsync()
    {
        var details = await Task.Run(() => _hardwareInfoService.GetHardwareDetails());
        foreach (var item in details)
        {
            HardwareDetails.Add(item);
            await Task.Delay(450);
        }
    }
}
