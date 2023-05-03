using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Admin : User
    {
        public int Permission
        {
            get { return permission; } 
            private set
            {
                permission = value;
            }
        }
        private int permission;

        public Admin(string username, string biographie, string email, string password, int perm)
            : base(username, biographie, email, password)
        {
            Permission = perm;
        }
    }
}
