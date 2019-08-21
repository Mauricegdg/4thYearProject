using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ShopBasketWeb.Utils
{
    public class Common
    {
        //fuction to create random salt string
        public static byte[] GetRandomSalt(int length)
        {
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[length];
            random.GetNonZeroBytes(salt);
            return salt;
        }
        // function to create password with salt
        public static byte[] SaltHashPassword(byte[] password,byte[] salt)
        {
            HashAlgorithm alg = new SHA256Managed();
            byte[] plainTextWithSaltBytes = new byte[password.Length + salt.Length];
            for (int i = 0; i < password.Length; i++)
            {
                plainTextWithSaltBytes[i] = password[i];

            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[password.Length + 1] = salt[i];
            }
            return alg.ComputeHash(plainTextWithSaltBytes);
        }
    }
}
