using ConsoleApp01;

Console.WriteLine("Hello, World!");

string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!?.";

var alphabet = Helper.GetUserAlphabet(defaultAlphabet);

Console.WriteLine(alphabet);

Console.Write("Caesar shift amount: ");
var shiftAmount = Console.ReadLine();