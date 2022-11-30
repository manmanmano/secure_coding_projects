namespace WebApp.Helpers;

public class CaesarHelper
{
    public static string EncryptText(string plaintext, int shiftAmount)
    {
        var plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext!);
        var encryptedBytes = new byte[plaintextBytes.Length];
        for (var i = 0; i < plaintextBytes.Length; i++)
        { 
            encryptedBytes[i] = (byte)(plaintextBytes[i] + shiftAmount % 255); 
        }
        
        return System.Convert.ToBase64String(encryptedBytes);
    }
}