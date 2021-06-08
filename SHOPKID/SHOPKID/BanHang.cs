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
using DevExpress.XtraGrid.Views.Grid;
using SHOPKID.Report;

namespace SHOPKID
{
    public partial class BanHang : DevExpress.XtraEditors.XtraUserControl
    {
        BanHang_Dall_Ball bh = new BanHang_Dall_Ball();
        SanPham_Dall_Ball sp = new SanPham_Dall_Ball();
        KhachHang_Dall_Ball kh = new KhachHang_Dall_Ball();
        List<HoaDonBHDT> lst = new List<HoaDonBHDT>();
        long tongtien = 0;
        List<SanPhamDTO> sp1 = new List<SanPhamDTO>();
        bool add1 = false;
       
        
        
        public BanHang()
        {
            InitializeComponent();
           
        }

       
        public void BanHang_Load(object sender, EventArgs e)
        {

            txtTenNV.Enabled = false;
            load_spbhall();
            Load_CbSp();
            loadSreachKh();
        }
        public void load_spbhall()
        {
            gridBH_SP.DataSource = sp.GetSpAll();
        }
        public void Load_SpBH()
        {

           
            gridBH_SP.DataSource = sp1;
        }

        public void Load_CbSp()
        {
            SearchLUSanPham.Properties.DataSource = bh.loadsp();
            SearchLUSanPham.Properties.DisplayMember = "TenSP";
            SearchLUSanPham.Properties.ValueMember = "MaSP";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {   if(add1)
                {
                    return;
                }
                if(txtMaHD.Text.Length>0)
                {
                   
                    FuncitonBanHang tt = new FuncitonBanHang();
                    int soluong = int.Parse(spinSoLuong.Text);
                    long dongia =tt.GetGiaspTheoMa(SearchLUSanPham.EditValue.ToString());
                    long thanhtien =tt.GetThanhTien(soluong,dongia);
                    string masp = SearchLUSanPham.EditValue.ToString();
               
                    HoaDonBHDT dt = new HoaDonBHDT();
                    dt.MaSP1 = masp;
                    dt.Tensp = SearchLUSanPham.Text;
                    dt.SoLuong1 = soluong;
                    dt.Dongia = dongia;
                    dt.Thanhtien = thanhtien;
                    int s = 1;
                    if (lst.Count == 0)
                    {
                        s = 1;
                    }
                    else
                    {
                        for (int i = 0; i < lst.Count; i++)
                        {
                            if ( masp== lst[i].MaSP1)
                            {
                                s++;
                            }
                        }
                    }
                    if (s == 1)
                    {
                        if (int.Parse(spinSoLuong.Text) <= 0)
                        {
                             XtraMessageBox.Show("Số lượng phải lớn hơn 0");
                            return;
                        }
                        tongtien += thanhtien;
                        lst.Add(dt);   
                        loadtam();
                        updateSoluong();

                    }
                }
                txtTongTien.Text = tongtien.ToString();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!");
            }
        }
        
        public void loadtam()
        {
            gridSPDChon.DataSource = "";
            gridSPDChon.DataSource = lst;
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            try
            {
                dateNgayHD.DateTime = DateTime.Now;
                dateNgayHD.Enabled = true;
                txtMaHD.Text = bh.getMahdauto();
                txtTenNV.Text = DangNhap.tennv;
                spinSoLuong.Value = 0;
                txtTongTien.Text = "";
                gridSPDChon.DataSource = null;
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!");
            }

            
        }
        public void loadSreachKh()
        {
            SreachKh.Properties.DataSource = kh.getdskhachhang();
            SreachKh.Properties.DisplayMember = "TenKH";
            SreachKh.Properties.ValueMember = "MaKH";
        }

        private void SearchLUSanPham_EditValueChanged(object sender, EventArgs e)
        {
            // FuncitonBanHang tt = new FuncitonBanHang();
            //MessageBox.Show();
            spinSoLuong.Value = 0;
        }

        private void Column_btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewBH_SP.RowCount <= 0)
                {
                    txtTongTien.Text = "";
                    return;
                }
                else
                {
                    //var gv = gridSPDChon.MainView as GridView;
                    //var index = gv.FocusedRowHandle;
                    string masp = gridViewSPDChon.GetRowCellValue(gridViewSPDChon.FocusedRowHandle, "MaSP1").ToString();
                    var index = lst.FindIndex(t => t.MaSP1 == masp);
                    tongtien = tongtien - lst[index].Thanhtien;
                    txtTongTien.Text = tongtien.ToString();
                    lst.RemoveAt(index);
                    loadtam();
                    DeleteSoluong();
                    return;
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!");
            }

            
        }

        private void gridSPDChon_Click(object sender, EventArgs e)
        {

        }

        //private void spinGiamPhanTram_EditValueChanged(object sender, EventArgs e)
        //{
          
        //        if (int.Parse(spinGiamPhanTram.Text) > 0)
        //           txtGiamGiaVND.Text = (tongtien * (int.Parse(spinGiamPhanTram.Text)/100)).ToString();
            
        //}
        public void updateSoluong()
        {
            sp1 = sp.GetSpAll();
            for (int i=0;i<sp1.Count;i++)
            {
                for(int j=0;j<lst.Count;j++)
                {
                    if(sp1[i].MaSp1==lst[j].MaSP1)
                    {
                        sp1[i].SoluongTon1-= lst[j].SoLuong1;
                    }
                }
            }
            Load_SpBH();
        }
        public void DeleteSoluong()
        {
            sp1 = sp.GetSpAll();
            for (int i = 0; i < sp1.Count; i++)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    if (sp1[i].MaSp1 == lst[j].MaSP1)
                    {
                        sp1[i].SoluongTon1 += lst[j].SoLuong1;
                    }
                }
            }
            Load_SpBH();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {

            
                string manv = DangNhap.matennv;
                if (SreachKh.Text == "[EditValue is null]")
                {
                    XtraMessageBox.Show("Bạn chưa chọn khách hàng mua sản phẩm");
                    return;
                }
                if (bh.kiemtrahoadon(txtMaHD.Text))
                {
                    XtraMessageBox.Show("Đã Tồn Tại Hóa Đơn Này");
                    return;
                }
                bh.AddHoaDonBH(txtMaHD.Text, DateTime.Parse(dateNgayHD.EditValue.ToString()), true, long.Parse(txtTongTien.Text), manv, SreachKh.EditValue.ToString());

                for (int i = 0; i < lst.Count; i++)
                {
                    bh.AddChitietHDBH(txtMaHD.Text, lst[i].Thanhtien, lst[i].MaSP1, lst[i].SoLuong1, lst[i].Dongia);
                }
                lst.Clear();
                tongtien = 0;
                
                load_spbhall();


                List<KhachHang> t = new List<KhachHang>();
                XtraMessageBox.Show("Thanh Toán Thành Công");
                HoaDonBanHangRpt rpt = new HoaDonBanHangRpt();
                rpt.show(txtMaHD.Text);
                
               
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            gridSPDChon.DataSource = null;
            txtTongTien.Text = "";
        }

        private void spinSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int soluongchon = int.Parse(spinSoLuong.Value.ToString());
                if (soluongchon > sp.getsoluongtheosp(SearchLUSanPham.EditValue.ToString()))
                {
                    add1 = true;
                    XtraMessageBox.Show("Số lượng bán ra lớn hơn số lượng tồn kho");
                    return;

                }
                else
                {
                    add1 = false;
                    return;
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("FBI WARNING!!!!!!!!!!!!!!!!!!!!");
            }
            
        }
    }
}
