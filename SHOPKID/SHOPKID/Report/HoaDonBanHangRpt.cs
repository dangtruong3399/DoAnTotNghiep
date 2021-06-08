using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SHOPKID.Report.Object;
using System.Collections.Generic;
using Dall_Ball;

namespace SHOPKID.Report
{
    public partial class HoaDonBanHangRpt : DevExpress.XtraReports.UI.XtraReport
    {
        Chitiethoadonbanhang tt = new Chitiethoadonbanhang();
        BanHang_Dall_Ball bh = new BanHang_Dall_Ball();
        public HoaDonBanHangRpt()
        {
            InitializeComponent();
            
            
        }
        public void show(string mahd)
        {
            
            lblNam.Text = DateTime.Now.Year.ToString();
            lblThang.Text = DateTime.Now.Month.ToString();
            lblNgay.Text = DateTime.Now.Day.ToString();

            lblTenKhachHang.Text = bh.getInfoKhachHang(mahd, "TenKH");
            lblDiaChi.Text= bh.getInfoKhachHang(mahd, "DiaChi");
            lblSoDienThoai.Text= bh.getInfoKhachHang(mahd, "SDT");
            lblGioiTinh.Text= bh.getInfoKhachHang(mahd, "GioiTinh");
            lblTenKhachHangHoaDon.Text = bh.getInfoKhachHang(mahd, "TenKH");
            lblTenNhanVien.Text= bh.getInfoKhachHang(mahd, "TenNV");

            tt.showdata(this, mahd);
            this.ShowPreview();
        }
    }
}
