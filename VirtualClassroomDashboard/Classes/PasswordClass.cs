using System;
using System.Security.Cryptography;
using System.Text;

namespace VirtualClassroomDashboard.Classes
{
    public class PasswordClass
    {
        //mixture of https://blog.securityinnovation.com/blog/2011/03/how-to-hash-and-salt-passwords-in-aspnet.html & https://entityframework.net/knowledge-base/39802164/asp-net-mvc---how-to-hash-password

        //size of salt to generate a salt val
        private const int SizeOfSalt = 32;

        public static string SaltGeneration()
        {
                //using an instance to the object 
            using(RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                    //generate a cryptographic random number of byte type using the salt size
                byte[] buff = new byte[SizeOfSalt];
                rng.GetBytes(buff);

                    //return a string version of the random number
                return Convert.ToBase64String(buff);
            }
        }

        public static string HashPassword(string salt, string pass)
        {
                //concatonate the salt and the password to get a new password
            string newPass = salt + pass;
           
                //create an instance of the object to hash the password
            HashAlgorithm PassHash = new SHA256CryptoServiceProvider();

                //convert to array of bytes
            byte[] bVal = Encoding.UTF8.GetBytes(newPass);
                
                //compute hash and return array of bytes
            byte[] bHashVal = PassHash.ComputeHash(bVal);

                //hash value as an encoded string
            return Convert.ToBase64String(bHashVal);
        }
        public static bool VerifyPassword(string pass, string hash, string salt)
        {
            string hash2 = HashPassword(salt, pass);

            if (hash == hash2)
                return true;
            return false;
        }
    }
}
