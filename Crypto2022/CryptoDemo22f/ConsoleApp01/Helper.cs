namespace ConsoleApp01;

public class Helper
{
    public static string GetUserAlphabet(string defaultAlphabet)
    {
        bool isValidInput;
        string? userAlphabet;
        do
        {
            isValidInput = true;
            Console.Write($"Input your userAlphabet [{defaultAlphabet.ToString()}]: ");
            userAlphabet = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userAlphabet) || userAlphabet.Length == 1)
            {
                userAlphabet = defaultAlphabet;
            }

            var charSet = new HashSet<char>();

            foreach (var chr in userAlphabet)
            {
                if (charSet.Contains(chr))
                {
                    isValidInput = false;
                    Console.WriteLine($"Your userAlphabet is not unique - {chr}!");
                    break;
                }

                charSet.Add(chr);
            }
        } while (isValidInput == false);

        return userAlphabet;
    }

    public static int CheckNumbersInInput(string defaultShiftAmount)
    {
        var isInt = false;
        var shiftInInt = 0;
        while (isInt == false)
        {
            isInt = true;
            Console.Write($"Input your shift amount [{defaultShiftAmount.ToString()}]: ");
            var shiftAmount = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(shiftAmount) || shiftAmount == "0")
            {
                shiftAmount = defaultShiftAmount;
            }
            
            if (!int.TryParse(shiftAmount, out shiftInInt))
            {
                isInt = false;
                Console.WriteLine("Shift amount can only be an integer!");
            }
            
        } 
        
        return shiftInInt;
    }
}