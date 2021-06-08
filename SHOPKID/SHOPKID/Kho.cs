using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dall_Ball;

namespace SHOPKID
{
    public partial class Kho : UserControl
    {
        KhoDaLL_BaLL kh = new KhoDaLL_BaLL();
        public Kho()
        {
            InitializeComponent();
        }
        public void load_kho(object sender, EventArgs e)
        {
            gridkho.DataSource = kh.load_kho();
        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
