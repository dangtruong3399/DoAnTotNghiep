using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dall_Ball;
namespace Dall_Ball
{
    public class FunctionDangNhap
    {
        DangNhap_Dall_Ball dn = new DangNhap_Dall_Ball();
        public bool CheckLogin(string username,string password)
        {
           
                if (dn.GetLogin(username, password).Count > 0)
                    return true;
                else
                    return false;
        }
        public string GetUserToMaNV(string username)
        {
            return dn.GetUserNV(username);

        }
        public string GetUserMaToMaNV(string username)
        {
            return dn.GetUserMaNV(username);

        }
    }

}
