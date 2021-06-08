using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball;
namespace SHOPKID.Report.Object
{
   public class Chitiethoadonbanhang :DevExpress.Xpo.XPLiteObject

    {
        BanHang_Dall_Ball bh = new BanHang_Dall_Ball();
        private string mahd;
        private string _TenSP;
        private int _Soluong;
        private long _Dongia;
        private long _Thanhtien;
        private string _Donvitinh;
        public string Mahd { get => mahd; set => mahd = value; }
        public string TenSP { get => _TenSP; set => _TenSP = value; }
        public int Soluong { get => _Soluong; set => _Soluong = value; }
        public long Dongia { get => _Dongia; set => _Dongia = value; }
        
        public long Thanhtien { get => _Thanhtien; set => _Thanhtien = value; }
        public string Donvitinh { get => _Donvitinh; set => _Donvitinh = value; }

        public void showdata(HoaDonBanHangRpt rpt,string mahd)
        {
            rpt.DataSource = bh.getHDBH(mahd);
            rpt.CreateDocument();
        }
    }
}
