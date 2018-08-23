using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Token.Password
{
    public class PasswordManager
    {
        public string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }

        public string HashPassword(string password, string salt, string loginname)
        {
            return BCrypt.Net.BCrypt.HashPassword(this.ProcessPassword(password, loginname), salt);
        }

        public bool CheckPassword(string hashPassword, string password, string salt, string loginname)
        {
            string validPassword = BCrypt.Net.BCrypt.HashPassword(this.ProcessPassword(password, loginname), salt);
            return (hashPassword == validPassword);
        }

        private string ProcessPassword(string password, string loginname)
        {
            return String.Join("", password, loginname, "!@#~$%&*()<>,.#@!");
        }
    }
}
