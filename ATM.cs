 class ATM
{
  
            List<CardInfo> cardInfoList = new List<CardInfo>();
            List<DepositTransaction> depositTransactions = new List<DepositTransaction>();
            List<WithdrawalTransaction> withdrawalTransactions  = new List<WithdrawalTransaction>();
            private DateTime brottTidpunkt;
   
    
    
 public void InputCardDetails()
{
    bool validCard = false;
    while (!validCard)
    {
        Console.WriteLine("Skriv ditt kortnummer (minst 5 siffror):");
        string kortnummerInput = Console.ReadLine();

        if (kortnummerInput.Length >= 5 && int.TryParse(kortnummerInput, out int kortnummer))
        {
            Console.WriteLine("Skriv ditt PIN (bara 4 siffror):");
            string pinInput = Console.ReadLine();

            if (pinInput.Length == 4 && int.TryParse(pinInput, out int pin))
            {
                Console.WriteLine("Kortnummer och PIN-kod accepterade!");
                CardInfo newCard = new CardInfo(kortnummer, pin);
                cardInfoList.Add(newCard);
                validCard = true; 
            }
            else
            {
                Console.WriteLine("Ogiltig PIN. Var god försök igen.");
            }
        }
        else
        {
            Console.WriteLine("Ogiltigt kortnummer. Var god försök igen.");
        }
    }
}
public void ShowBalance()
{
    bool validCard = false;

    while (!validCard)
    {
        Console.WriteLine("Skriv ditt kortnummer (minst 5 siffror):");
        string kortnummerInput = Console.ReadLine();

        if (kortnummerInput.Length >= 5 && int.TryParse(kortnummerInput, out int kortnummer))
        {
            int countPin = 0;
            bool validPin = false;

            while (countPin < 3)
            {
                Console.WriteLine("Skriv ditt PIN (4 siffror):");
                string pinInput = Console.ReadLine();

                if (pinInput.Length == 4 && int.TryParse(pinInput, out int pin))
                {
                    validPin = true;

                   
                    int totalInsättningar = 0;
                    int totalUtsättningar = 0;

                    foreach (var insättning in depositTransactions)
                    {
                        if (insättning.CardNumber == kortnummer && insättning.Pin == pin)
                        {
                            totalInsättningar += insättning.Amount; 
                        }
                    }

                    foreach (var uttag in withdrawalTransactions)
                    {
                        if (uttag.CardNumber == kortnummer && uttag.Pin == pin)
                        {
                            totalUtsättningar += uttag.Amount;
                        }
                    }

                    int aktuellSaldo = totalInsättningar - totalUtsättningar;
                    Console.WriteLine($"Din saldo: {aktuellSaldo} kronor.");
                    validCard = true; 
                    break;
                }
                else
                {
                    countPin++;
                    if (countPin >= 3)
                    {
                        Console.WriteLine("För många misslyckade försök. Åtkomst nekad.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig PIN. Var god försök igen.");
                    }
                }
            }

            if (!validPin) break;
        }
        else
        {
            Console.WriteLine("Ogiltigt kortnummer. Var god försök igen.");
        }
    }
    Console.ReadKey();
}


    public void MakeDeposit()
    {
        bool validCard = false;

        while (!validCard)
        {
            Console.WriteLine("Skriv ditt kortnummer (minst 5 siffror):");
            string kortnummerInput = Console.ReadLine();

            if (kortnummerInput.Length >= 5 && int.TryParse(kortnummerInput, out int kortnummer))
            {
                validCard = true;

                int countPin = 0;
                bool validPin = false;

                while (!validPin && countPin < 3)
                {
                    Console.WriteLine("Skriv ditt PIN (bara 4 siffror):");
                    string pinInput = Console.ReadLine();

                    if (pinInput.Length == 4 && int.TryParse(pinInput, out int pin))
                    {
                        Console.WriteLine("Kortnummer och PIN-kod accepterade!");
                        CardInfo newCard = new CardInfo(kortnummer, pin);
                        cardInfoList.Add(newCard);
                        validPin = true;
                 
                        while (true)
                        {
                            Console.WriteLine("Hur mycket vill du insätta? (Skriv 0 för att avsluta)");
                            if (int.TryParse(Console.ReadLine(), out int antalInsättning))
                            {
                                if (antalInsättning == 0)
                                {
                                    Console.WriteLine("Insättning avslutad.");
                                    break;
                                }
                                else if (antalInsättning > 0)
                                {
                                    DepositTransaction newInsätta = new DepositTransaction(antalInsättning, kortnummer, pin);
                                    depositTransactions.Add(newInsätta);
                                    Console.WriteLine($"Du har satt in {antalInsättning} kronor.");
                                }
                                else
                                {
                                    Console.WriteLine("Ogiltigt belopp. Försök igen.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltig inmatning. Försök igen.");
                            }
                        }
                    }
                    else
                    {
                        countPin++;
                        Console.WriteLine("Ogiltig PIN. Var god försök igen.");

                        if (countPin >= 3)
                        {
                            Console.WriteLine("För många försök. Åtkomst nekad.");
                            break;
                        }
                    }
                }

                if (validPin)
                    break;
            }
            else
            {
                Console.WriteLine("Ogiltigt kortnummer. Var god försök igen.");
            }
        }
        Console.ReadKey();
    }

    public void MakeWithdrawal()
{
    bool validCard = false;

    while (!validCard)
    {
        Console.WriteLine("Skriv ditt kortnummer (minst 5 siffror):");
        string kortnummerInput = Console.ReadLine();

        if (kortnummerInput.Length >= 5 && int.TryParse(kortnummerInput, out int kortnummer))
        {
            validCard = true;

            int countPin = 0;
            bool validPin = false;

            while (!validPin && countPin < 3)
            {
                Console.WriteLine("Skriv ditt PIN (bara 4 siffror):");
                string pinInput = Console.ReadLine();

                if (pinInput.Length == 4 && int.TryParse(pinInput, out int pin))
                {
                    Console.WriteLine("Kortnummer och PIN-kod accepterade!");
                    CardInfo newCard = new CardInfo(kortnummer, pin);
                    cardInfoList.Add(newCard);
                    validPin = true;

                    while (true)
                    {
                        Console.WriteLine("Hur mycket vill du utsätta? (Skriv 0 för att avsluta)");
                        if (int.TryParse(Console.ReadLine(), out int antalUtsättning))
                        {
                            if (antalUtsättning == 0)
                            {
                                Console.WriteLine("Utsättning avslutad.");
                                break;
                            }
                            else if (antalUtsättning > 0)
                            {
                         
                                int totalInsättningar = 0;
                                int totalUtsättningar = 0;

                                foreach (DepositTransaction penger in depositTransactions)
                                {
                                    if (penger.CardNumber == kortnummer && penger.Pin == pin)
                                    {
                                        totalInsättningar += penger.Amount;
                                    }
                                }

                                
                                foreach (WithdrawalTransaction pengerUt in withdrawalTransactions)
                                {
                                    if (pengerUt.CardNumber == kortnummer && pengerUt.Pin == pin)
                                    {
                                        totalUtsättningar += pengerUt.Amount;
                                    }
                                }

                                
                                int aktuellSaldo = totalInsättningar - totalUtsättningar;

                                if (aktuellSaldo >= antalUtsättning)
                                {
                                    WithdrawalTransaction newUtsätta = new WithdrawalTransaction(antalUtsättning, kortnummer, pin);
                                    withdrawalTransactions.Add(newUtsätta);
                                    Console.WriteLine($"Du har tagit ut {antalUtsättning} kronor.");
                                }
                                else
                                {
                                    Console.WriteLine("Otillräckligt saldo. Utsättning nekad.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt belopp. Försök igen.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltig inmatning. Försök igen.");
                        }
                    }
                }
                else
                {
                    countPin++;
                    Console.WriteLine("Ogiltig PIN. Var god försök igen.");

                    if (countPin >= 3)
                    {
                        Console.WriteLine("För många försök. Åtkomst nekad.");
                        break;
                    }
                }
            }

            if (validPin)
                break;
        }
        else
        {
            Console.WriteLine("Ogiltigt kortnummer. Var god försök igen.");
        }
    }
    Console.ReadKey();
}



public void ShowTransactionHistory()
{
  bool validCard = false;
    while (!validCard)
    {
        Console.WriteLine("Skriv ditt kortnummer (minst 5 siffror):");
        string kortnummerInput = Console.ReadLine();

        if (kortnummerInput.Length >= 5 && int.TryParse(kortnummerInput, out int kortnummer))
        {
            Console.WriteLine("Skriv ditt PIN (bara 4 siffror):");
            string pinInput = Console.ReadLine();

            if (pinInput.Length == 4 && int.TryParse(pinInput, out int pin))
            {
                Console.WriteLine("Kortnummer och PIN-kod accepterade!");
                validCard = true;



                foreach(DepositTransaction transaktionIn in depositTransactions)
                {
                    Console.WriteLine($"{transaktionIn.Amount} var insättad");
                }

                foreach(WithdrawalTransaction transaktionUt in withdrawalTransactions)
                    {
                   
                    Console.WriteLine($"{transaktionUt.Amount} var utsättad");
                    }
            
            }
            else
            {
                Console.WriteLine("Ogiltig PIN. Var god försök igen.");
            }
        }
        else
        {
            Console.WriteLine("Ogiltigt kortnummer. Var god försök igen.");
        }
    }
    Console.ReadKey();
}

}



