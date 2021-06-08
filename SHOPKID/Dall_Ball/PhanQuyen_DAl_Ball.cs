using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball.DTO;
namespace Dall_Ball
{
    public class PhanQuyen_DAl_Ball
    {

        ShopKidDataContext data = new ShopKidDataContext();


    
        public List<Quyen> getAllQuyen(string username)
        {
            return data.Quyens.Where(t => t.UserName == username).ToList();

            
            //var ds = from k in data.Quyens
            //         select new QuyenDTO
            //         {
            //             TenBtn = k.DMform.TenBtn

            //         };
            //return ds.ToList();
        } 
        public  IQueryable getAll(string username)
        {
            var ds = from s in data.Quyens.Where(t => t.UserName == username)
                     select new
                     {
                       
                         s.DMform.IDform,
                         s.DMform.TenFrm,                 
                     };
            return ds;
        }

        public IQueryable load_username()
        {
            var ds = from k in data.UserNhanViens select new {
                k.UserName,
                k.NhanVien.TenNV,
            };
            return ds;
        }
        public IQueryable load_quyenchuaco(string username)
        {
            var ds = from DMforms in data.DMforms
                     where
                       !
                         (from Quyens in data.Quyens
                          where
        Quyens.UserName == username
                          select new
                          {
                              Quyens.IdFrm
                          }).Contains(new { IdFrm = DMforms.IDform })
                     select new
                     {
                         DMforms.IDform,
                         DMforms.TenFrm
                     };

            return ds;
        }

        public void insertQuyen(string username,string idfrom)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                Quyen dm = new Quyen();
                dm.UserName = username;
                dm.IdFrm = idfrom;

                data.Quyens.InsertOnSubmit(dm);
                data.SubmitChanges();
            }
        }
        public void deleteQuyen(string username,string idfrom)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                Quyen qp = new Quyen();
                qp = data.Quyens.Where(t => t.IdFrm == idfrom && t.UserName==username).FirstOrDefault();
                if (qp != null)
                {
                    data.Quyens.DeleteOnSubmit(qp);
                    data.SubmitChanges();
                }

            }
        }
        public bool kiemtraquyen(string username,string idfrom)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                var ds = data.Quyens.Where(t => t.IdFrm == idfrom && t.UserName == username).ToList();
                if (ds.ToList().Count <= 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
