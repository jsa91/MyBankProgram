using System;
using System.Collections.Generic;
using System.Linq;

namespace MySuperBank
{
    public class MySuperBank
    {
        static void Main(string[] args)
        {
            BankAccount account = null;

            if (ReadWrite.ReadAllLines(out var transactions))
            {
                account = new BankAccount(transactions);
                Console.WriteLine(account.GetAccountHistory());
                Console.WriteLine($"Förra månadens återstående lön: {account.Balance}");
                Console.WriteLine("-------------------\n\n");
            }

            account = null;
            var salary = 0;
            while (true)
            {
                Console.WriteLine("'Enter' för att betala räkningar eller 'q' för att avsluta");
                var inputSalary = Console.ReadLine();

                if (inputSalary == "q")
                {
                    Environment.Exit(-1);
                }

                try
                {
                    Console.WriteLine("Ange din netto månadslön i [SEK]\n");
                    salary = Convert.ToInt32(Console.ReadLine());
                    account = new BankAccount(salary);
                    break;

                }
                catch (FormatException ex)
                {
                    // TODO: Never use try/catch as expected logic flow, performance is abyssmal and signals the wrong intent
                    // Not sure what this means.
                    Console.WriteLine($"FEL! Ange lönen i siffor utan specialtecken.");
                    Console.WriteLine(ex.ToString());
                }
            }

            while (true)
            {
                Console.WriteLine("'Enter' för att ange en kostnad eller 'q' för att lista kostnaderna och avsluta");
                var inputExpense = Console.ReadLine();

                if (inputExpense == "q")
                {
                    Console.WriteLine($"Avslutar...");
                    WriteOut();
                    account.WriteAllLines();
                    break;
                }
                try
                {
                    Console.WriteLine($"\nVilken var kostnaden?\n");
                    string note = Console.ReadLine();
                    Console.WriteLine($"\nAnge kostnaden i SEK\n");
                    int expense = Convert.ToInt32(Console.ReadLine());
                    account.MakeWithdrawal(expense, note);

                    WriteOut();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"FEL! Ange kostnaden i positiva heltal");
                    Console.WriteLine(ex.ToString());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"FEL! Ange kostanaden utan specialtecken");
                    Console.WriteLine(ex.ToString());
                }
            }

            void WriteOut()
            {
                Console.WriteLine(account.GetAccountInfo());
                Console.WriteLine($"Totala kostnader: {account.Balance - salary}");
                Console.WriteLine($"Återstående lön: {account.Balance}");
                Console.WriteLine("-------------------\n\n");
            }
        }
    }
}
