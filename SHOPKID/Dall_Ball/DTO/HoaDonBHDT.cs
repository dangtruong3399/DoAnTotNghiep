using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dall_Ball.DTO
{
  public  class HoaDonBHDT
    {
        string MaSP;
        int SoLuong;
        long dongia;
        long thanhtien;
        string tensp;
        public string MaSP1 { get => MaSP; set => MaSP = value; }
        public int SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public long Dongia { get => dongia; set => dongia = value; }
        public long Thanhtien { get => thanhtien; set => thanhtien = value; }
        public string Tensp { get => tensp; set => tensp = value; }
    }
}
