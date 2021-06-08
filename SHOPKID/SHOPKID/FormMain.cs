using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuVien;
using Dall_Ball;
using DevExpress.XtraEditors;
namespace SHOPKID
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        List<DevExpress.XtraBars.BarButtonItem> listbutton = new List<DevExpress.XtraBars.BarButtonItem>();
        List<Quyen> listquyen = new List<Quyen>();
        PhanQuyen_DAl_Ball pq = new PhanQuyen_DAl_Ball();
        AddTab add = new AddTab();
        public Form1()
        {
            InitializeComponent();
     
        }
        public void skins()


        {
            DevExpress.LookAndFeel.DefaultLookAndFeel thems = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            thems.LookAndFeel.SkinName = "Valentine";

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
        private void InitListButton()
        {
            listbutton.Add(btnSanPham);
            listbutton.Add(btnLoaiSanPham);
            listbutton.Add(btnNhaCungCap);
            listbutton.Add(btnGiaoDien);
            listbutton.Add(btnBanHang);
            listbutton.Add(btnKhachHang);
            listbutton.Add(btnNhanVien);
            listbutton.Add(btnTK);
            listbutton.Add(btnPhanQuyen);
            listbutton.Add(btnBaoCaoDT);
            listbutton.Add(btnHoaDonBanHang);
            listbutton.Add(btnHoaDonNhapHang);
          
           
           // listbutton.Add(btnDangXuat);
            //listbutton.Add(btnPhanQuyen);
            for (int i = 0; i < listbutton.Count; i++)
                listbutton[i].Enabled = false;
  
        }

        private void setQuyen()
        {
            listquyen = pq.getAllQuyen(DangNhap.username);
            foreach (Quyen q in listquyen)
            {
                
                    for (int i = 0; i < listbutton.Count; i++)
                    {
                        if (listbutton[i].Name == q.DMform.TenBtn)
                            listbutton[i].Enabled = true;
                    }
                
            }
        }
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Sản Phẩm")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Sản Phẩm", new SanPham());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            skins();
            InitListButton();
            setQuyen();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Hóa Đơn Nhập Hàng")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Hóa Đơn Nhập Hàng", new NhapHang());
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Nhân Viên")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Nhân Viên", new NhanVien());
            }   

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Nhà Cung Cấp")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Nhà Cung Cấp", new NhaCungCap());
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Khách Hàng")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Khách Hàng", new KhachHang());
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Loại Sản Phẩm")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Loại Sản Phẩm", new LoaiSanPham());
            }
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            xtraTabControl1.TabPages.RemoveAt(xtraTabControl1.SelectedTabPageIndex);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Bán Hàng")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Bán Hàng", new BanHang());
            }
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Hóa Đơn Bán Hàng")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Hóa Đơn Bán Hàng", new HoaDonBanHang());
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Phân Quyền")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Phân Quyền", new PhanQuyen());
            }
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Kho")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Kho", new Kho());
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Tài Khoản")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Tài Khoản", new TaiKhoan());
            }
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult rs;
            rs = XtraMessageBox.Show("Bạn có muốn đăng xuất ", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (rs != DialogResult.Yes)
            {
                return;

            }
            Hide();
            DangNhap frm = new DangNhap();
            frm.ShowDialog();
            Close();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Báo Cáo Doanh Thu")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Báo Cáo Doanh Thu", new DoanhThu());
            }
        }

        private void barButtonItem1_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Đổi Mật Khẩu")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {
                return;
            }
            else
            {
                add.AddTabControl(xtraTabControl1, "", "Đổi Mật Khẩu", new DoiMKhau());
            }
        }
    }
}
