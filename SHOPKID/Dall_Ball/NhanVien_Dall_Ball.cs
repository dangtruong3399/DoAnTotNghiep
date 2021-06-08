using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball.DTO;


namespace Dall_Ball
{
    public class NhanVien_Dall_Ball
    {
        TuDongTang tt = new TuDongTang();
        ShopKidDataContext data = new ShopKidDataContext();

        public IQueryable loaddulieunhanvien()
        {
            var s = from NhanViens in data.NhanViens
                    select new
                    {
                        NhanViens.MaNV,
                        NhanViens.TenNV,
                        NhanViens.NgaySinh,
                        NhanViens.DiaChi,
                        NhanViens.SDT,
                        NhanViens.GioiTinh,
                        NhanViens.SoCMND,
                        NhanViens.ChucVu.TenCV,
                    };
            return s;
        }


        public List<NhanVienDTO> dsnhanvien()
        {
            List<NhanVienDTO> nvdt = new List<NhanVienDTO>();
            var ds = from k in data.NhanViens
                     select new NhanVienDTO
                     {
                         Manv1 = k.MaNV,
                         Tennv1=k.TenNV,
                         Ngaysinh1=(DateTime)k.NgaySinh,
                         Diachi1=k.DiaChi,
                         Sdt1=k.SDT,
                         Gioitinh1=k.GioiTinh,
                         Socmnd1=k.SoCMND,
                         Tencv1=k.ChucVu.TenCV,
                     };
            return ds.ToList();

        }

        public void them1NhanVien(string maNV, string tenNV, DateTime ngaysinh, string diaChi, string sdt, string gioiTinh, string socmnd, string macv)
        {
            NhanVien nv = new NhanVien();
            nv.MaNV = maNV;
            nv.TenNV = tenNV;
            nv.NgaySinh = ngaysinh;
            nv.DiaChi = diaChi;
            nv.SDT = sdt;
            nv.GioiTinh = gioiTinh;
            nv.SoCMND = socmnd;
            nv.MaCV = macv;

            data.NhanViens.InsertOnSubmit(nv);
            data.SubmitChanges();
        }

        public bool sua1NhanVien(string maNV, string tenNV, DateTime ngaysinh, string diaChi, string sdt, string gioiTinh, string socmnd, string macv)
        {
            NhanVien nv = new NhanVien();
            nv = data.NhanViens.Where(m => m.MaNV == maNV).FirstOrDefault();
            if (nv!=null)
            {
              
                nv.TenNV = tenNV;
                nv.NgaySinh = ngaysinh;
                nv.DiaChi = diaChi;
                nv.SDT = sdt;
                nv.GioiTinh = gioiTinh;
                nv.SoCMND = socmnd;
                nv.MaCV = macv;
                data.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<String> mahdxuattheonv(string manv)
        {
            var ds = from s in data.HoaDons.Where(t => t.MaNV == manv) select s.MaHD;
            return ds.ToList();
        }

        public void xoa1NhanVien(string maNV)
        {
            NhanVien nv = data.NhanViens.Where(m => m.MaNV == maNV).FirstOrDefault();
            data.NhanViens.DeleteOnSubmit(nv);
            data.SubmitChanges();
        }

        public string getmaNhanVien(string y)
        {


            string x = data.NhanViens.Max(t => t.MaNV);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));

            if (ma >= 0 && ma < 9)
            {
                return "NV00" + (ma + 1).ToString();
            }
            else if (ma >= 9)
            {
                return "NV0" + (ma + 1).ToString();
            }
            else
                return "";
        }

        public IQueryable LoadChucVu()
        {
            var a = from b in data.ChucVus select b;
            return a;
        }



    }
}
