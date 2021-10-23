using System;
using System.Management;
using System.Windows.Forms;
using Microsoft.Win32;
using ByteSizeLib;
namespace ALMITWV
{
    public partial class Form1 : Form
    {
        public string mbrd { get; }
        public string GfxCard { get; }
        public string Processor { get; }
        public string Ram { get; }
        public Form1()
        {
            InitializeComponent();
            
            Label.Text = "Hang on while we gather data about your system. If you see this text with your naked eye, it means that something is wrong";
            string CurrentVersionAlt = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";

            var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(CurrentVersionAlt, false);
            DateTime startDate = new DateTime(1970, 1, 1, 0, 0, 0);
            object objValue = key.GetValue("InstallDate");
            string stringValue = objValue.ToString();
            Int64 regVal = Convert.ToInt64(stringValue);
            DateTime instd = startDate.AddSeconds(regVal); //end copypaste
            string InstallDate = instd.ToString();

            string ReleaseId = (string)key.GetValue("ReleaseId");
            string ProductName = (string)key.GetValue("ProductName");
            string DisplayVersion = (string)key.GetValue("DisplayVersion");
            string EditionId = (string)key.GetValue("EditionId");
            string CurrentVersion = (string)key.GetValue("CurrentVersion");

            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject obj in myVideoObject.Get())
            {
                GfxCard = (string)obj["Name"];
            }
            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementObject obj in myProcessorObject.Get())
            {
                Processor = (string)obj["name"];
            }
            ManagementObjectSearcher myMotherboardObject = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
            foreach (ManagementObject obj in myMotherboardObject.Get())
            {
                mbrd = (string)obj["Model"];
            }
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject result in results)
            {
                Ram = result["TotalVisibleMemorySize"].ToString();
            }
            // now to text substitution
            Label.Text = null;
            label1.Text = ProductName.Replace(EditionId, null);
            label2.Text = "Edition ID: " + EditionId;
            label3.Text = "Version String: " + DisplayVersion + " (" + ReleaseId + ")";
            label4.Text = "Install Date: " + InstallDate;
            label5.Text = "Machine Name: " + Environment.MachineName;
            label6.Text = "Kernel Version: " + CurrentVersion;
            label12.Text = "CPU: " + Processor;
            label9.Text = "Graphics Card: " + GfxCard;
            label8.Text = "User: " + Environment.UserName;
            label11.Text = "Motherboard: " + mbrd;
            label13.Text = "RAM: " + Ram + " (This is in kilobytes)";

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/404oops/ALMITWV");
        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
