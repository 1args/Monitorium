using System.Management;

namespace WpfApp2.Helpers;

public class HardwareDataProvider
{
    public string GetHardwareData(string wmiClass, string[] properties)
    {
        try
        {
            using ManagementObjectSearcher searcher 
                = new($"SELECT * FROM {wmiClass}");

            List<string> details = [];

            foreach (var managementObject in searcher.Get())
            {
                foreach (var property in properties)
                {
                    if (managementObject.Properties[property]?.Value != null)
                    {
                        details.Add($"{property}: {managementObject.Properties[property].Value}");
                    }
                }
            }

            return details.Count != 0
                ? string.Join("\n", details)
                : "No details found";
        }
        catch
        {
            return "Error retrieving data.";
        }
    }
}