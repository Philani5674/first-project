using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGC_219001683
{
    class Premeir: BankClient
    {
        public decimal Invest { get; set; }
        public Premeir()
        {

        }

        public Premeir(int clientNum, string clientName, decimal balance, decimal invest)
        {
            ClientName = clientName;
            ClientNum = clientNum;
            Balance = balance;
            Invest = invest;
        }

        public override string Display()
        {
            return string.Format("{0, -5} {1, -12} {2, -8} {3, -8}", ClientNum, ClientName, Balance, $"Premier: {Invest}");
        }


        public override void Withdrawal(decimal amt)
        {
            if (Invest > 5000)
            {
                decimal b = Balance - amt;
                Console.WriteLine($"Transaction Successful -------------- The new balance for {ClientName} is {b}");
            }
            else if (Balance - 100 - amt < 100)
            {
                Console.WriteLine("Cancelled, balance cannot be less than 100");
            }
            else
            {
                Console.WriteLine("Transaction was a success");
            }
        }
    }
}
