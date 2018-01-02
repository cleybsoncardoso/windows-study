using firebaseApplication.email;
using firebaseApplication.password;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace firebaseApplication.model
{
    public class Passwords
    {
        string login;
        string password;

        //variables to generate the password hash
        string PasswordHash = "P@SSw0rd";
        string SaltKey = "S@LT&KEYcrypt";
        string VIKey = "@1B2c3D4e5F6g7H8";

        public Passwords(string login, string password)
        {
            if (login == null || login.Equals(""))
            {
                throw new ExceptionEmail();
            } else if(password == null || password.Length < 4)
            {
                throw new ExceptionPasswordLength();
            }
            this.login = login;
            this.password = password;
        }



        //method for create hash of password
        //return object with password encrypted
        //
        public Passwords encrypt()
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(this.password);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            //variables to salve hash of password
            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            //convert hash of password in byte to base64
            this.password =  Convert.ToBase64String(cipherTextBytes);
            return this;
        }

        //Decrypt password 
        public string decrypt()
        {
            //Decrypt base64 to hash of password in byte
            byte[] cipherTextBytes = Convert.FromBase64String(this.password);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        public string[] ToArray()
        {
            return new string[2] { this.login, this.password }; ;
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
    }
}
