using ConsoleApp01;

Console.WriteLine("Hello, Caesar!");

string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!?.";
string defaultShiftAmount = "3";

var alphabet = Helper.GetUserAlphabet(defaultAlphabet);

Console.WriteLine(alphabet);

// TODO: write a function that takes input and check that the user only writes numbers
// look into int.TryParse(), no chars, no symbols, no zero, input must be smaller than alphabets
Console.Write("Caesar shift amount: ");

var shiftAmount = Helper.CheckNumbersInInput(defaultShiftAmount);

Console.WriteLine(shiftAmount);