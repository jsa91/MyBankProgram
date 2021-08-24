using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Configuration;

namespace MySuperBank
{
    public class BankAccount
    {
        public int Balance
        {
            get => allTransactions.Sum(item => item.Amount);
        }

        public List<Transaction> allTransactions = new();

        public BankAccount(int initialBalance)
        {
            MakeDeposit(initialBalance, "Lön\n");
        }

        public BankAccount(IEnumerable<Transaction> transactions)
        {
            allTransactions = transactions.ToList();
        }

        public void MakeDeposit(int amount, string note)
        {
            var deposit = new Transaction(amount, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(int amount, string note)
        {
            var withdrawal = new Transaction(-amount, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountInfo()
        {
            var report = new StringBuilder();
            DateTime dateTime = DateTime.Now;

            //HEADER
            Console.WriteLine("\n\n-------------------");
            Console.WriteLine("{0}", dateTime);
            report.AppendLine("Summa\tUtgift\n");
            foreach (var item in allTransactions)
            {
                //ROWS
                report.AppendLine($"{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }
        public string GetAccountHistory()
        {
            var report = new StringBuilder();


            //HEADER
            Console.WriteLine("\n\nFörra månadens intäkter och kostnader");
            Console.WriteLine("-------------------");
            report.AppendLine("Summa\tUtgift\n");
            foreach (var item in allTransactions)
            {
                //ROWS
                report.AppendLine($"{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }
        public string Json()
        {
            string json = JsonSerializer.Serialize(allTransactions);
            return json;
        }
    }
}