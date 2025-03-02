using System.Collections.ObjectModel;
using WpfApp2.Interfaces;
using WpfApp2.MVVM.Model;

namespace WpfApp2.MVVM.ViewModel;

public class HardwareViewModel : Core.ViewModel
{
    public string SystemName { get; set; } = Environment.MachineName;

    public ObservableCollection<HardwareItemModel> HardwareDetails { get; set; }

    public HardwareViewModel(IHardwareInfoService hardwareInfoService)
    {
        HardwareDetails = new ObservableCollection<HardwareItemModel>(hardwareInfoService.GetHardwareDetails());
    }
}
