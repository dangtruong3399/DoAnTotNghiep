using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDoDungTreEm.Models
{
    public class ThongKe
    {
        QLTreEmDataContext db = new QLTreEmDataContext();
        public int MaDH { get; set; }
        public string Username { get; set; }
        public DateTime NgayDatHang { get; set; }
        public DateTime NgayGiao { get; set; }
        public string MaSP { get; set; }
        public double DonGia { get; set; }
        public int Soluong { get; set; }
        public double ThanhTien
        {
            get
            {
                return Soluong * DonGia;
            }
        }
        public ThongKe()
        {
            
        }
    }
}