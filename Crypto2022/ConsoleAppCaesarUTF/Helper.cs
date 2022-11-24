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
                Console.Write("Plaintext cannot be an empty string!\nPlaintext: ");
                isEmpty = true;
            }
        } while (isEmpty == true);

        return plaintext;
    }

    public static int ValidateShiftAmount()
    {
        var isInt = false;
        var shiftInInt = 0;
        while (isInt == false)
        { 
            isInt = true;
            Console.Write("Input your shift amount: ");
            var shiftAmount = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(shiftAmount))
            {
                Console.WriteLine("Shift amount cannot be left empty!");
                isInt = false;
            }

            if (!int.TryParse(shiftAmount, out shiftInInt))
            {
                isInt = false;
                Console.WriteLine("Shift amount can only be an integer!");
            }
            else if (shiftInInt == 0)
            {
                isInt = false;
                Console.WriteLine("Shift amount cannot be zero!");
            }
        } 
        
        return shiftInInt;
    }

    public static byte[] ShiftBytes(byte[] plaintextBytes, int shiftAmount)
    {
        var encryptedBytes = new byte[plaintextBytes.Length];
        for (int i = 0; i < plaintextBytes.Length; i++)
        { 
            encryptedBytes[i] = (byte)(plaintextBytes[i] + shiftAmount % 255); 
        }

        return encryptedBytes;
    }

    public static byte[] UnshiftBytes(byte[] shiftedBytes, int shiftAmount)
    {
        var unshiftedBytes = new byte[shiftedBytes.Length];
        for (int i = 0; i < shiftedBytes.Length; i++)
        {
            unshiftedBytes[i] = (byte)(shiftedBytes[i] - shiftAmount % 255);
        }

        return unshiftedBytes;
    }
}