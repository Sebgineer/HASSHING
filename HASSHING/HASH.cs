using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HASSHING
{
    internal class HASH
    {
        private HMAC hMAC;

        public void setHmac(string name){
            switch (name)
            {
                case "MD5":
                    this.hMAC = new HMACMD5();
                    break;
                case "SHA1":
                    this.hMAC = new HMACSHA1();
                    break;
                case "SHA256":
                    this.hMAC = new HMACSHA256();
                    break;
            }

        }

        public byte[] randomKey()
        {
            RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
            byte[] key = new byte[4];
            rnd.GetBytes(key);
            return key;

        }

        public byte[] Hashing(byte[] message, byte[] key)
        {
            hMAC.Key = key;
            return hMAC.ComputeHash(message);
        }
    }
}
