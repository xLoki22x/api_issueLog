using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

public class Encode
{
    public static string hashPassword(string HashType, string pwd)
    {
        byte[] hash = null;
        StringBuilder digest = null;
        switch (HashType)
        {
            case "SHA1":
                SHA1 sha1 = SHA1CryptoServiceProvider.Create();
                hash = sha1.ComputeHash(Encoding.ASCII.GetBytes(pwd));
                digest = new StringBuilder();
                foreach (byte n in hash)
                {
                    digest.Append(Convert.ToInt32(n + 256).ToString("x2"));
                }
                break;
            case "SHA256":
                SHA256 sha256 = SHA256CryptoServiceProvider.Create();
                hash = sha256.ComputeHash(Encoding.ASCII.GetBytes(pwd));
                digest = new StringBuilder();
                foreach (byte n in hash)
                {
                    digest.Append(Convert.ToInt32(n + 256).ToString("x2"));
                }
                break;
            case "SHA384":
                SHA384 sha384 = SHA384CryptoServiceProvider.Create();
                hash = sha384.ComputeHash(Encoding.ASCII.GetBytes(pwd));
                digest = new StringBuilder();
                foreach (byte n in hash)
                {
                    digest.Append(Convert.ToInt32(n + 256).ToString("x2"));
                }
                break;
            case "SHA512":
                SHA512 sha512 = SHA512CryptoServiceProvider.Create();
                hash = sha512.ComputeHash(Encoding.ASCII.GetBytes(pwd));
                digest = new StringBuilder();
                foreach (byte n in hash)
                {
                    digest.Append(Convert.ToInt32(n + 256).ToString("x2"));
                }
                break;
            case "MD5":

                MD5 md5 = MD5CryptoServiceProvider.Create();
                hash = md5.ComputeHash(Encoding.ASCII.GetBytes(pwd));
                digest = new StringBuilder();
                foreach (byte n in hash)
                {
                    digest.Append(Convert.ToInt32(n + 256).ToString("x2"));
                }
                break;
            case "MD5I":
                Byte[] originalBytes;
                Byte[] encodedBytes;
                MD5 md5I;

                md5I = new MD5CryptoServiceProvider();
                originalBytes = ASCIIEncoding.Default.GetBytes(pwd);
                encodedBytes = md5I.ComputeHash(originalBytes);

                return BitConverter.ToString(encodedBytes);
        }
        return digest.ToString();
    }   
}

