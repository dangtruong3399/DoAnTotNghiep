using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball.DTO;

namespace Dall_Ball
{
    public class TaiKhoan_Dall_BaLL
    {
        ShopKidDataContext data = new ShopKidDataContext();
       
        public IQueryable getalltk()
        {
            return from k in data.UserNhanViens
                   select new
                   {
                       k.UserName,
                       k.NhanVien.TenNV,
                       k.NhanVien.ChucVu.TenCV,
                       k.NhanVien.MaNV,
                   };

        }
        public string SHA256(string password)
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
        public void them1taikhoan(string username, string password, string manv)
        {
            UserNhanVien user = new UserNhanVien();
            user.UserName = username;
            user.Password = SHA256(password);
            user.MaNV = manv;
            data.UserNhanViens.InsertOnSubmit(user);
            data.SubmitChanges();
        }

      
        public bool sua1taikhoan(TaiKhoanDTO taiKhoan, string password)
        {
            UserNhanVien user = new UserNhanVien();
           
                user = data.UserNhanViens.FirstOrDefault(t => t.UserName == taiKhoan.UserName && t.Password==SHA256(password));
                if(user!=null)
                {
                user.Password = SHA256(taiKhoan.Password);
                data.SubmitChanges();
                return true;
                }

            return false;
        }
        public void xoa1taikhoan(string username)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                UserNhanVien user = new UserNhanVien();
                user = data.UserNhanViens.Where(t => t.UserName ==username).FirstOrDefault();
                if (user != null)
                {
                    data.UserNhanViens.DeleteOnSubmit(user);
                    data.SubmitChanges();
                }
            }
        }
    }
}
