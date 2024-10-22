using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents
{
    public class AuthorizedUser
    {
        private static AuthorizedUser instance;
        public AuthorizedUser()
        {
           
        }
        public Person AuthorizedPerson { get; set; }
        public static bool IsAdmin { get; set; } = false;
        public void CheckIsAdmin()
        {
            if (AuthorizedPerson != null)
            {
                if (AuthorizedPerson.Password == "r" && AuthorizedPerson.Login == "raf")
                    IsAdmin = true;
            }
            return;
        }
        public static AuthorizedUser GetInstance()
        {
            if (instance == null)
                instance = new AuthorizedUser();
            return instance;

        }
    }
}
