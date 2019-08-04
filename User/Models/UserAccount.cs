using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Models
{
    public class UserAccount
    {
        public UserAccount()
        {
            Detail = new Detail();
        }
        public string UserId { get; set; }

        public Detail Detail { get; set; }
    }
}
