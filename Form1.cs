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
            } else
            {
                RegisteredOrganization = null;
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
                gbrak = (int.Parse(Ram) / 1048576);
            }
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            // now to text substitution
            Label.Text = null;
            productname.Text = ProductName.Replace(EditionId, null);
            editionid.Text = "Edition ID: " + EditionId;
            versionstring.Text = "Version String: " + DisplayVersion + " (" + ReleaseId + ")";
            instaldate.Text = "Install Date: " + InstallDate;
            machinename.Text = "Machine Name: " + Environment.MachineName;
            kernelversion.Text = "Kernel Version: " + CurrentVersion;
            cpu.Text = "CPU: " + Processor;
            gpu.Text = "Graphics Card: " + GfxCard;
            user.Text = "User: " + Environment.UserName;
            motherboard.Text = "Motherboard: " + mbrd;
            ram.Text = "RAM (GB): " + rak + "MB" + " ("gbrak + "GB")" ;
            regowner.Text = "Registered Owner: " + RegisteredOwner;
            if (RegisteredOrganization != "")
            {
                reg_org_or_res.Text = "Registered Organization: " + RegisteredOrganization;
                null_or_res.Text = "Resolution: " + screenWidth + "x" + screenHeight;
            } else {
                reg_org_or_res.Text = "Resolution: " + screenWidth + "x" + screenHeight;
            }
            clipboard = productname.Text + Environment.NewLine + string.Concat(Enumerable.Repeat("-", productname.Text.Length)) + Environment.NewLine + editionid.Text + Environment.NewLine + versionstring.Text + Environment.NewLine + instaldate.Text + Environment.NewLine + machinename.Text + Environment.NewLine + kernelversion.Text + Environment.NewLine + cpu.Text + Environment.NewLine + gpu.Text + Environment.NewLine + user.Text + Environment.NewLine + motherboard.Text + Environment.NewLine + ram.Text + Environment.NewLine + regowner.Text + Environment.NewLine + reg_org_or_res.Text + Environment.NewLine + null_or_res.Text;
            Console.WriteLine(clipboard);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
        
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/404oops/ALMITWV");
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
    }
}
