namespace ConsoleApp01;

public class Helper
{
    private static void EndApplication(string userInput)
    {
        if (userInput.ToLower() == "exit")
        {
            Console.WriteLine("Exiting the application...");
            Environment.Exit(0);
        }
    }
    
    public static string GetUserAlphabet(string defaultAlphabet)
    {
        bool isValidInput;
        string? userAlphabet;
        do
        {
            isValidInput = true;
            Console.Write($"Input your userAlphabet [{defaultAlphabet.ToString()}] or type 'exit' to quit: ");
            userAlphabet = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(userAlphabet) || userAlphabet.Length == 1)
            {
                userAlphabet = defaultAlphabet;
            }
            
            EndApplication(userAlphabet);

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

    public static int CheckNumbersInInput(string defaultShiftAmount, int alphabetLength)
    {
        var isInt = false;
        var shiftInInt = 0;
        while (isInt == false)
        {
            isInt = true;
            Console.Write($"Input your shift amount [{defaultShiftAmount.ToString()}] or type 'exit' to quit: ");
            var shiftAmount = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(shiftAmount))
            {
                shiftAmount = defaultShiftAmount;
            }
            
            EndApplication(shiftAmount);

            if (!int.TryParse(shiftAmount, out shiftInInt))
            {
                isInt = false;
                Console.WriteLine("Shift amount can only be an integer!");
            }
            else if (shiftInInt == 0)
            {
                isInt = false;
                Console.WriteLine("Shift amount cannot be zero!");
            } else if (shiftInInt >= alphabetLength)
            {
                Console.WriteLine("Shift amount cannot be equal or bigger than the alphabet itself!");
                isInt = false;
            }

        } 
        
        return shiftInInt;
    }
}