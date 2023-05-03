using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stim_Model
{
    internal class Administrateur : User
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

        public Administrateur(string username, string biographie, string email, string password, int perm)
            : base(username, biographie, email, password)
        {
            Permission = perm;
        }
    }
}
