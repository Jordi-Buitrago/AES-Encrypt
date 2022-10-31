using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AES
{
    internal class Xifrat
    {
        public static string Encrypt(string message, string pass, string salt)
        {
            //Aquesta funcio fa el cifrat i descifrat
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            //Aqui agafem sequencies de bytes del salt i la longitud que volem
            DeriveBytes rgb = new Rfc2898DeriveBytes(pass, Encoding.Unicode.GetBytes(salt), 9);
            //Determinem el congunt de tamany de la clau 
            byte[] key = rgb.GetBytes(aes.KeySize >> 3);
            //Determinem el congunt de tamany del cifrat de bloc
            byte[] iv = rgb.GetBytes(aes.BlockSize >> 3);
            //Especifiquem el mode de cifrat de bloc
            aes.Mode = CipherMode.CBC;
            aes.Key = key;
            aes.IV = iv;
            //Definim les operacions bàsiques i 
            ICryptoTransform encryptor = aes.CreateEncryptor();
            byte[] data = Encoding.Unicode.GetBytes(message);
            byte[] dataencrypt = encryptor.TransformFinalBlock(data, 0, data.Length);
            //retorna un array a String
            return Convert.ToBase64String(dataencrypt);
        }
        public static string Decrypt(string message, string pass, string salt)  
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            DeriveBytes rgb = new Rfc2898DeriveBytes(pass, Encoding.Unicode.GetBytes(salt), 9);
            byte[] key = rgb.GetBytes(aes.KeySize >> 3);
            byte[] iv = rgb.GetBytes(aes.BlockSize >> 3);
            aes.Mode = CipherMode.CBC;
            aes.Key = key;
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor();
            byte[] data = Convert.FromBase64String(message);
            byte[] datadecrypt = decryptor.TransformFinalBlock(data, 0, data.Length);
            return Encoding.Unicode.GetString(datadecrypt);
        }

    }
}
