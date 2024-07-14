namespace MightThinkTwice
{

    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    using Microsoft.Win32;
    using System.Windows.Forms;
    using System.Formats.Asn1;
    using System.Globalization;
    using static System.Runtime.InteropServices.JavaScript.JSType;
    using System.Media;

    public partial class MightThinkTwice : Form
    {
        public MightThinkTwice()
        {
            InitializeComponent();
        }

        public string[][] Rules;
        System.Timers.Timer timer = new System.Timers.Timer();


        private void MightThinkTwice_Load(object sender, EventArgs e)
        {
            //Load Installed Programs to ListBox
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        if (subkey.GetValue("DisplayName") != null)
                        {
                            lbxProgams.Items.Add(subkey.GetValue("DisplayName"));
                        }
                    }
                }
            }

            Rules = new string[1][];
            Rules[0] = new string[4];
            Rules[0] = ["Program", "State", "Start Time", "End Time"];
            //Read Rules.txt and add to Rules array
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            System.IO.StreamReader file = new System.IO.StreamReader(dir + @"\RulesList.txt");
            if (file.ReadLine() != null)
            {
                //string[] test = file.ReadAllText().Split('\n');
                string[] test = File.ReadAllLines(dir + @"\RulesList.txt");
                

                //foreach (var line in file.ReadToEnd().Split('\n'))
                foreach (var line in test)
                {
                    Rules[lbxRules.Items.Count][0] = line.Split(',')[0];
                    Rules[lbxRules.Items.Count][1] = line.Split(',')[1];
                    Rules[lbxRules.Items.Count][2] = line.Split(',')[2];
                    Rules[lbxRules.Items.Count][3] = line.Split(',')[3];
                    lbxRules.Items.Add(line);

                    if (test.Length > Rules.GetLength(0))
                    {
                        string[][] b = new string[Rules.GetLength(0) + 1][];
                        for (int i = 0; i < Rules.Length; i++)
                        {
                            b[i] = Rules[i];
                        }
                        b[b.Length - 1] = new string[4];
                        Rules = b;
                    }
                    
                }
            }
            file.Close();
            lbxRules.Sorted = true;


            //Add Time to ListBox
            for (int i = 0; i < 24; i++)
            {
                lbxStartTime.Items.Add(i + ":00");
                lbxEndTime.Items.Add(i + ":00");
            }

        }

        private void MightThinkTwice_FormClosed(object sender, FormClosedEventArgs e)
        {
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(dir + @"\RulesList.txt");
            //const string sPath = "RulesList.txt";
            //System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in lbxRules.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
            SaveFile.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add Rule to ListBox
            lbxRules.Items.Add(lbxProgams.SelectedItem + "," + (rbtnUse.Checked ? "Use" : "Restrict") + "," + lbxStartTime.SelectedItem + "," + lbxEndTime.SelectedItem);
            // Add Rule to Rules Array
            string[][] b = new string[Rules.GetLength(0) + 1][];
            for (int i = 0; i < Rules.Length; i++)
            {
                b[i] = Rules[i];
            }
            b[b.Length - 1] = new string[4];
            Rules = b;
            Rules[lbxRules.Items.Count][0] = lbxProgams.SelectedItem.ToString();
            Rules[lbxRules.Items.Count][1] = (rbtnUse.Checked ? "Use" : "Restrict");
            Rules[lbxRules.Items.Count][2] = lbxStartTime.SelectedItem.ToString();
            Rules[lbxRules.Items.Count][3] = lbxEndTime.SelectedItem.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Delete Rule from ListBox            
            int j = 0;
            string[][] b = new string[Rules.GetLength(0) - 1][];
            for (int i = 0; i < Rules.Length; i++)
            {
                if (i == lbxRules.SelectedIndex + 1)
                {
                    j = -1;
                    continue;
                }
                else
                {
                    b[i - j] = Rules[i];
                }
            }
            Rules = b;
            lbxRules.Items.RemoveAt(lbxRules.SelectedIndex);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Every 5 seconds check if a rule is being violated
            
            timer.Interval = 5000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(CheckRules);
            timer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void CheckRules(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Check if a rule is being violated
            foreach (var rule in Rules)
            {
                if (rule[0].ToString() == "Program")
                {
                    continue;
                }
                if (rule[1].ToString() == "Use")
                {
                    if (DateTime.Now.Hour >= int.Parse(rule[2].ToString().Split(':')[0]) && DateTime.Now.Hour <= int.Parse(rule[3].ToString().Split(':')[0]))
                    {
                        //Get process name from rule and check if it is running
                        string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
                        {
                            foreach (string subkey_name in key.GetSubKeyNames())
                            {
                                using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                                {
                                    if (subkey.GetValue("DisplayName") != null)
                                    {
                                        if (subkey.GetValue("DisplayName").ToString() == rule[0])
                                        {
                                            string processexe = subkey.GetValue("DisplayIcon").ToString().Split("\\").Last();
                                            var allProcesses = Process.GetProcesses();

                                            if (Process.GetProcessesByName(processexe.Substring(0, processexe.Length - 4)).Length == 0)
                                            {
                                                Process.Start(subkey.GetValue("DisplayIcon").ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (DateTime.Now.Hour >= int.Parse(rule[2].ToString().Split(':')[0]) && DateTime.Now.Hour <= int.Parse(rule[3].ToString().Split(':')[0]))
                    {
                        //Get process name from rule and check if it is running
                        string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
                        {
                            foreach (string subkey_name in key.GetSubKeyNames())
                            {
                                using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                                {
                                    if (subkey.GetValue("DisplayName") != null)
                                    {
                                        if (subkey.GetValue("DisplayName").ToString() == rule[0])
                                        {
                                            string processexe = subkey.GetValue("DisplayIcon").ToString().Split("\\").Last();
                                            var allProcesses = Process.GetProcesses();

                                            if (Process.GetProcessesByName(processexe.Substring(0, processexe.Length - 4)).Length != 0)
                                            {
                                                foreach (var process in Process.GetProcessesByName(processexe.Substring(0, processexe.Length - 4)))
                                                {
                                                    playQuitSound();
                                                    process.Kill();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void playQuitSound()
        {
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            SoundPlayer simpleSound = new SoundPlayer(dir + @"\huh-cat.mp3");
            simpleSound.Play();
        }
    }
}
