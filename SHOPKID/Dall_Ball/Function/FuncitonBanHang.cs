using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball;
using Dall_Ball.DTO;

namespace Dall_Ball
{
   public class FuncitonBanHang
    {
        BanHang_Dall_Ball bh = new BanHang_Dall_Ball();
        public List<HoaDonBHDT> AddTam(string masp,int soluong,long dongia,long thanhtien)
        {
            List<HoaDonBHDT> lst = new List<HoaDonBHDT>();
            HoaDonBHDT dt = new HoaDonBHDT();
            dt.MaSP1 = masp;
            dt.SoLuong1 = soluong;
            dt.Dongia = dongia;
            dt.Thanhtien = thanhtien;
            lst.Add(dt);
            return lst;
            
        }
        public long GetGiaspTheoMa(string masp)
        {
            return bh.GetGiaSptheoMa(masp);
                
        }
        public long GetGianhapSptheoma(string masp)
        {
            return bh.GetGianhapSptheoma(masp);

        }
        public long GetThanhTien(int soluong,long dongia)
        {
            return soluong * dongia;
        }
    }
}
