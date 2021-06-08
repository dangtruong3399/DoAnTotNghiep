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

namespace SHOPKID
{
    public partial class TaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        TaiKhoan_Dall_BaLL tk = new TaiKhoan_Dall_BaLL();
        NhanVien_Dall_Ball nv = new NhanVien_Dall_Ball();
        bool add = false;
        public TaiKhoan()
        {
            InitializeComponent();
 
        }
        public void load_taikhoan(object sender, EventArgs e)
        {
            load_alluser();
            load_TKNV();
                databinds(true);
            hienthi(true);
            btnXoa.Enabled = true;
            btnThem.Enabled = true;

        }
        private void gridTaiKhoan_Click(object sender, EventArgs e)
        {

        }
        public void load_alluser()
        {
            gridTaiKhoan.DataSource = tk.getalltk();
        }
        public void load_TKNV()
        {
            cboNhanVien.Properties.DataSource = nv.loaddulieunhanvien();
            cboNhanVien.Properties.DisplayMember = "TenNV";
            cboNhanVien.Properties.ValueMember = "MaNV";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                btnThem.Enabled = false;
                txtTenTK.Text = "";
                txtMatKhau.Text = "";
                add = true;
                hienthi(false);
                btnXoa.Enabled = false;
                databinds(false);
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            
            
        }
        public void databinds(bool t)
        {
            if (t)
            {
                txtTenTK.DataBindings.Clear();
                txtTenTK.DataBindings.Add("Text", gridTaiKhoan.DataSource, "UserName");
                cboNhanVien.DataBindings.Clear();
                cboNhanVien.DataBindings.Add("Text", gridTaiKhoan.DataSource, "MaNV");
            }
            else
            {
                txtTenTK.DataBindings.Clear();
                cboNhanVien.DataBindings.Clear();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (add)
                {
                    tk.them1taikhoan(txtTenTK.Text, txtMatKhau.Text, cboNhanVien.EditValue.ToString());
                    XtraMessageBox.Show("Thêm thành công");
                    load_alluser();
                    databinds(true);
                    load_taikhoan(sender, e);
                return;
                }
        }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!!!!!");
            }

}

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa", "Đồng ý xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tk.xoa1taikhoan(txtTenTK.Text);
                    load_alluser();

                    databinds(true);
                    XtraMessageBox.Show("Thành Công");
                    add = false;

                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!!!!!!");
            }


            
           
        }

        private void checkBxHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxHienMK.Checked)
            {
                txtMatKhau.Properties.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.Properties.PasswordChar = '*';
            }
        }
        public void hienthi(bool t)
        {
            if (t)
            {

                txtTenTK.Enabled = false;
                txtMatKhau.Enabled = false;
                cboNhanVien.Enabled = false;
                

            }
            else
            {

                txtTenTK.Enabled = true;
                txtMatKhau.Enabled = true;
                cboNhanVien.Enabled = true;
              

            }
        }

        private void cboNhanVien_EditValueChanged(object sender, EventArgs e)
        {
            //XtraMessageBox.Show(cboNhanVien.EditValue.ToString());
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (!add)
            //{
            //    txtTenTK.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UserName").ToString();
            //    cboNhanVien.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenNV").ToString();
            //}
            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            load_taikhoan(sender, e);
        }
    }
    }
