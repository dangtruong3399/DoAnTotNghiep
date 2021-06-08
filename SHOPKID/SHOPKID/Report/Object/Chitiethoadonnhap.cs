using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball;

namespace SHOPKID.Report.Object
{
   public class Chitiethoadonnhap : DevExpress.Xpo.XPLiteObject
    {
        PhieuNhap_DALL_BaLL pn = new PhieuNhap_DALL_BaLL();
        private string _MaPN;
        private string _TenSP;
        private int _SoLuongNhap;
        private long _GiaNhap;
        private long _ThanhTien;
        private string _DonViTinh;
        public string MaPN { get => _MaPN; set => _MaPN = value; }
        public string TenSP { get => _TenSP; set => _TenSP = value; }
       
      
        public long ThanhTien { get => _ThanhTien; set => _ThanhTien = value; }
        public string DonViTinh { get => _DonViTinh; set => _DonViTinh = value; }
        public int SoLuongNhap { get => _SoLuongNhap; set => _SoLuongNhap = value; }
        public long GiaNhap { get => _GiaNhap; set => _GiaNhap = value; }

        public void showdata(HoaDonNhapHangRpt rpt, string mapn)
        {
            rpt.DataSource = pn.loadchitietpn(mapn);
            rpt.CreateDocument();
        }
    }
}
