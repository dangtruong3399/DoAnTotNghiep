using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Dall_Ball;
using Dall_Ball.DTO;

namespace SHOPKID
{
    public partial class DoanhThu : DevExpress.XtraEditors.XtraUserControl
    {
        BanHang_Dall_Ball bh = new BanHang_Dall_Ball();
        List<DoanhThuDTO> lst = new List<DoanhThuDTO>();
        
        public DoanhThu()
        {
            InitializeComponent();
        }
        private void DoanhThu_Load(object sender, EventArgs e)
        {
           
        }

        private void btnThucThi_Click(object sender, EventArgs e)
        {
            gridDoanhThu.DataSource = bh.getDoanhthu(DateTime.Parse(dateNgayBD.EditValue.ToString()),
           DateTime.Parse(dateNgayKT.EditValue.ToString()));
            
            

        }
    }
}
