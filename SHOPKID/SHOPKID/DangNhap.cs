using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Dall_Ball;

namespace SHOPKID
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {

       
        FunctionDangNhap dn = new FunctionDangNhap();
        public static string tennv = "";
             public static string matennv = "";
        public static string username = "";
        public DangNhap()
        {
            InitializeComponent();
        }

        private void checkBxHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxHienMK.Checked)
            {
                txtMK.Properties.PasswordChar = '\0';
            }
            else
            {
                txtMK.Properties.PasswordChar = '*';
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (dn.CheckLogin(txtTenDangNhap.Text, txtMK.Text))
                {
                    Form1 frm = new Form1();
                    tennv = dn.GetUserToMaNV(txtTenDangNhap.Text);
                    matennv = dn.GetUserMaToMaNV(txtTenDangNhap.Text);
                    username = txtTenDangNhap.Text;
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();

                }
                else
                {
                    XtraMessageBox.Show("Tài khoản hoặc mật khẩu sai");
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!");
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}