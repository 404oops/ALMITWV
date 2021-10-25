using System;
using System.Management;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Linq;
using System.Threading.Tasks;

namespace ALMITWV
{
    public partial class Form1 : Form
    {
        public string mbrd { get; }
        public string GfxCard { get; }
        public string Processor { get; }
        public string Ram { get; }
        public int rak { get; }
        public string RegisteredOwner;
        public string RegisteredOrganization;
        public string clipboard;
        public Form1()
        
        {
            InitializeComponent();
            button1.Text = "Copy to Clipboard";
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
            string RegisteredOwner = (string)key.GetValue("RegisteredOwner");
            if ((string)key.GetValue("RegisteredOrganization") != null)
            {
                RegisteredOrganization = (string)key.GetValue("RegisteredOrganization");
            }
            

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
                rak = (int.Parse(Ram) / 1024);
            }
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
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
            label15.Text = "RAM: " + rak + "MB";
            label14.Text = "Registered Owner: " + RegisteredOwner;
            label10.Text = "Resolution: " + screenWidth + "x" + screenHeight;
            if (RegisteredOrganization != "")
            {
                label7.Text = "Registered Organization: " + RegisteredOrganization;
            } else
            {
                label7.Text = null;
            }
            // // printing for cli (i don't see the use for this but eh, idc, here it is:
            // Console.WriteLine(label1.Text);
            // Console.WriteLine(string.Concat(Enumerable.Repeat("-", label1.Text.Length)));
            // Console.WriteLine(label2.Text);
            // Console.WriteLine(label3.Text);
            // Console.WriteLine(label4.Text);
            // Console.WriteLine(label5.Text);
            // Console.WriteLine(label6.Text);
            // Console.WriteLine(label12.Text);
            // Console.WriteLine(label9.Text);
            // Console.WriteLine(label8.Text);
            // Console.WriteLine(label11.Text);
            // Console.WriteLine(label15.Text);
            // Console.WriteLine(label14.Text);
            // Console.WriteLine(label7.Text);

            clipboard = label1.Text + Environment.NewLine + string.Concat(Enumerable.Repeat("-", label1.Text.Length)) + Environment.NewLine + label2.Text + Environment.NewLine + label3.Text + Environment.NewLine + label4.Text + Environment.NewLine + label5.Text + Environment.NewLine + label6.Text + Environment.NewLine + label12.Text + Environment.NewLine + label9.Text + Environment.NewLine + label8.Text + Environment.NewLine + label11.Text + Environment.NewLine + label15.Text + Environment.NewLine + label14.Text + Environment.NewLine + label7.Text + Environment.NewLine + label10.Text;
            Console.WriteLine(clipboard);

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

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            Clipboard.SetText(clipboard);
            button1.Text = "Copied!";
            await Task.Delay(millisecondsDelay: 1000);
            button1.Text = "Copy to Clipboard";
        }
        public static Task Delay(int milliseconds)
        {
            var tcs = new TaskCompletionSource<bool>();
            var timer = new System.Threading.Timer(o => tcs.SetResult(false));
            timer.Change(milliseconds, -1);
            return tcs.Task;
        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }
    }
}
