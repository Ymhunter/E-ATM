class Utilities
{
    public static int ValidateInteger()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Vänligen ange ett nummer!");
            }
        }
    }
    public static string ValidateString()
    {
        while(true)
        {
            string input = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Du kan inte skriva blanksteg..");
            }
            else
            {
                return input;
            }
        }
    }

    public static DateTime ValidateDatetime()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (!DateTime.TryParse(input, out DateTime dateTime))
            {
                Console.WriteLine("Felaktigt inskrivning av datum!");
            }
            else
            {
                return dateTime;
            }
        }
    }
}