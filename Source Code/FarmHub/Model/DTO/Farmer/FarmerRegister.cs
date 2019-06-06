using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.Farmer
{
    public class FarmerRegister
    {
        public USER_AUTHENTICATION UserAu { get; set; }
        public FARMER Farmer { get; set; }
    }
}
