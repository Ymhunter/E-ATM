using System;
using System.Collections.Generic;

namespace EATMNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            bool huvudMeny = true;

            while (huvudMeny)
            {
            Console.Clear();
            Console.WriteLine("*********************************");
            Console.WriteLine("Välkommen till E-ATM");
            Console.WriteLine("*********************************"); 
            Console.WriteLine("Välj ett val nedan:");
            Console.WriteLine("1. Registrering kort ");
            Console.WriteLine("2. Visa penger");
            Console.WriteLine("3. instätta penger");
            Console.WriteLine("4. utsätta penger");
            Console.WriteLine("5. Visa transaktionshistorik");
            Console.WriteLine("Q. Avslutas programmet");
            
            string val = Utilities.ValidateString();
            switch (val)
            {
                case "1":
                    atm.InputCardDetails();
                    break;

                case "2":
                    atm.ShowBalance();
                    break;

                case "3":
                    atm.MakeDeposit();
                    break;

                case "4":
                    atm.MakeWithdrawal();
                    break;


                 case "5":
                    atm.ShowTransactionHistory();
                    break;

               
                
                case "Q":
                    Console.WriteLine("Programmet avslutas...");
                    Thread.Sleep(2000);
                    huvudMeny = false;
                    break;
                default:
                    Console.WriteLine("Ogiltlig inmatning! ");
                    break;
    }
            }
       }
    }

}