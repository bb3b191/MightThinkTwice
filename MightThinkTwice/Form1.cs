namespace MightThinkTwice
{

    using System;
    using System.Diagnostics;
    using System.ComponentModel;


    public partial class MightThinkTwice : Form
    {
        public MightThinkTwice()
        {
            InitializeComponent();
        }

        public string[,] Rules = { { "Program", "State", "Start", "End" } };

        private void MightThinkTwice_Load(object sender, EventArgs e)
        {
            //Load Installed Programs to ListBox
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (Microsoft.Win32.RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        lbxProgams.Items.Add(subkey.GetValue("DisplayName"));
                    }
                }
            }

            //Read Rules.txt and add to Rules array
            System.IO.StreamReader file = new System.IO.StreamReader("RulesList.txt");
            foreach (var line in file.ReadToEnd().Split('\n'))
            {
                Rules[lbxRules.Items.Count, 0] = line.Split(',')[0];
                Rules[lbxRules.Items.Count, 1] = line.Split(',')[1];
                Rules[lbxRules.Items.Count, 2] = line.Split(',')[2];
                Rules[lbxRules.Items.Count, 3] = line.Split(',')[3];
                lbxRules.Items.Add(line);
            }


            //Add Time to ListBox
            for (int i = 0; i < 24; i++)
            {
               lbxStartTime.Items.Add(i + ":00");
               lbxEndTime.Items.Add(i + ":00");
            }

        }

        private void MightThinkTwice_FormClosed(object sender, FormClosedEventArgs e)
        {
            const string sPath = "RulesList.txt";
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in lbxRules.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add Rule to ListBox
            lbxRules.Items.Add(lbxProgams.SelectedItem + "," + (rbtnUse.Checked ? "Use" : "Restrict") + "," + lbxStartTime.SelectedItem + "," + lbxEndTime.SelectedItem);
            // Add Rule to Rules Array
            Rules[lbxRules.Items.Count, 0] = lbxProgams.SelectedItem.ToString();
            Rules[lbxRules.Items.Count, 1] = (rbtnUse.Checked ? "Use" : "Restrict");
            Rules[lbxRules.Items.Count, 2] = lbxStartTime.SelectedItem.ToString();
            Rules[lbxRules.Items.Count, 3] = lbxEndTime.SelectedItem.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Delete Rule from ListBox
            lbxRules.Items.RemoveAt(lbxRules.SelectedIndex);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Every 5 seconds check if a rule is being violated
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 5000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(CheckRules);
            timer.Start();
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
                    if (DateTime.Now.Hour >= int.Parse(rule[2].Split(' ')[0]) && DateTime.Now.Hour <= int.Parse(rule[3].Split(' ')[0]))
                    {
                        if (Process.GetProcessesByName(rule[0].ToString()).Length == 0)
                        {
                            Process.Start(rule[0].ToString());
                        }
                    }
                }
                else
                {
                    if (DateTime.Now.Hour >= int.Parse(rule[2].Split(' ')[0]) && DateTime.Now.Hour <= int.Parse(rule[3].Split(' ')[0]))
                    {
                        if (Process.GetProcessesByName(rule[0].ToString()).Length > 0)
                        {
                            foreach (var process in Process.GetProcessesByName(rule[0].ToString()))
                            {
                                process.Kill();
                            }
                        }
                    }
                }
            }
        }
    }
}
