using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dall_Ball.DTO
{
 public   class NhapHangDTOT
    {
        private string _MaPN;
        private string _MaSP;
        private string _TenSP;
        private long _GiaNhap;
        private int _SoLuongNhap;
        private long _ThanhTien;



 
        public long ThanhTien { get => _ThanhTien; set => _ThanhTien = value; }
        public long GiaNhap { get => _GiaNhap; set => _GiaNhap = value; }
       
        public string MaPN { get => _MaPN; set => _MaPN = value; }
        public string MaSP { get => _MaSP; set => _MaSP = value; }
        public string TenSP { get => _TenSP; set => _TenSP = value; }
        public int SoLuongNhap { get => _SoLuongNhap; set => _SoLuongNhap = value; }
    }
}
