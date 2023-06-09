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


    public static void ValidateKeyLength(byte[] plaintextBytes, IList passphraseInts)
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
}