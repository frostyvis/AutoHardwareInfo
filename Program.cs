using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using OpenHardwareMonitor.Hardware;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

class HardwareInfo
{
    static void Temperature()
    {
        Computer computer = new Computer();
        computer.CPUEnabled = true;
        computer.GPUEnabled = true;
        computer.MainboardEnabled = true;
        computer.HDDEnabled = true;

        computer.Open();

        string filePath = "hardware_info.txt";
        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            writer.WriteLine(DateTime.UtcNow);
            foreach (var hardwareItem in computer.Hardware)
            {
                hardwareItem.Update();
                writer.WriteLine($"Hardware: {hardwareItem.Name}");

                foreach (var sensor in hardwareItem.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature)
                    {
                        writer.WriteLine($"  {sensor.Name}: {sensor.Value} °C");
                    }
                }
            }
        }

        computer.Close();

    }

    static void HddInfo()
    {
        string filePath = "hardware_info.txt";

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

            searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            writer.WriteLine("\nDisk Drive Information:");
            foreach (ManagementObject obj in searcher.Get())
            {
                writer.WriteLine("\nModel: " + obj["Model"]);
                writer.WriteLine("Interface Type: " + obj["InterfaceType"]);
                ulong sizeGB = Convert.ToUInt64(obj["Size"]) / (1024 * 1024 * 1024);
                writer.WriteLine($"Size: {sizeGB} Gb");
                writer.WriteLine("Serial Number: " + obj["SerialNumber"]);
                writer.WriteLine();
            }
        }
    }

    static void InfoAll()
    {
        try
        {
            string filePath = "hardware_info.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

                writer.WriteLine("\nProcessor Information:");
                foreach (ManagementObject obj in searcher.Get())
                {
                    writer.WriteLine("Name: " + obj["Name"]);
                    writer.WriteLine("Manufacturer: " + obj["Manufacturer"]);
                    writer.WriteLine("Current Clock Speed: " + obj["CurrentClockSpeed"] + " MHz");
                    writer.WriteLine("Number of Cores: " + obj["NumberOfCores"]);
                }

                searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
                writer.WriteLine("\nMemory Information:");
                foreach (ManagementObject obj in searcher.Get())
                {
                    ulong sizeGB = Convert.ToUInt64(obj["Capacity"]) / (1024 * 1024 * 1024);
                    writer.WriteLine($"Capacity: {sizeGB} Gb");
                    writer.WriteLine("Manufacturer: " + obj["Manufacturer"]);
                    writer.WriteLine("Speed: {0} MHz", obj["Speed"]);
                    writer.WriteLine("Memory Type: {0}", obj["MemoryType"]);
                    writer.WriteLine("Part Number: {0}", obj["PartNumber"]);
                    writer.WriteLine("Serial Number: {0}", obj["SerialNumber"]);
                    writer.WriteLine("Form Factor: {0}", obj["FormFactor"]);
                }

                searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
                writer.WriteLine("\nComputer System Information:");
                foreach (ManagementObject obj in searcher.Get())
                {
                    foreach (var property in obj.Properties)
                    {
                        writer.WriteLine($"{property.Name}: {property.Value}");
                    }
                }

                searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                writer.WriteLine("\nBase Board Information:");
                foreach (ManagementObject obj in searcher.Get())
                {
                    foreach (var property in obj.Properties)
                    {
                        writer.WriteLine($"{property.Name}: {property.Value}");
                    }
                }

                searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process");
                writer.WriteLine("\nProcess Information:");
                foreach (ManagementObject obj in searcher.Get())
                {
                    writer.WriteLine("Process: {0} - ID: {1}", obj["Name"], obj["ProcessId"]);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    public class HDD
    {

        public int Index { get; set; }
        public bool IsOK { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Serial { get; set; }
        public Dictionary<int, Smart> Attributes = new Dictionary<int, Smart>() {
                {0x00, new Smart("Invalid")},
                {0x01, new Smart("Raw read error rate")},
                {0x02, new Smart("Throughput performance")},
                {0x03, new Smart("Spinup time")},
                {0x04, new Smart("Start/Stop count")},
                {0x05, new Smart("Reallocated sector count")},
                {0x06, new Smart("Read channel margin")},
                {0x07, new Smart("Seek error rate")},
                {0x08, new Smart("Seek timer performance")},
                {0x09, new Smart("Power-on hours count")},
                {0x0A, new Smart("Spinup retry count")},
                {0x0B, new Smart("Calibration retry count")},
                {0x0C, new Smart("Power cycle count")},
                {0x0D, new Smart("Soft read error rate")},
                {0xB8, new Smart("End-to-End error")},
                {0xBE, new Smart("Airflow Temperature")},
                {0xBF, new Smart("G-sense error rate")},
                {0xC0, new Smart("Power-off retract count")},
                {0xC1, new Smart("Load/Unload cycle count")},
                {0xC2, new Smart("HDD temperature")},
                {0xC3, new Smart("Hardware ECC recovered")},
                {0xC4, new Smart("Reallocation count")},
                {0xC5, new Smart("Current pending sector count")},
                {0xC6, new Smart("Offline scan uncorrectable count")},
                {0xC7, new Smart("UDMA CRC error rate")},
                {0xC8, new Smart("Write error rate")},
                {0xC9, new Smart("Soft read error rate")},
                {0xCA, new Smart("Data Address Mark errors")},
                {0xCB, new Smart("Run out cancel")},
                {0xCC, new Smart("Soft ECC correction")},
                {0xCD, new Smart("Thermal asperity rate (TAR)")},
                {0xCE, new Smart("Flying height")},
                {0xCF, new Smart("Spin high current")},
                {0xD0, new Smart("Spin buzz")},
                {0xD1, new Smart("Offline seek performance")},
                {0xDC, new Smart("Disk shift")},
                {0xDD, new Smart("G-sense error rate")},
                {0xDE, new Smart("Loaded hours")},
                {0xDF, new Smart("Load/unload retry count")},
                {0xE0, new Smart("Load friction")},
                {0xE1, new Smart("Load/Unload cycle count")},
                {0xE2, new Smart("Load-in time")},
                {0xE3, new Smart("Torque amplification count")},
                {0xE4, new Smart("Power-off retract count")},
                {0xE6, new Smart("GMR head amplitude")},
                {0xE7, new Smart("Temperature")},
                {0xF0, new Smart("Head flying hours")},
                {0xFA, new Smart("Read error retry rate")},
                /* slot in any new codes you find in here */
            };

    }

    public class Smart
    {
        public bool HasData
        {
            get
            {
                if (Current == 0 && Worst == 0 && Threshold == 0 && Data == 0)
                    return false;
                return true;
            }
        }
        public string Attribute { get; set; }
        public int Current { get; set; }
        public int Worst { get; set; }
        public int Threshold { get; set; }
        public int Data { get; set; }
        public bool IsOK { get; set; }

        public Smart()
        {

        }

        public Smart(string attributeName)
        {
            this.Attribute = attributeName;
        }
    }

    /// <summary>
    /// Tested against Crystal Disk Info 5.3.1 and HD Tune Pro 3.5 on 15 Feb 2013.
    /// Findings; I do not trust the individual smart register "OK" status reported back frm the drives.
    /// I have tested faulty drives and they return an OK status on nearly all applications except HD Tune. 
    /// After further research I see HD Tune is checking specific attribute values against their thresholds
    /// and and making a determination of their own (which is good) for whether the disk is in good condition or not.
    /// I recommend whoever uses this code to do the same. For example -->
    /// "Reallocated sector count" - the general threshold is 36, but even if 1 sector is reallocated I want to know about it and it should be flagged.   
    /// </summary>

    static void HddSmart()
    {
        try
        {

            // retrieve list of drives on computer (this will return both HDD's and CDROM's and Virtual CDROM's)                    
            var dicDrives = new Dictionary<int, HDD>();

            var wdSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            // extract model and interface information
            int iDriveIndex = 0;
            foreach (ManagementObject drive in wdSearcher.Get())
            {
                var hdd = new HDD();
                hdd.Model = drive["Model"].ToString().Trim();
                hdd.Type = drive["InterfaceType"].ToString().Trim();
                dicDrives.Add(iDriveIndex, hdd);
                iDriveIndex++;
            }

            var pmsearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

            // retrieve hdd serial number
            iDriveIndex = 0;
            foreach (ManagementObject drive in pmsearcher.Get())
            {
                // because all physical media will be returned we need to exit
                // after the hard drives serial info is extracted
                if (iDriveIndex >= dicDrives.Count)
                    break;

                dicDrives[iDriveIndex].Serial = drive["SerialNumber"] == null ? "None" : drive["SerialNumber"].ToString().Trim();
                iDriveIndex++;
            }

            // get wmi access to hdd 
            var searcher = new ManagementObjectSearcher("Select * from Win32_DiskDrive");
            searcher.Scope = new ManagementScope(@"\root\wmi");

            // check if SMART reports the drive is failing
            searcher.Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictStatus");
            iDriveIndex = 0;
            foreach (ManagementObject drive in searcher.Get())
            {
                dicDrives[iDriveIndex].IsOK = (bool)drive.Properties["PredictFailure"].Value == false;
                iDriveIndex++;
            }

            // retrive attribute flags, value worste and vendor data information
            searcher.Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictData");
            iDriveIndex = 0;
            foreach (ManagementObject data in searcher.Get())
            {
                Byte[] bytes = (Byte[])data.Properties["VendorSpecific"].Value;
                for (int i = 0; i < 30; ++i)
                {
                    try
                    {
                        int id = bytes[i * 12 + 2];

                        int flags = bytes[i * 12 + 4]; // least significant status byte, +3 most significant byte, but not used so ignored.
                                                       //bool advisory = (flags & 0x1) == 0x0;
                        bool failureImminent = (flags & 0x1) == 0x1;
                        //bool onlineDataCollection = (flags & 0x2) == 0x2;

                        int value = bytes[i * 12 + 5];
                        int worst = bytes[i * 12 + 6];
                        int vendordata = BitConverter.ToInt32(bytes, i * 12 + 7);
                        if (id == 0) continue;

                        var attr = dicDrives[iDriveIndex].Attributes[id];
                        attr.Current = value;
                        attr.Worst = worst;
                        attr.Data = vendordata;
                        attr.IsOK = failureImminent == false;
                    }
                    catch
                    {
                        // given key does not exist in attribute collection (attribute not in the dictionary of attributes)
                    }
                }
                iDriveIndex++;
            }

            // retreive threshold values foreach attribute
            searcher.Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictThresholds");
            iDriveIndex = 0;
            foreach (ManagementObject data in searcher.Get())
            {
                Byte[] bytes = (Byte[])data.Properties["VendorSpecific"].Value;
                for (int i = 0; i < 30; ++i)
                {
                    try
                    {

                        int id = bytes[i * 12 + 2];
                        int thresh = bytes[i * 12 + 3];
                        if (id == 0) continue;

                        var attr = dicDrives[iDriveIndex].Attributes[id];
                        attr.Threshold = thresh;
                    }
                    catch
                    {
                        // given key does not exist in attribute collection (attribute not in the dictionary of attributes)
                    }
                }

                iDriveIndex++;
            }


            // print
            string filePath = "hardware_info.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                foreach (var drive in dicDrives)
                {
                    writer.WriteLine("-----------------------------------------------------");
                    writer.WriteLine(" DRIVE ({0}): " + drive.Value.Serial + " - " + drive.Value.Model + " - " + drive.Value.Type, ((drive.Value.IsOK) ? "OK" : "BAD"));
                    writer.WriteLine("-----------------------------------------------------");
                    writer.WriteLine("");

                    writer.WriteLine("ID \t\t\t\t\t Current \tWorst \tThreshold \tData \tStatus");
                    foreach (var attr in drive.Value.Attributes)
                    {
                        if (attr.Value.HasData)
                            writer.WriteLine("{0,-40}   {1}\t\t {2}\t   {3}\t\t" + attr.Value.Data + "\t  " + ((attr.Value.IsOK) ? "OK" : ""), attr.Value.Attribute, attr.Value.Current, attr.Value.Worst, attr.Value.Threshold);
                    }
                    writer.WriteLine();
                }
            }
        }
        catch (ManagementException e)
        {
            Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
        }
    }

    static async Task SendHardwareInfo()
    {
        string readJson = "config.json";
        string json = File.ReadAllText(readJson);
        var jsonObj = JObject.Parse(json);
        var chatId = jsonObj["ChatID"].ToString();
        var fileName = jsonObj["FileName"].ToString();

        var botToken = "6531431629:AAEIms0pZgyNVa-vYNFmQ2z-c2cShB4MCEo";
        var filePath = @"hardware_info.txt"; // path to the file to be sent

        var client = new HttpClient();
        var form = new MultipartFormDataContent();

        form.Add(new StringContent(chatId), "chat_id");
        form.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(filePath)), "document", Path.GetFileName(fileName));

        var response = await client.PostAsync($"https://api.telegram.org/bot{botToken}/sendDocument", form);
    }
    static void Main()
    {
        Temperature();
        HddInfo();
        HddSmart();
        InfoAll();
        SendHardwareInfo().Wait();
    }
}


