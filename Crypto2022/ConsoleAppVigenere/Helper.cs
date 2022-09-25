namespace ConsoleAppVigenere;


public class Helper
{
    public static string GetPlaintext()
    {
        bool isEmpty;
        string? plaintext;
        do
        {
            plaintext = Console.ReadLine();
            isEmpty = false;
            if (string.IsNullOrWhiteSpace(plaintext))
            {
                Console.Write("Plaintext cannot be an empty string!\nPlaintext: ");
                isEmpty = true;
            }
        } while (isEmpty == true);

        return plaintext;
    }
    
    
    public static string GetPassphrase()
    {
        bool isEmpty;
        string? passphrase;
        do
        {
            passphrase = Console.ReadLine();
            isEmpty = false;
            if (string.IsNullOrWhiteSpace(passphrase))
            {
                Console.Write("Passphrase cannot be an empty string!\nPassphrase: ");
                isEmpty = true;
            }
        } while (isEmpty == true);

        return passphrase;
    }

    
    public static string EncryptText(string plaintext, string passphrase)
    {
        var plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext!);
        Console.Write("Bytes for plaintext: ");
        foreach (var b in plaintextBytes) Console.Write(b + " ");

        var passphraseBytes = System.Text.Encoding.UTF8.GetBytes(passphrase!);
        Console.Write("\nBytes for passphrase: ");
        foreach (var b in passphraseBytes) Console.Write(b + " ");

        var shiftedBytes = new byte[plaintextBytes.Length];
        for (int i = 0; i < plaintextBytes.Length; i++)
        {
            shiftedBytes[i] = (byte)((plaintextBytes[i] + passphraseBytes[i]) % 255);
        }
        Console.Write("\nBytes after shifting with Vigenere: ");
        foreach (var b in shiftedBytes) Console.Write(b + " ");

        var b64Text = System.Convert.ToBase64String(shiftedBytes);
        return b64Text;
    }
}