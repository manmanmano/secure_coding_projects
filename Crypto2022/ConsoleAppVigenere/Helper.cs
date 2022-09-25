using System.Collections;

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

    
    private static void ValidateKeyLength(byte[] plaintextBytes, IList passphraseInts)
    {
        bool isEqual;
        int i = 0;
        do
        {
            isEqual = true;
            if (plaintextBytes.Length < passphraseInts.Count)
            {
                passphraseInts.RemoveAt(passphraseInts.Count - 1);
                isEqual = false;
            }
            else if (plaintextBytes.Length > passphraseInts.Count)
            {
                if (i == passphraseInts.Count)
                {
                    i = 0;
                }
                passphraseInts.Add(passphraseInts[i]);
                i++;
                isEqual = false;
            }

        } while (isEqual == false);
    }

    
    public static string EncryptText(string plaintext, string passphrase)
    {
        var plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext!);
        Console.Write("Plaintext bytes: ");
        // print out bytes of plaintext
        foreach (var b in plaintextBytes) Console.Write(b + " ");

        var passphraseBytes = System.Text.Encoding.UTF8.GetBytes(passphrase!);
        List<int> passphraseInts = new List<int>();
        // add passphraseBytes to list of int
        foreach (var b in passphraseBytes)
        {
            passphraseInts.Add(b);
        }
        Console.Write("\nPassphrase bytes: ");
        // print out bytes of passphrase
        foreach (var b in passphraseInts) Console.Write(b + " ");

        ValidateKeyLength(plaintextBytes, passphraseInts);
        Console.Write("\nPassphrase bytes after validation: ");
        // print out bytes of new validated passphrase
        foreach (var b in passphraseInts) Console.Write(b + " ");
        
        var shiftedBytes = new byte[plaintextBytes.Length];
        for (int i = 0; i < plaintextBytes.Length; i++)
        {
            shiftedBytes[i] = (byte)((plaintextBytes[i] + passphraseInts[i]) % 255);
        }
        // print out new bytes of shifted value
        Console.Write("\nPlaintext bytes after Vigenere encryption: ");
        foreach (var b in shiftedBytes) Console.Write(b + " ");

        var b64Text = System.Convert.ToBase64String(shiftedBytes);
        return b64Text; 
    }
    
}