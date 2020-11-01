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
using CardCollectorData;

namespace CardCollector2
{
    public partial class Form1 : Form
    {
        private Form activeContent = null;
        private List<GenBlock> genBlocks = new List<GenBlock>();
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine(
            ConfigurationManager.AppSettings.Get("CS").ToString() + " " +
            ConfigurationManager.AppSettings.Get("DB").ToString() + " " +
            ConfigurationManager.AppSettings.Get("Table").ToString());

           
            GenBlock genBlock2 = new GenBlock(pnlMenu, this,2,8,15,"Gen 2");
            GenBlock genBlock = new GenBlock(pnlMenu, this,1,1,7,"Gen 1");
            
            genBlocks.Add(genBlock);
            genBlocks.Add(genBlock2);
            
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

        public void OpenCardPage(Set set)
        {
            lbSet.Text = set.ToString();
            OpenContent(new CardPage(set.ToString()));

        }

        public int closeOther(int num)
        {
            foreach (GenBlock item in genBlocks)
            {
                item.CloseSubPanel(num);
            }
            return 0;
        }
    }
}
