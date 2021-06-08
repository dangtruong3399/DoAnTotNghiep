using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball.DTO;
namespace Dall_Ball
{
    public class ChucVu_Dall_Ball
    {
        ShopKidDataContext data = new ShopKidDataContext();

        public List<ChucVu> loadcv()
        {
            return data.ChucVus.ToList();

        }
        //public List<ChucVuDTO> Getallchucvu()
        //{

        //    List<ChucVuDTO> nvdt = new List<ChucVuDTO>();
        //    var ds = from k in data.ChucVus
        //             select new ChucVuDTO
        //             {
        //                 Macv1=k.MaCV,
        //                 Tencv1=k.TenCV,

        //             };
        //    return ds.ToList();
        //}

        public string getmachucvu()
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                string x = data.ChucVus.Max(t => t.MaCV);
            int ma = int.Parse(x.Substring(x.Length - 3, 3));

            if (ma >= 0 && ma < 9)
            {
                return "CV00" + (ma + 1).ToString();
            }
            else if (ma >= 9)
            {
                return "CV0" + (ma + 1).ToString();
            }
            else
                return "";
            }
        }


        public void xoa1cv(string macv)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                ChucVu cv = new ChucVu();
            cv = data.ChucVus.Where(t => t.MaCV == macv).FirstOrDefault();

            if (cv != null)
            {
                data.ChucVus.DeleteOnSubmit(cv);
                data.SubmitChanges();

            }
            }
        }


        public void them1cv(string macv, string tencv)
        {
            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                ChucVu cv = new ChucVu();
            cv.MaCV = macv;
            cv.TenCV = tencv;
            data.ChucVus.InsertOnSubmit(cv);
            data.SubmitChanges();
            }

        }
        public void sua1cv(string macv, string tencv)
        {

            using (ShopKidDataContext data = new ShopKidDataContext())
            {
                ChucVu cv = new ChucVu();
            cv = data.ChucVus.Where(t => t.MaCV == macv).FirstOrDefault();
            if (cv != null)
            {
                cv.TenCV = tencv;
                data.SubmitChanges();
            }
            }
        }

    }
}
