using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dall_Ball.DTO
{
   public class HoaDonDTO
    {
        private string _MaHD;
        private DateTime _NgayLapHD;
        private bool _TrangThai;
        private long _TongTien;
        private string _TenKH;
        private string _TenNV;
        private string _MaKH;

        public string MaHD { get => _MaHD; set => _MaHD = value; }
        public DateTime NgayLapHD { get => _NgayLapHD; set => _NgayLapHD = value; }
        public bool TrangThai { get => _TrangThai; set => _TrangThai = value; }
        public long TongTien { get => _TongTien; set => _TongTien = value; }
        public string TenKH { get => _TenKH; set => _TenKH = value; }
        public string TenNV { get => _TenNV; set => _TenNV = value; }
        public string MaKH { get => _MaKH; set => _MaKH = value; }
    }
}
