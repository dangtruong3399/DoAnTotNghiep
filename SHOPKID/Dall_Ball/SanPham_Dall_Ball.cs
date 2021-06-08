using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball.DTO;

namespace Dall_Ball
{
    public class SanPham_Dall_Ball
    {

        ShopKidDataContext data = new ShopKidDataContext();
        TuDongTang tt = new TuDongTang();
        public IQueryable GetSanPham()
        {
            var s = from SanPham in data.SanPhams select SanPham;

            return s;
        }
        public List<SanPhamDTO> GetSpAll()
        {

            List<SanPhamDTO> nvdt = new List<SanPhamDTO>();
            var ds = from k in data.Khos
                     select new SanPhamDTO
                     {
                         MaSp1 = k.MaSP,
                         TenSp1 = k.SanPham.TenSP,
                         DonViTinh1 = k.SanPham.DonViTinh,
                         Giaban1 = (long)k.SanPham.GiaBan,
                         SoluongTon1 = (int)k.SoLuong
                     };
            return ds.ToList();
        }
        //public string xem()
        //{
        //    string x = "";
        //    if (data.SanPhams.ToList().Count >= 0)
        //    {

        //        x= getmasptutang();

        //    }
        //    else
        //        textinput.= "sp001";
        //    return x;
        //}
        public IQueryable loadspandlsp()
        {
            var ds = from Khos in data.Khos
                     select new
                     {
                         Khos.SanPham.MaSP,
                         Khos.SanPham.TenSP,
                         Khos.SanPham.LoaiSanPham.TenLoai,
                         Khos.SoLuong,
                         Khos.SanPham.MoTa,
                         Khos.SanPham.GiaBan,
                         Khos.SanPham.GiaNhap,
                         Khos.SanPham.DonViTinh,
                         Khos.SanPham.HinhAnh,
                         Khos.SanPham.MaLoai,
                     };
            return ds;
        }

        public void them1loaisanpham(string masp, string tensp, string donvitinh, long giaban, long gianhap, string hinhanh, string mota, string maloai)
        {
            try
            {
                SanPham sanPham = new SanPham
                {
                    MaSP = masp,
                    TenSP = tensp,
                    DonViTinh = donvitinh,
                    GiaBan = (long)giaban,
                    GiaNhap = (long)gianhap,
                    HinhAnh = hinhanh,
                    MoTa = mota,
                    MaLoai = maloai,
                };
                data.SanPhams.InsertOnSubmit(sanPham);
                data.SubmitChanges();
            }
            catch (Exception ex)
            {
                
            }
        }

        public void xoa1sanpham(string masp)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                SanPham sanPham = new SanPham();
                sanPham = data.SanPhams.Where(t => t.MaSP == masp).FirstOrDefault();
                if (sanPham!=null)
                {
                    data.SanPhams.DeleteOnSubmit(sanPham);
                    data.SubmitChanges();
                }
            }
        }

        public void sua1sanpham(string masp, string tensp, string donvitinh, float giaban, float gianhap, string hinhanh,  string mota, string maloai)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                var querySanPhams =
                from SanPhams in data.SanPhams
                where SanPhams.MaSP == masp
                select SanPhams;
            foreach (var SanPhams in querySanPhams)
            {
           
                SanPhams.TenSP = tensp;
                SanPhams.DonViTinh = donvitinh;
                SanPhams.GiaBan = (long)giaban;
                SanPhams.GiaNhap = (long)gianhap;
                SanPhams.HinhAnh = hinhanh;
                SanPhams.MoTa = mota;
                SanPhams.MaLoai= maloai;
            }
            data.SubmitChanges();
            }
        }

        public string getmasptutang()
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                string x = data.SanPhams.Max(t => t.MaSP);
                int ma = int.Parse(x.Substring(x.Length - 3, 3));
                if (ma >= 0 && ma < 9)
                {
                    return "SP00" + (ma + 1).ToString();
                }
                else if (ma >= 9 && ma < 99)
                {
                    return "SP0" + (ma + 1).ToString();
                }
                else if (ma >= 99 && ma <= 999)
                    return "SP";
                else return "";
            }
        }

        //public string loadgianhap(string masp)
        //{
        //    List<SanPham> sp = new List<SanPham>();
        //    sp = data.SanPhams.Where(t => t.MaSP == masp).ToList();
        //    //return sp[0].GiaNhap.ToString();
        //}

        //public string loadgiaban(string masp)
        //{
        //    List<SanPham> sp = new List<SanPham>();
        //    sp = data.SanPhams.Where(t => t.MaSP == masp).ToList();
        //    return sp[0].GiaBan.ToString();
        //}

        public int getsoluongtheosp(string masp)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                return data.Khos.Where(t => t.MaSP == masp).ToList()[0].SoLuong.Value;
            } 
        }

    }
}
