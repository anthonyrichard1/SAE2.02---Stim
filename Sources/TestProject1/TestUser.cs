using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestUser
    {
        [Fact]
        public void Constructor()
        {
            User user = new("username", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.NotNull(user);
        }

        [Fact]
        public void Username()
        {
            User user = new("", "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.Null(user.Username);

            User user2 = new(null, "biographie", "adresse.mail@gmail.com", "Azerty123*");
            Assert.Null(user.Username);
        }
    }
}
