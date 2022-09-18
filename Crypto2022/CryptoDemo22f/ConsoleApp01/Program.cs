using ConsoleApp01;

Console.WriteLine("Hello, Caesar!");

string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!?.";
string defaultShiftAmount = "3";

var alphabet = Helper.GetUserAlphabet(defaultAlphabet);

Console.WriteLine(alphabet);

Console.Write("Caesar shift amount: ");

var shiftAmount = Helper.CheckNumbersInInput(defaultShiftAmount, alphabet.Length);

Console.WriteLine(shiftAmount);