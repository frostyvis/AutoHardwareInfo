using System.IO;
using System.Windows.Forms;
using AutoHardwareMonitorInfo;
using Newtonsoft.Json;

class HardwareInfo
{
    static void CreateFile()
    {
        string filePath = "config.json";
        if (File.Exists(filePath) == false)
        {
            var data = new
            {
                ChatID = "",
                FileName = "AutoHardwareInfo"
            };

            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }
    }
    static void Main()
    {
        CreateFile();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());

    }
}


