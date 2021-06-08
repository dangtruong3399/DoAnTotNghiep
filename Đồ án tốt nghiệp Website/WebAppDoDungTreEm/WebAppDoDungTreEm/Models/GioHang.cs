using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDoDungTreEm.Models
{
    public class GioHang
    {
        QLTreEmDataContext db = new QLTreEmDataContext();
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double Gia { get; set; }
        public string Hinh { get; set; }
        public int Soluong { get; set; }
        public string Maloai { get; set; }
        public double ThanhTien
        {
            get
            {
                return Soluong * Gia;
            }
        }
        public GioHang(string msp)
        {
            MaSP = msp+"";
            SanPham obj = db.SanPhams.Single(n => n.MaSP == MaSP);
            TenSP = obj.TenSP;
            Hinh = obj.HinhAnh;
            Gia = double.Parse(obj.GiaBan.ToString());
            Soluong = 1;
            Maloai = obj.MaLoai;
        }
    }
}