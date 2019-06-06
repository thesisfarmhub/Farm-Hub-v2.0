using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmHub
{

    [Serializable]
    public class UserLoginSession
    {
        public long UserID { get; set; }
        public string UserName { get; set; }

    }
}