namespace ConsoleAppCaesarUTF;

public class Helper
{
    public static string? GetPlaintext()
    {
        bool isEmpty;
        string? plaintext;
        do
        {
            plaintext = Console.ReadLine();
            isEmpty = false;
            if (string.IsNullOrWhiteSpace(plaintext))
            {
                isEmpty = true;
            }
        } while (isEmpty == true);

        return plaintext;
    }
}