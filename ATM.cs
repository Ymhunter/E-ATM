class ATM
{

    List<CardInfo> cardInfoList = new List<CardInfo>();
    List<DepositTransaction> depositTransactions = new List<DepositTransaction>();
    List<WithdrawalTransaction> withdrawalTransactions = new List<WithdrawalTransaction>();


    public void InputCardDetails()
    {

        Console.WriteLine("Skriv ditt kortnummer (minst 5 siffror):");
        int kortnummerInput = Utilities.ValidateCardNumbers();


        Console.WriteLine("Skriv ditt PIN (bara 4 siffror):");
        int pinInput = Utilities.ValidatePin();

        Console.WriteLine("Kortnummer och PIN-kod accepterade!");
        CardInfo newCard = new CardInfo(kortnummerInput, pinInput);
        cardInfoList.Add(newCard);





    }
    public void ShowBalance()
    {

        Console.WriteLine("Skriv ditt kortnummer (minst 5 siffror):");
        int kortnummerInput = Utilities.ValidateCardNumbers();

        Console.WriteLine("Skriv ditt PIN (4 siffror):");
        int pinInput = Utilities.ValidatePin();

        Console.WriteLine("Kortnummer och PIN-kod accepterade!");
        CardInfo newCard = new CardInfo(kortnummerInput, pinInput);
        cardInfoList.Add(newCard);

        int totalInsättningar = 0;
        int totalUtsättningar = 0;

        foreach (var insättning in depositTransactions)
        {
            if (insättning.CardNumber == kortnummerInput && insättning.Pin == pinInput)
            {
                totalInsättningar += insättning.Amount;
            }
        }

        foreach (var uttag in withdrawalTransactions)
        {
            if (uttag.CardNumber == kortnummerInput && uttag.Pin == pinInput)
            {
                totalUtsättningar += uttag.Amount;
            }
        }

        int aktuellSaldo = totalInsättningar - totalUtsättningar;
        Console.WriteLine($"Din saldo: {aktuellSaldo} kronor.");
        Console.ReadKey();
    }


    public void MakeDeposit()
    {
        Console.WriteLine("Skriv ditt kortnummer (minst 5 siffror):");
        int kortnummerInput = Utilities.ValidateCardNumbers();


        Console.WriteLine("Skriv ditt PIN (bara 4 siffror):");
        int pinInput = Utilities.ValidatePin();

        Console.WriteLine("Kortnummer och PIN-kod accepterade!");
        CardInfo newCard = new CardInfo(kortnummerInput, pinInput);
        cardInfoList.Add(newCard);


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
                    DepositTransaction newInsätta = new DepositTransaction(antalInsättning, kortnummerInput, pinInput);
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
        Console.ReadKey();
    }

    public void MakeWithdrawal()
    {
        Console.WriteLine("Skriv ditt kortnummer (minst 5 siffror):");
        int kortnummerInput = Utilities.ValidateCardNumbers();


        Console.WriteLine("Skriv ditt PIN (bara 4 siffror):");
        int pinInput = Utilities.ValidatePin();

        Console.WriteLine("Kortnummer och PIN-kod accepterade!");
        CardInfo newCard = new CardInfo(kortnummerInput, pinInput);
        cardInfoList.Add(newCard);


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
                        if (penger.CardNumber == kortnummerInput && penger.Pin == pinInput)
                        {
                            totalInsättningar += penger.Amount;
                        }
                    }


                    foreach (WithdrawalTransaction pengerUt in withdrawalTransactions)
                    {
                        if (pengerUt.CardNumber == kortnummerInput && pengerUt.Pin == pinInput)
                        {
                            totalUtsättningar += pengerUt.Amount;
                        }
                    }


                    int aktuellSaldo = totalInsättningar - totalUtsättningar;

                    if (aktuellSaldo >= antalUtsättning)
                    {
                        WithdrawalTransaction newUtsätta = new WithdrawalTransaction(antalUtsättning, kortnummerInput, pinInput);
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



    public void ShowTransactionHistory()
    {

        Console.WriteLine("Skriv ditt kortnummer (minst 5 siffror):");
        int kortnummerInput = Utilities.ValidateCardNumbers();

        Console.WriteLine("Skriv ditt PIN (4 siffror):");
        int pinInput = Utilities.ValidatePin();

        Console.WriteLine("Kortnummer och PIN-kod accepterade!");
        CardInfo newCard = new CardInfo(kortnummerInput, pinInput);
        cardInfoList.Add(newCard);


        foreach (DepositTransaction transaktionIn in depositTransactions)
        {
            Console.WriteLine($"{transaktionIn.Amount} var insättad");
        }

        foreach (WithdrawalTransaction transaktionUt in withdrawalTransactions)
        {

            Console.WriteLine($"{transaktionUt.Amount} var utsättad");
        }
        Console.ReadKey();
    }

}



