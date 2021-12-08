using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGC_219001683
{
    class BankClient : IComparable, IClient
    {
        public decimal Balance { get; set; }
        public string ClientName { get; set; }
        public int ClientNum { get; set; }

        public BankClient()
        {

        }
        public BankClient(decimal balance, string clientName, int clientNum)
        {
            Balance = balance;
            ClientName = clientName;
            ClientNum = clientNum;
        }
        public int CompareTo(object P)
        {
            BankClient NgcamuP = (BankClient)P;
            if(this.Balance>NgcamuP.Balance)
            {
                return 1;
            }
            else
            {
                return -1;

            }
            

        }

        public void Deposit(decimal amt)
        {
            Balance += amt;
            Console.WriteLine($"The new deposit is {Balance}");
        }
        public virtual void Withdrawal(decimal amt)
        {
            if (Balance - amt < 100)
            {
                Console.WriteLine(ClientName + " " + "Transaction Cancelled, balance cannot be less than 100");
            }
            else
            {
                Console.WriteLine("Transaction was a success");
            }
        }
        public virtual string Display()
        {
            return string.Format("{0, -5} {1, -12} {2, -8}", ClientNum, ClientName, Balance);
        }
    }
}
