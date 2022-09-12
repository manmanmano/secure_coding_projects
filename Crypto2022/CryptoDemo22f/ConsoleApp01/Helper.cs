namespace ConsoleApp01;

public class Helper
{
    public static string GetUserAlphabet(string defaultAlphabet)
    {
        var isValidInput = true;
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
}