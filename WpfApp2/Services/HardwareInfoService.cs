using WpfApp2.Interfaces;
using WpfApp2.MVVM.Model;
using System.Management;
using WpfApp2.Helpers;

namespace WpfApp2.Services;

public class HardwareInfoService(
    HardwareDataProvider hdProvider) : IHardwareInfoService
{
    private readonly HardwareDataProvider _hdProvider = hdProvider;

    public List<HardwareItemModel> GetHardwareDetails()
    {
        return
        [
            new HardwareItemModel
            {
                Name = "Processor", 
                Description = GetProcessorInfo(),
                Icon = "HardwareCpu",
            },
            new HardwareItemModel
            {
                Name = "Graphics card", 
                Description = GetGraphicsCardInfo(),
                Icon = "StairsUpReflectHorizontal",

            },
            new HardwareItemModel
            {
                Name = "Hard drive",
                Description = GetHardDriveInfo(),
                Icon = "FolderOpen",
            },
            new HardwareItemModel
            {
                Name = "Display",
                Description = GetDisplayInfo(),
                Icon = "Monitor",
            },
            new HardwareItemModel
            {
                Name = "RAM", 
                Description = GetRamInfo(),
                Icon = "CameraFlash",
            }
        ];
    }

    private string GetProcessorInfo()
    {
        return _hdProvider.GetHardwareData(
            "Win32_Processor", 
            [
                "Name",
                "Manufacturer",
                "Caption",
                "L2CacheSize",
                "L3CacheSize",
                "CurrentClockSpeed",
                "MaxClockSpeed",
                "NumberOfCores",
                "NumberOfEnabledCore",
                "NumberOfLogicalProcessors",
                "PowerManagementSupported",
                "ProcessorId",
                "SerialNumber",
                "VirtualizationFirmwareEnabled",
                "CurrentVoltage",
                "AddressWidth",
                "Status"
            ]);
    }

    private string GetGraphicsCardInfo()
    {
        return _hdProvider.GetHardwareData(
            "Win32_VideoController", 
            [
                "Name",
                "AdapterCompatibility",
                "CurrentHorizontalResolution",
                "CurrentVerticalResolution",
                "CurrentRefreshRate",
                "MaxRefreshRate",
                "MinRefreshRate",
                "AdapterRAM",
                "DriverVersion",
                "Monochrome",
                "Status"
            ]);
    }

    private string GetHardDriveInfo()
    {
        return _hdProvider.GetHardwareData(
            "Win32_DiskDrive",
            [
                "Name",
                "Manufacturer",
                "Model", 
                "FirmwareRevision",
                "InterfaceType",
                "MediaLoaded",
                "MediaType",
                "SerialNumber",
                "Size",
                "TotalCylinders", 
                "TotalHeads",
                "TotalSectors",
                "TotalTracks",
                "TracksPerCylinder", 
                "BytesPerSector",
                "Status"
            ]);
    }

    private string GetDisplayInfo()
    {
        return _hdProvider.GetHardwareData(
            "Win32_DesktopMonitor",
            [
                "Name", 
                "MonitorManufacturer", 
                "PNPDeviceID",
                "DeviceID",
                "Status"
            ]);
    }

    private string GetRamInfo()
    {
        return _hdProvider.GetHardwareData(
            "Win32_PhysicalMemory",
            [
                "Name",
                "SerialNumber",
                "Speed",
                "ConfiguredVoltage",
                "DeviceLocator",
                "MemoryType",
                "PartNumber",
                "Tag",
                "BankLabel",
                "TotalWidth", 
                "TypeDetail",
                "SMBIOSMemoryType",
                "Capacity"
            ]);
    }
}