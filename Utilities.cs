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
        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
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



    public static int ValidateCardNumbers()
    {
        while (true)
        {
            string kortnummerInput = Console.ReadLine();
            if (kortnummerInput.Length >= 5 && int.TryParse(kortnummerInput, out int kortnummer))
            {
                return kortnummer;
            }
            else
            {
                Console.WriteLine("Vänligen ange 5 siffror!");
            }
        }
    }

    public static int ValidatePin()
    {
        int countPin = 0;

        while (countPin < 3)
        {
            string pinInput = Console.ReadLine();

            if (pinInput.Length == 4 && int.TryParse(pinInput, out int pin))
            {
                return pin;
            }
            else
            {
                countPin++;
                Console.WriteLine("Ogiltig PIN. Var god försök igen.");
            }
        }


        Console.WriteLine("För många ogiltiga försök.");
        return -1;
    }

}