using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using Microsoft.Win32.TaskScheduler;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace AutoHardwareMonitorInfo
{
    public partial class Form1 : Form
    {
        string ConfigFile = "config.json";
        string TgUsername = "";
        short TsDays = 30;
        short TsHours = 12;
        string SendFileName = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            TgUsername = textBoxUsername.Text;
        }
        private async void btnSaveUsername_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            string botToken = "botToken";
            string chatID = "";

            HttpResponseMessage response = await client.GetAsync($"https://api.telegram.org/bot{botToken}/getUpdates");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic updates = JsonConvert.DeserializeObject(json);

                foreach (var result in updates["result"])
                {
                    if (result["message"]["from"]["username"] != null && (string)result["message"]["from"]["username"] == TgUsername)
                    {
                        chatID = (string)result["message"]["chat"]["id"];
                    }
                }
            }
            else
            {
                MessageBox.Show($"Error: {response.StatusCode}");
            }
            if (chatID != "")
            {
                string json = File.ReadAllText(ConfigFile);
                dynamic person = JsonConvert.DeserializeObject(json);

                person.ChatID = chatID;

                string updatedJson = JsonConvert.SerializeObject(person);

                File.WriteAllText(ConfigFile, updatedJson);

                MessageBox.Show("Username saved successfully");
            }
            else
            {
                MessageBox.Show($"Error! Check the spelling of the username and write to the bot again.");
            }
        }
        private void numericUpDownDays_ValueChanged(object sender, EventArgs e)
        {
            TsDays = (short)numericUpDownDays.Value;
        } 
        private void numericUpDownHours_ValueChanged(object sender, EventArgs e)
        {
            TsHours = (short)numericUpDownHours.Value;
        }

        private void btnIntervalDays_Click(object sender, EventArgs e)
        {

            using (TaskService taskService = new TaskService())
            {
                TaskDefinition taskDefinition = taskService.NewTask();

                DailyTrigger trigger = new DailyTrigger();
                trigger.StartBoundary = DateTime.Today + TimeSpan.FromHours(TsHours); // Start time
                trigger.DaysInterval = TsDays; // Interval in days between starts

                taskDefinition.Settings.StartWhenAvailable = true; // Run the task immediately if a scheduled start is missed
                taskDefinition.Triggers.Add(trigger);

                taskDefinition.Actions.Add(new ExecAction(@"ProgramAHITG.exe"));

                taskService.RootFolder.RegisterTaskDefinition("AutoHardwareInfo", taskDefinition);
                MessageBox.Show("Task \"AutoHardwareInfo\" added");
            }

        }

        private void btnDeleteIntervalDays_Click(object sender, EventArgs e)
        {
            using (TaskService taskService = new TaskService())
            {
                Task task = taskService.FindTask("AutoHardwareInfo");

                if (task != null)
                {
                    taskService.RootFolder.DeleteTask("AutoHardwareInfo");
                    MessageBox.Show($"Task AutoHardwareInfo successfully deleted.");
                }
                else
                {
                    MessageBox.Show($"Task AutoHardwareInfo not found.");
                }
            }
        }

        private void textBoxFileName_TextChanged(object sender, EventArgs e)
        {
            SendFileName = textBoxFileName.Text;
        }

        private void btnFileName_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText(ConfigFile);
            dynamic person = JsonConvert.DeserializeObject(json); 

            person.FileName = SendFileName;

            string updatedJson = JsonConvert.SerializeObject(person);

            File.WriteAllText(ConfigFile, updatedJson);

            MessageBox.Show($"The filename sent will be called: {SendFileName}");
        }

        private void btnSendTest_Click(object sender, EventArgs e)
        {
            string chatID = JObject.Parse(File.ReadAllText(ConfigFile))["ChatID"].ToString();

            if (chatID == "")
            {
                MessageBox.Show("ERROR! Enter Username Telegram");
            }
            else
            {
                ProcessStartInfo SendTest = new ProcessStartInfo
                {
                    FileName = @"ProgramAHITG.exe",
                    Verb = "runas"
                };
                try
                {
                    var process = Process.Start(SendTest);
                    process.WaitForExit();
                    MessageBox.Show("File sent. Check Telegram.");
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show("Launch cancelled by user");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            
        }
    }
}
