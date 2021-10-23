using System;
// using System.Collections.Generic;    Don't need them now
// using System.ComponentModel;         Don't need them now
// using System.Data;                   Don't need them now
// using System.Drawing;                Don't need them now
// using System.Linq;                   Don't need them now
// using System.Text;                   Don't need them now
// using System.Threading.Tasks;        Don't need them now
using System.Windows.Forms;
using Microsoft.Win32;

namespace ALMITWV
{
    public partial class Form1 : Form
    {
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

            // now to text substitution
            Label.Text = null;
            label1.Text = ProductName.Replace(EditionId, null);
            label2.Text = "Edition ID: " + EditionId;
            label3.Text = "Version String: " + DisplayVersion + " (" + ReleaseId + ")";
            label4.Text = "Install Date: " + InstallDate;
            label5.Text = "Machine Name: " + Environment.MachineName;
            label6.Text = "Kernel Version: " + CurrentVersion;
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
    }
}
