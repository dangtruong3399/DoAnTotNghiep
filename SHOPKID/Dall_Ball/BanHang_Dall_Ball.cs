using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball.DTO;
namespace Dall_Ball
{
    public class BanHang_Dall_Ball
    {

        ShopKidDataContext data = new ShopKidDataContext();

        public IQueryable loadsp()
        {
            var ds = from k in data.Khos.Where(t => t.SoLuong > 0)
                     select new
                     {
                         k.MaSP,
                         k.SanPham.TenSP,
                         k.SoLuong,
                     };
            return ds;
        }
        public string getMahdauto()
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                //HD001
                string s = "";
                if (data.HoaDons.ToList().Count > 0)
                {
                    s = "HD";
                    string x = data.HoaDons.Max(t => t.MaHD);
                    string cat = x.Substring(2, 3);
                    int ma = int.Parse(x.Substring(2,3));
                    int k = ma + 1;
                    if (ma < 9)
                    {
                        return "HD00" + k.ToString();
                    }
                    else if (ma >= 9 && ma < 99)
                    {
                        return "HD0" + (ma + 1).ToString();
                    }
                    else if (ma >=99 && ma <= 999)
                        return "HD" + (ma + 1).ToString();
                    else
                        return null;
               
                }
                else
                    return "HD001";
            }
        }

        public void AddHoaDonBH(string mahd, DateTime ngaylaphd, bool trangthai, long tongtien, string manv, string makh)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                HoaDon hd = new HoaDon
                {
                    MaHD = mahd,
                    NgayLapHD = ngaylaphd,
                    TrangThai = trangthai,
                    TongTien = tongtien,
                    MaNV = manv,
                    MaKH = makh

                };
                data.HoaDons.InsertOnSubmit(hd);
                data.SubmitChanges();
            }


        }
        public void AddChitietHDBH(string mahd, long tongtien, string masp, int soluong, long dongia)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                ChiTietHD cthd = new ChiTietHD
                {
                    MaHD = mahd,
                    MaSP = masp,
                    SoLuong = soluong,
                    ThanhTien = tongtien,
                    DonGia = dongia,

                };
                data.ChiTietHDs.InsertOnSubmit(cthd);
                data.SubmitChanges();
            }
        }
        public long GetGiaSptheoMa(string masp)
        {
            List<SanPham> hh = new List<SanPham>();
            hh = data.SanPhams.Where(t => t.MaSP == masp).ToList();
            return hh[0].GiaBan.Value;
        }
        public long GetGianhapSptheoma(string masp)
        {

            List<SanPham> hh = new List<SanPham>();
            hh = data.SanPhams.Where(t => t.MaSP == masp).ToList();
            return hh[0].GiaNhap.Value;
        }

        //public List<NhanVienDTO> dsnhanvien()
        //{
        //    List<NhanVienDTO> nvdt = new List<NhanVienDTO>();
        //    var ds = from k in data.NhanViens
        //             select new NhanVienDTO
        //             {
        //                 Manv1 = k.MaNV,
        //                 Tennv1 = k.TenNV,
        //                 Ngaysinh1 = (DateTime)k.NgaySinh,
        //                 Diachi1 = k.DiaChi,
        //                 Sdt1 = k.SDT,
        //                 Gioitinh1 = k.GioiTinh,
        //                 Socmnd1 = k.SoCMND,
        //                 Tencv1 = k.ChucVu.TenCV,
        //             };
        //    return ds.ToList();

        //}

        public List<HoaDonDTO> getAllHoadon()
        {
            var ds = from k in data.HoaDons
                     select new HoaDonDTO
                     {
                         MaHD = k.MaHD,
                         NgayLapHD = (DateTime)k.NgayLapHD,
                         TrangThai = (bool)k.TrangThai,
                         TenKH = k.KhachHang.TenKH,
                         TenNV = k.NhanVien.TenNV,
                         TongTien = (long)k.TongTien,
                         MaKH = k.MaKH,
                         


                     };
            return ds.ToList();
        }

        public IQueryable getAllCTHoaDon(string mahd)
        {
            return  from k in data.ChiTietHDs.Where(t => t.MaHD == mahd)
                   select new
                   {
                       k.MaHD,
                       k.SanPham.TenSP,
                       k.SoLuong,
                       k.DonGia,
                       k.ThanhTien,
                   };
            
        }

        public List<HoaDonDTO> getIDHD(string mahd)
        {
            var ds = from k in data.HoaDons
                     where
                      k.MaHD.StartsWith(mahd)
                     select new HoaDonDTO
                     {
                         MaHD = k.MaHD,
                         NgayLapHD = (DateTime)k.NgayLapHD,
                         TrangThai = (bool)k.TrangThai,
                         TenKH = k.KhachHang.TenKH,
                         TenNV = k.NhanVien.TenNV,

                         TongTien = (long)k.TongTien,



                     };
            return ds.ToList();
        }
        public  void deleteCTHD(string mahd)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                while (data.ChiTietHDs.Where(t => t.MaHD == mahd).ToList().Count > 0)
                {
                    ChiTietHD ct = new ChiTietHD();
                    ct = data.ChiTietHDs.Where(t => t.MaHD == mahd).FirstOrDefault();
                    if (ct != null)
                    {
                        data.ChiTietHDs.DeleteOnSubmit(ct);
                        data.SubmitChanges();
                    }
                }
            }
        }
        public bool kiemtrachitiethd(string mahd)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
               
                if (data.ChiTietHDs.Where(t=>t.MaHD==mahd).ToList().Count <= 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public void deletehd(string mahd)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                HoaDon ct = new HoaDon();
                ct = data.HoaDons.Where(t => t.MaHD == mahd).FirstOrDefault();
                if (ct != null)
                {
                    data.HoaDons.DeleteOnSubmit(ct);
                    data.SubmitChanges();
                }
            }
        }
        public bool kiemtrahoadon(string mahd)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                if (data.ChiTietHDs.Where(t => t.MaHD == mahd).ToList().Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public string getSDTKh(string makh)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                return data.KhachHangs.Where(t => t.MaKH == makh).ToList()[0].SDT.ToString();

            }
        }
        public string getDiaChiKh(string makh)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                return data.KhachHangs.Where(t => t.MaKH == makh).ToList()[0].DiaChi.ToString();

            }
        }
        public void deletectpxmasp(string masp)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                while (data.ChiTietHDs.Where(t => t.MaSP == masp).ToList().Count > 0)
                {
                    ChiTietHD ct = new ChiTietHD();
                    ct = data.ChiTietHDs.Where(t => t.MaSP == masp).FirstOrDefault();
                    if (ct != null)
                    {
                        data.ChiTietHDs.DeleteOnSubmit(ct);
                        data.SubmitChanges();
                    }
                }

            }
        }

        public void deletepnallbh()
        {

            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                for (int i = 0; i < data.HoaDons.ToList().Count; i++)
                {
                    HoaDon ct = new HoaDon();
                    if (data.HoaDons.ToList()[i].ChiTietHDs.Count <= 0)

                    {
                        string mapn = data.HoaDons.ToList()[i].MaHD;
                        ct = data.HoaDons.Where(t => t.MaHD == mapn).FirstOrDefault();
                        if (ct != null)
                        {
                            data.HoaDons.DeleteOnSubmit(ct);
                            data.SubmitChanges();
                        }
                    }
                }

            }
        }
        public IQueryable getHDBH(string mahd)
        {
            return from k in data.ChiTietHDs.Where(t => t.MaHD == mahd)
                   select new
                   {
                       k.SanPham.TenSP,
                       k.SoLuong,
                       k.SanPham.DonViTinh,
                       k.DonGia,
                       k.ThanhTien,
                   };
        }

        public string getInfoKhachHang(string mahd,string giatricanlay)
        {

            var ds = from k in data.HoaDons.Where(t => t.MaHD == mahd)
                     select new
                     {
                         k.KhachHang.TenKH,
                         k.KhachHang.DiaChi,
                         k.KhachHang.SDT,
                         k.KhachHang.GioiTinh,
                         k.NhanVien.TenNV,
                     };   
            if (giatricanlay == "TenKH")
                return ds.ToList()[0].TenKH;
            else if (giatricanlay == "DiaChi")
                return ds.ToList()[0].DiaChi;
            else if (giatricanlay == "SDT")
                return ds.ToList()[0].SDT;
            else if (giatricanlay == "GioiTinh")
                return ds.ToList()[0].GioiTinh;
            else if(giatricanlay=="TenNV")
                return ds.ToList()[0].TenNV;
            else
                return "";
        }
        public List<DoanhThuDTO> getDoanhthu(DateTime ngayfrom,DateTime ngayto)
        {
            string ngaybd = ngayfrom.Year.ToString()+"-"+ngayfrom.Month +'-' + ngayfrom.Day ;
            string ngayketthuc = ngayto.Year.ToString() + "-" + ngayto.Month.ToString() + '-' + ngayto.Day;
            var ds = from ChiTietHDs in data.ChiTietHDs
                     where ChiTietHDs.HoaDon.NgayLapHD.Value>=DateTime.Parse(ngaybd) && ChiTietHDs.HoaDon.NgayLapHD.Value<=DateTime.Parse(ngayketthuc)
                     group new { ChiTietHDs.HoaDon, ChiTietHDs, ChiTietHDs.SanPham } by new
                     {
                         ChiTietHDs.HoaDon.MaHD,
                         NgayLapHD = (DateTime?)ChiTietHDs.HoaDon.NgayLapHD
                     } into g
                     select new DoanhThuDTO
                     {
                       MahD=g.Key.MaHD,
                        Tongiaban =(long)g.Sum(p => p.ChiTietHDs.ThanhTien),
                         NgaylapHd =g.Key.NgayLapHD.Value,
                         Tongianhap =(long)g.Sum(p => p.ChiTietHDs.SoLuong * p.ChiTietHDs.SanPham.GiaNhap),
                         DoanhThu = (long)(g.Sum(p => p.ChiTietHDs.ThanhTien) - g.Sum(p => p.ChiTietHDs.SoLuong * p.ChiTietHDs.SanPham.GiaNhap))
                     };
            return ds.ToList();
        }
    }


}
    