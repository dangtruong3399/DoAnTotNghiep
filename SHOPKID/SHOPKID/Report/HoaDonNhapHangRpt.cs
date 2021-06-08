using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SHOPKID.Report.Object;

namespace SHOPKID.Report
{
    public partial class HoaDonNhapHangRpt : DevExpress.XtraReports.UI.XtraReport
    {

        Chitiethoadonnhap tt = new Chitiethoadonnhap();
        
        public HoaDonNhapHangRpt()
        {
            InitializeComponent();
        }
        public void showdata(string mapn,string tennv,string ncc)
        {
            lblNam.Text = DateTime.Now.Year.ToString();
            lblThang.Text = DateTime.Now.Month.ToString();
            lblNgay.Text = DateTime.Now.Day.ToString();
            lblTenNv.Text = tennv;
            lblTenNCC.Text = ncc;
            tt.showdata(this,mapn);
            this.ShowPreview();
        }

    }
}
