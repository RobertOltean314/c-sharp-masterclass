ProccessString myString = CustomToUpper;

Print print1 = text => Console.WriteLine(text.ToUpper());
Print print2 = text => Console.WriteLine(text.ToLower());
Print multicast = print1 + print2;

multicast("Crocodile");


string CustomToUpper(string input)
{
    return input.ToUpper();
}

delegate string ProccessString(string input);

delegate void Print(string input);