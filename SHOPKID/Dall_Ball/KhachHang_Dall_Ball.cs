using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball.DTO;

namespace Dall_Ball
{
    public class KhachHang_Dall_Ball
    {
        TuDongTang tt = new TuDongTang();
        ShopKidDataContext data = new ShopKidDataContext();

        public IQueryable getdskhachhang()
        {
            var ds = from KhachHangs in data.KhachHangs
                     select new
                     {
                         KhachHangs.MaKH,
                         KhachHangs.TenKH,
                     
                         KhachHangs.SDT,
                    
                         KhachHangs.DiaChi,
                         KhachHangs.GioiTinh,
                     };

            return ds;

        }

        public List<KhachHangDTO> GetkhAll()
        {

            List<KhachHangDTO> khdt = new List<KhachHangDTO>();
            var ds = from k in data.KhachHangs
                     select new KhachHangDTO
                     {
                         Makh1 = k.MaKH,
                         Tenkh1 = k.TenKH,
                         
                         Sdt1 = k.SDT,
                       
                         Diachi1 = k.DiaChi,
                         Gioitinh1 = k.GioiTinh,

                     };
            return ds.ToList();
        }

        public List<KhachHang> loadallkh()
        {
            return data.KhachHangs.ToList();
        }


        public void them1khachhang(string makh, string tenkh, string sdt,  string diachi, string gioitinh)
        {
            KhachHang kh = new KhachHang();

            kh.MaKH = makh;
            kh.TenKH = tenkh; 
            kh.SDT = sdt;
            kh.DiaChi = diachi;
            kh.GioiTinh = gioitinh;


            data.KhachHangs.InsertOnSubmit(kh);
            data.SubmitChanges();



        }


        public void sua1KhachHang(string makh, string tenkh, string sdt, string diachi, string gioitinh)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                var queryKhachHangs = from KhachHangs in data.KhachHangs
                                      where KhachHangs.MaKH == makh
                                      select KhachHangs;
                foreach (var KhachHangs in queryKhachHangs)
                {
                    KhachHangs.TenKH = tenkh;
                    KhachHangs.SDT = sdt;
                    KhachHangs.DiaChi = diachi;
                    KhachHangs.GioiTinh = gioitinh;
                }

                data.SubmitChanges();
            }
        }

        public void xoa1KhachHang(string makh)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                KhachHang kh = new KhachHang();
                kh = data.KhachHangs.Where(t => t.MaKH == makh).FirstOrDefault();
                if (kh != null)
                {
                    data.KhachHangs.DeleteOnSubmit(kh);
                    data.SubmitChanges();
                }
            }
        }

        public string getmakhachhang(string y)
        {
            string x = data.KhachHangs.Max(t => t.MaKH);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));

            if (ma >= 0 && ma < 9)
            {
                return "KH00" + (ma + 1).ToString();
            }
            else if (ma >= 9 && ma < 99)
            {
                return "KH0" + (ma + 1).ToString();
            }
            else if (ma >= 99 && ma <= 999)
                return "KH";
            else
                return "";

        }

    }
}
