using WpfApp2.MVVM.Model;

namespace WpfApp2.Interfaces;

public interface IHardwareInfoService
{
    List<HardwareItemModel> GetHardwareDetails();
}