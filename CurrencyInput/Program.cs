Console.WriteLine("Monetary Value Parser");

decimal targetDecimal;
bool isInputDone = false;

while (!isInputDone)
{
    Console.WriteLine("Please, type in amount between zero and two billion.");
    Console.Write("Type in amount: ");
    if (decimal.TryParse(Console.ReadLine()?.Replace(".", ","), out targetDecimal))
    {
        if (targetDecimal >= 2000000000)
        {
            Console.WriteLine("Amount should be less than 2 billion!");
            continue;
        }

        if (targetDecimal < 0)
        {
            Console.WriteLine("Amount should be higher than zero!");
            continue;
        }

        try
        {
            Console.WriteLine("Your amount is " + new CurrencyInput.CurrencyParser(targetDecimal).GetParsed());
            isInputDone = true;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Parsing error: \n" + ex.ToString());
        }
    }
    else
    {
        Console.WriteLine("Invalid Input");
    }
}

Console.WriteLine("Thank you for using the program. Made by Anton Polovnikov 2022.");
Console.ReadLine();