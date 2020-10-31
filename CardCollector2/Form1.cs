using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace CardCollector2
{
    public partial class Form1 : Form
    {
        private Form activeContent = null;
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine(
            ConfigurationManager.AppSettings.Get("CS").ToString() + " " +
            ConfigurationManager.AppSettings.Get("DB").ToString() + " " +
            ConfigurationManager.AppSettings.Get("Table").ToString());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void OpenContent(Form child)
        {
            if (activeContent != null) activeContent.Close();
            activeContent = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(child);
            pnlContent.Tag = child;
            child.Show();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            OpenContent(new SettingsForm());
        }

        private void btnPageTest_Click(object sender, EventArgs e)
        {
            OpenContent(new CardPage("Hello Page"));
        }
    }
}
