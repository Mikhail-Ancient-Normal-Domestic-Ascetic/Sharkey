using System;
using System.Linq;
using System.Security.Cryptography;
namespace Sharkey;

public class PasswordGenerator
{
    private const string Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

    public static string GeneratePassword(int length)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] bytes = new byte[length];
            rng.GetBytes(bytes);
            return new string(bytes.Select(b => Characters[b % Characters.Length]).ToArray());
        }
    }
}