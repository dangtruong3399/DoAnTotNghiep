using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dall_Ball;
using DevExpress.XtraEditors;

namespace SHOPKID
{
    public partial class ChucVu : Form
    {
        public ChucVu()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.WindowState = FormWindowState.Minimized;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        ChucVu_Dall_Ball cv = new ChucVu_Dall_Ball();
        bool add = false, update = false;

        private void Chucvu_Load(object sender, EventArgs e)
        {
            hienthi(true);
          
            loadsachcv();
            bind(true);
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtMaCV.Enabled = false;


        }
        public void loadsachcv()
        {
            dsChucVu.DataSource = cv.loadcv();
        }

        public void hienthi(bool t)
        {
            if (t)
            {

                btnLuu.Enabled = false;
                txtTenCV.Enabled = false;
            
            }
            else
            {

                btnLuu.Enabled = true;
                txtTenCV.Enabled = true;
               
            }
        }

        public void bind(bool t)
        {
            if (t)
            {
                txtMaCV.DataBindings.Clear();
                txtMaCV.DataBindings.Add("Text", dsChucVu.DataSource, "MaCV");
                txtTenCV.DataBindings.Clear();
                txtTenCV.DataBindings.Add("Text", dsChucVu.DataSource, "TenCV");

            }
            else
            {
                txtMaCV.DataBindings.Clear();
                txtTenCV.DataBindings.Clear();

            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                resetvalues();
                hienthi(false);
                add = true;
                update = false;
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                if (gridView1.RowCount <= 0)
                {
                    txtMaCV.Text = "CV001";
                }
                else
                {
                    txtMaCV.Text = cv.getmachucvu();
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!");
            }
                
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                add = false;
                update = true;
                hienthi(false);

                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!");
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có muốn Xóa", "Đồng Ý Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cv.xoa1cv(txtMaCV.Text);
                    Chucvu_Load(sender, e);
                    XtraMessageBox.Show("Xóa Thành công");
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!");
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenCV.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Bạn phải nhập tên chức vụ");
                    return;
                }
                if (add)
                {


                    if (XtraMessageBox.Show("Bạn có muốn Lưu", "Đồng Ý Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cv.them1cv(txtMaCV.Text, txtTenCV.Text);

                        XtraMessageBox.Show("Thành công");
                        Chucvu_Load(sender, e);
                    }


                }
                if (update)
                {


                    if (XtraMessageBox.Show("Bạn có muốn Lưu", "Đồng Ý Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cv.sua1cv(txtMaCV.Text, txtTenCV.Text);

                        XtraMessageBox.Show("Thành Công");
                        Chucvu_Load(sender, e);
                    }

                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!");
            }
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Chucvu_Load(sender, e);
        }

        public void resetvalues()
        {
            
            txtMaCV.Text = "";
            txtTenCV.Text = "";
        }


    }
}
