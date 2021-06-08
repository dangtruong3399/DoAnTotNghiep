using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball.DTO;

namespace Dall_Ball
{
 public  class DangNhap_Dall_Ball
    {
     
     

        public  List<UserNhanVien> GetLogin(string username,string passwrod)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                var ds = from UserNhanVien in data.UserNhanViens
                     where
                       UserNhanVien.UserName == username &&
                       UserNhanVien.Password == SHA256(passwrod)
                         select UserNhanVien;
                return ds.ToList();
            }
        }

       
        public List<TaiKhoanDTO> getAllTaiKhoan()
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                List<TaiKhoanDTO> nvdt = new List<TaiKhoanDTO>();
                var ds = from k in data.UserNhanViens
                         select new TaiKhoanDTO
                         {
                           UserName=k.UserName,
                           TenNV=k.NhanVien.TenNV,

                         };
                return ds.ToList();
            }
        }
        public   string SHA256(string password)
        {
            try
            {
                SHA256Managed crypt = new SHA256Managed();
                string hash = string.Empty;
                byte[] crypyo = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
                foreach (byte item in crypyo)
                {

                    hash += item.ToString("x2");
                }
                return hash;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public string GetUserNV(string username)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                string ds = (from NguoiDungs in data.UserNhanViens
                             where
                               NguoiDungs.UserName == username
                             select NguoiDungs.NhanVien.TenNV).FirstOrDefault();
                return ds;
            }
        }
        public string GetUserMaNV(string username)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                string ds = (from NguoiDungs in data.UserNhanViens
                             where
                               NguoiDungs.UserName == username
                             select NguoiDungs.NhanVien.MaNV).FirstOrDefault();
                return ds;
            }
        }
    }

}
