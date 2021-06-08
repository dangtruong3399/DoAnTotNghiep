using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dall_Ball
{
    public class KhoDaLL_BaLL
    {

        ShopKidDataContext data = new ShopKidDataContext();
        public IQueryable load_kho()
        {

            var ds = from k in data.Khos
                     select new
                     {
                         k.MaKho,
                         k.SanPham.TenSP,
                         k.SoLuong,
                     };
            return ds;

        }
        public void upadtekho(string masp, int soluong)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                Kho kh = new Kho();
                kh = data.Khos.Where(t => t.MaSP == masp).FirstOrDefault();
                if (kh != null)
                {
                    kh.SoLuong = soluong;
                    data.SubmitChanges();
                }
            }

        }
        public int getsoluongkho(string masp)
        {

            return data.Khos.Where(t => t.MaSP == masp).ToList()[0].SoLuong.Value;

        }

        public void xoakho(string masp)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                Kho kh = new Kho();
                kh = data.Khos.Where(t => t.MaSP == masp).FirstOrDefault();
                if (kh != null)
                {
                    data.Khos.DeleteOnSubmit(kh);
                    data.SubmitChanges();
                }
            }

        }

       

       
    }
}
