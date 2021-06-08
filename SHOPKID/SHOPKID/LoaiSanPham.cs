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
    public partial class LoaiSanPham : DevExpress.XtraEditors.XtraUserControl
    {
        bool add, update;
        LoaiSanPham_Dall_Ball lsp = new LoaiSanPham_Dall_Ball();

        public LoaiSanPham()
        {
            InitializeComponent();
        }

        public void LoaiSanPham_Load(object sender,EventArgs e)
        {

            hienthi(false);
            xemloaiSP();
            txtMaLoaiSP.Enabled = false;
            bind(true);
            BtnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();
        }
        public void hienthi(bool t)
        {

            txtTenLoaiSP.Enabled = t;


        }

        public void bind(bool t)
        {
            if (t)
            {
                txtMaLoaiSP.DataBindings.Clear();
                txtMaLoaiSP.DataBindings.Add("Text", dsloaisp.DataSource, "MaLoai");
                txtTenLoaiSP.DataBindings.Clear();
                txtTenLoaiSP.DataBindings.Add("Text", dsloaisp.DataSource, "TenLoai");

                //    ckTranThai.DataBindings.Add("Text", dsLoaihang.DataSource, "inhTrangHang");
            }
            else
            {
                txtMaLoaiSP.DataBindings.Clear();
                txtTenLoaiSP.DataBindings.Clear();

            }


        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenLoaiSP.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên loại sản phẩm");
                    return;
                }

                if (add)
                {

                    if (XtraMessageBox.Show("Bạn có muốn Thêm Loại Sản Phẩm Mới", "Đồng Ý Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        lsp.them1loaisanpham(txtMaLoaiSP.Text, txtTenLoaiSP.Text);

                        XtraMessageBox.Show("Thêm Thành Công");
                        LoaiSanPham_Load(sender, e);
                    }

                }
                if (update)
                {
                    if (XtraMessageBox.Show("Bạn có muốn Sửa Loại Sản Phẩm Này", "Đồng Ý Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool kq = lsp.sua1loaisanpham(txtMaLoaiSP.Text, txtTenLoaiSP.Text);

                        if (kq)
                        {
                            XtraMessageBox.Show("Sửa Thành Công");
                            LoaiSanPham_Load(sender, e);
                        }
                    }

                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                add = true;
                update = false;
                // txtMaLH.Enabled = true;
                txtMaLoaiSP.Text = "";

                txtTenLoaiSP.Text = "";
                btnSua.Enabled = false;
                BtnLuu.Enabled = true;
                btnXoa.Enabled = false;
                btnThem.Enabled = false;

                hienthi(true);
                bind(false);

                if (gridView1.RowCount <= 0)
                {
                    txtMaLoaiSP.Text = "LH001";
                }
                else
                {
                    txtMaLoaiSP.Text = lsp.getmaloaisp("LH00");
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!");
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                update = true;
                add = false;
                hienthi(true);
                btnThem.Enabled = false;
                BtnLuu.Enabled = true;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                bind(false);
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!");
            }
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoaiSanPham_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount <= 0)
                {
                    XtraMessageBox.Show("Không có loại hàng để xóa");
                    return;
                }
                lsp.xoasanphamtheoloai(txtMaLoaiSP.Text);
                if (lsp.xoa1loaisanpham(txtMaLoaiSP.Text))
                {
                    XtraMessageBox.Show("Thành Công");
                    LoaiSanPham_Load(sender, e);
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!");
            }
            
        }


        public void load_visbile(object sender, EventArgs e)
        {
            LoaiSanPham_Load(sender, e);
        }
        public void xemloaiSP()
        {

            List<Dall_Ball.LoaiSanPham> lst = new List<Dall_Ball.LoaiSanPham>();
            lst = lsp.loaddulieuloaisanpham();
            dsloaisp.DataSource = lst;

        }
    }
}
