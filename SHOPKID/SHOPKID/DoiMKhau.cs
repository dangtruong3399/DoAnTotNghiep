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
    public partial class DoiMKhau : DevExpress.XtraEditors.XtraUserControl
    {
        TaiKhoan_Dall_BaLL taikhoan = new TaiKhoan_Dall_BaLL();
        TaiKhoanDTO tk = new TaiKhoanDTO();
        public DoiMKhau()
        {
            InitializeComponent();
        }
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMKCu.Properties.PasswordChar = '*';
            txtMKMoi.Properties.PasswordChar = '*';
            txtNhapLaiMK.Properties.PasswordChar = '*';
            labelTenTaiKhoan.Text = DangNhap.tennv;
            txtMKCu.Text = "";
            txtMKMoi.Text = "";
            txtNhapLaiMK.Text = "";
            
        }
        private bool KTMatKhau()//kiểm tra độ dài mật khẩu, xứ lý khi nhấn nút thêm
        {
            if (txtMKMoi.Text.Length <= 7 || txtMKMoi.Text.Length >= 15)
                return false;
            return true;
        }
        private bool KTDongNhatMK()// kiểm tra nhập lại mật khẩu có đúng hay ko
        {
            if (txtMKMoi.Text != txtNhapLaiMK.Text)
                return false;
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtMKCu.Text == "" || txtMKMoi.Text == "" || txtNhapLaiMK.Text == "")
                XtraMessageBox.Show("Chưa nhập mật khẩu");
            else if (txtMKMoi.Text == "")
                XtraMessageBox.Show("Chưa nhập mật khẩu mới");
            else if (txtNhapLaiMK.Text == "")
                XtraMessageBox.Show("Chưa nhập lại mật khẩu mới");
            else
            {
                if (KTMatKhau() == false)
                    XtraMessageBox.Show("Độ dài mật khẩu phải từ 8 đến 16 ký tự");
                else if (KTDongNhatMK() == false)
                    XtraMessageBox.Show("Mật khẩu mới và mật khẩu nhập lại");
                else
                {
                    tk.UserName = DangNhap.username;
                    tk.Password = txtMKMoi.Text;
                    if (taikhoan.sua1taikhoan(tk, txtMKCu.Text))
                    {
                        XtraMessageBox.Show("Đổi mật khẩu thành công");
                    }
                    else
                    {
                        XtraMessageBox.Show("Đổi mật khẩu thất bại");

                    }
                }
            }
        }

        private void checkMKCu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMKCu.Checked)
            {
                txtMKCu.Properties.PasswordChar = '\0';
            }
            else
            {
                txtMKCu.Properties.PasswordChar = '*';
            }
        }

        private void checkMKMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMKMoi.Checked)
            {
                txtMKMoi.Properties.PasswordChar = '\0';
            }
            else
            {
                txtMKMoi.Properties.PasswordChar = '*';
            }
        }

        private void checkMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMK.Checked)
            {
                txtNhapLaiMK.Properties.PasswordChar = '\0';
            }
            else
            {
                txtNhapLaiMK.Properties.PasswordChar = '*';
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau_Load(sender,e);
        }
    }
}
