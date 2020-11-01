using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows;
using CardCollectorData;


namespace CardCollector2
{
    
    public class GenBlock
    {
        private Button btnGen;
        private Button btnSet;
        private Panel subPanel;
        private Panel container;
        private int setsCol =0;
        private Form1 form1;
        private int id;

        public GenBlock(Panel parent, Form1 form1, int ID, int firstSet, int endSet, string gen)
        {
            this.form1 = form1;
            id = ID;
            
          
            

            container = new Panel();
            container.Dock = DockStyle.Top;
            container.Height = 1 * 40;
            parent.Controls.Add(container);

            subPanel = new Panel();
            subPanel.Dock = DockStyle.Fill;
            subPanel.Visible = false;
            
            container.Controls.Add(subPanel);
            for (int i = endSet; i > firstSet - 1; i--)
            {
                Set name = (Set)i;
                CreateSetButton(name);
                setsCol++;

            }



            btnGen = new Button();
            btnGen.Text = gen;
            btnGen.Dock = DockStyle.Top;
            btnGen.Height = 40;
            btnGen.Margin = new Padding(0, 0, 0, 5);
            btnGen.BackColor = Color.FromArgb(37, 46, 59);
            btnGen.ForeColor = Color.White;
            btnGen.TextAlign = ContentAlignment.MiddleLeft;
            btnGen.FlatStyle = FlatStyle.Flat;
           
            btnGen.FlatAppearance.BorderSize = 0;
            btnGen.Click += BtnGen_Click;
            container.Controls.Add(btnGen);
        }

        private void CreateSetButton(Set set)
        {
            btnSet = new Button();
            btnSet.Tag=set;
            btnSet.Text = set.ToString();
            btnSet.Dock = DockStyle.Top;
            btnSet.Height = 40;
            btnSet.BackColor = Color.Yellow;
            btnSet.TextAlign = ContentAlignment.MiddleLeft;
            btnSet.FlatStyle = FlatStyle.Flat;
            btnSet.Click += BtnSet_Click;
            subPanel.Controls.Add(btnSet);
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            form1.OpenCardPage((Set)b.Tag);
           
        }

        private void BtnGen_Click(object sender, EventArgs e)
        {
            form1.closeOther(id);
           
        }
        public void CloseSubPanel(int ID)
        {
            if (!subPanel.Visible&& ID==id)
            {
                container.Height = (setsCol + 1) * 40;
                subPanel.Visible = true;
            }
            else
            {
                subPanel.Visible = false;
                container.Height = 1 * 40;
            }
        }
    }
}
