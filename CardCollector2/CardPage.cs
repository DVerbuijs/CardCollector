using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardCollector2
{
    public partial class CardPage : Form
    {
        public CardPage(string msg)
        {
            InitializeComponent();
            Console.WriteLine(msg);
        }
    }
}
