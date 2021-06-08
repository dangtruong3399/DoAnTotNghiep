using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dall_Ball
{
    public class PhieuNhap_DALL_BaLL
    {
        ShopKidDataContext data = new ShopKidDataContext();
       //public IQueryable load_PN()
       // {
       //     var ds = from ChiTietPhieuNhaps in data.ChiTietPhieuNhaps
       //              select new
       //              {
       //                  ChiTietPhieuNhaps.MaPN,
       //                  ChiTietPhieuNhaps.SanPham.TenSP,
       //                  NgayNhap=(DateTime?)ChiTietPhieuNhaps.PhieuNhap.NgayNhap,
       //                  ChiTietPhieuNhaps.PhieuNhap.NhaCungCap.TenNCC,
       //                  ChiTietPhieuNhaps.SoLuongNhap,
       //                  ChiTietPhieuNhaps.ThanhTien
                         
       //              };
       //     return ds;
       // }

        public IQueryable load_pn()
        {
            var pn = from k in data.PhieuNhaps
                     select new
                     {
                         k.MaPN,
                         k.NgayNhap,
                         k.NhaCungCap.TenNCC,
                          
                     };
            return pn;
        }
        
        public IQueryable loadchitietpn(string pn)
        {
            var n = from k in data.ChiTietPhieuNhaps.Where(t=>t.MaPN==pn)
                     select new
                     {
                           k.MaPN,
                         k.SanPham.TenSP,
                         k.SanPham.GiaNhap,
                         k.SanPham.DonViTinh,
                         k.SoLuongNhap,
                        k.PhieuNhap.NhaCungCap.TenNCC,
                         k.ThanhTien,                    
                     };
            return n;
        }
             
        public string matudongtang()
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                string s = "";
                if (data.PhieuNhaps.ToList().Count > 0)
                {
                    s = "PN";
                    string x = data.PhieuNhaps.Max(t => t.MaPN);
                    int ma = int.Parse(x.Substring(2, 3));

                    if (ma < 9)
                        return s + "00" + (ma + 1).ToString();
                    else if (ma >=9 && ma < 99)
                        return s + "0" + (ma + 1).ToString();
                    else if (ma >= 99 && ma <= 999)
                        return s + (ma + 1).ToString();
                    else
                        return "";
                }
                return "PN001";
            }
        }
        public bool kiemtrangayhientai()
        {
            //string s = DateTime.Now.Year + "-" + DateTime.Now.Day + "-" + DateTime.Now.Month;
            DateTime s = DateTime.Now;
            //string[] formattedStrings =s.GetDateTimeFormats();
            if (data.PhieuNhaps.Where(t => t.NgayNhap == s).ToList().Count <= 0)
                return true;
            else
                return false;
        }
        public string laymahdtudate()     
        {
            DateTime s = DateTime.Now;
            string[] formattedStrings = s.GetDateTimeFormats();
            var  ds=data.PhieuNhaps.Where(t => t.NgayNhap==s).ToList()[0].MaPN ;
            if(ds!=null)
            {
                return ds.ToString();
            }
            else
            {
                return "";
            }
        }
        public void them1pn(string mapn,string mancc,string manv,DateTime ngaynhap,long tongtien)
        {
            try
            {
                using (ShopKidDataContext data = new ShopKidDataContext())
                {
                    PhieuNhap pn = new PhieuNhap();
                    pn.MaPN = mapn;
                    pn.NgayNhap = ngaynhap;
                    pn.TongTien = tongtien;
                    pn.MaNV = manv;
                    pn.MaNCC = mancc;
                    data.PhieuNhaps.InsertOnSubmit(pn);
                    data.SubmitChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }         
        }
        public void them1chitetpn(string mapn,string masp,long gianhap,int soluong,long thanhtien)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                ChiTietPhieuNhap pn = new ChiTietPhieuNhap();
            pn.MaPN = mapn;
            pn.MaSP = masp;
            pn.SoLuongNhap = soluong;
            pn.ThanhTien = thanhtien;
            data.ChiTietPhieuNhaps.InsertOnSubmit(pn);
            data.SubmitChanges();
                }
        }
        public bool kiemtraphieunhap(string mapn)
        {
            if (data.ChiTietPhieuNhaps.Where(t => t.MaPN == mapn).ToList().Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool kiemtrachitiethd(string mahd)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                if (data.ChiTietPhieuNhaps.Where(t => t.MaPN == mahd).ToList().Count <= 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public void delete(string mapn)
        {

            using (ShopKidDataContext data = new ShopKidDataContext())
            {
              
                    PhieuNhap ct = new PhieuNhap();
                    ct = data.PhieuNhaps.Where(t => t.MaPN == mapn).FirstOrDefault();
                    if (ct != null)
                    {
                        data.PhieuNhaps.DeleteOnSubmit(ct);
                        data.SubmitChanges();
                    }
            }
        }
        public void deletectpn(string mapn)
        {  
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                while (data.ChiTietPhieuNhaps.Where(t => t.MaPN == mapn).ToList().Count > 0)
                {
                    ChiTietPhieuNhap ct = new ChiTietPhieuNhap();
                    ct = data.ChiTietPhieuNhaps.Where(t => t.MaPN == mapn).FirstOrDefault();
                    if (ct != null)
                    {
                        data.ChiTietPhieuNhaps.DeleteOnSubmit(ct);
                        data.SubmitChanges();
                    }
                }      
            }
        }
        public void deletectpnmasp(string masp)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                while (data.ChiTietPhieuNhaps.Where(t => t.MaSP == masp).ToList().Count > 0)
                {
                    ChiTietPhieuNhap ct = new ChiTietPhieuNhap();
                    ct = data.ChiTietPhieuNhaps.Where(t => t.MaSP == masp).FirstOrDefault();
                    if (ct != null)
                    {
                        data.ChiTietPhieuNhaps.DeleteOnSubmit(ct);
                        data.SubmitChanges();
                    }
                }
            }
        }
        public string gettongtien(string mapn)
        {
            var ds = from ChiTietPhieuNhaps in
 (from ChiTietPhieuNhaps in data.ChiTietPhieuNhaps
  where
    ChiTietPhieuNhaps.MaPN == mapn
  select new
  {
      ChiTietPhieuNhaps.ThanhTien,
      Dummy = "x"
  })
                     group ChiTietPhieuNhaps by new { ChiTietPhieuNhaps.Dummy } into g
                    
                     select new
                     {
                         
                        tongtien=g.Sum(p => p.ThanhTien).Value
                     };
            return ds.ToList()[0].tongtien.ToString();
        }
        public void deletepnall()
        {

            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                for(int i=0;i<data.PhieuNhaps.ToList().Count;i++)
                {
                    PhieuNhap ct = new PhieuNhap();
                    if (data.PhieuNhaps.ToList()[i].ChiTietPhieuNhaps.Count<=0)                         

                    {
                            string mapn = data.PhieuNhaps.ToList()[i].MaPN;
                            ct = data.PhieuNhaps.Where(t => t.MaPN == mapn).FirstOrDefault();
                            if (ct != null)
                            {
                                data.PhieuNhaps.DeleteOnSubmit(ct);
                                data.SubmitChanges();
                            }
                        } 
                }
            }
        }
        //public string getInfoTenNV(string mahd)
        //{

        //    var ds = from k in data.PhieuNhaps.Where(t => t.MaPN == mahd)
        //         select new
        //         {
                   
                   
        //         };
        //    if (giatricanlay == "TenKH")
        //        return ds.ToList()[0].TenKH;
        //    else if (giatricanlay == "DiaChi")
        //        return ds.ToList()[0].DiaChi;
        //    else if (giatricanlay == "SDT")
        //        return ds.ToList()[0].DiaChi;
        //    else if (giatricanlay == "GioiTinh")
        //        return ds.ToList()[0].GioiTinh;
        //    else if (giatricanlay == "TenNV")
        //        return ds.ToList()[0].TenNV;
        //    else
        //        return "";
        //}

    }
}
