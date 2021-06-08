using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dall_Ball.DTO
{
   public  class DMformDTO
    {
        private string _TenFrm;
        private string _IDform;
            public string TenFrm { get => _TenFrm; set => _TenFrm = value; }
        public string IDform { get => _IDform; set => _IDform = value; }
    }
}
