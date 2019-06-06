using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.Trader
{
    public class Register
    {
        public USER_AUTHENTICATION UserAu { get; set; }
        public TRADER trader { get; set; }
        public FARMER farmer { get; set; }
    }
}
