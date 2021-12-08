using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace NGC_219001683
{
    class Program
    {
        static void Main(string[] args)
        {
            //The First Part Of the Application
            BankClient bankClient = new BankClient(clientNum: 1, clientName: "Banko", balance: 130);
            Premeir premier = new Premeir(clientName: "Richie", clientNum: 2, balance: 120, invest: 5500);

            Console.WriteLine(bankClient.Display());
            Console.WriteLine(premier.Display());


            List<BankClient> bankClients = new List<BankClient>();
            bankClient.Withdrawal(50);
            premier.Withdrawal(50);


            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("This is the list of all the Clients From The Database");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------");


            List<BankClient> bClients = new List<BankClient>();
            GetClientData(bClients);
            Console.WriteLine(string.Format("{0, -5} {1, -12} {2, -8}{3,-8}","ID", "ClientName", "Balance", "Invest"));
            DisplayClient(bClients);


        }

       


        //The Second Part Of the Application
        public static void GetClientData(List<BankClient> bankClients)
        {
            string conString = @"Data Source = 143.128.146.30\ist3; User ID = ist3cg; Password = nv49ok; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection conn = new SqlConnection(conString);
            string sql = "SELECT * FROM [dbo].[BankClient]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "Client");
            DataTable dt = ds.Tables["Client"];

            foreach (DataRow drow in dt.Rows)
            {
                BankClient bclient = new BankClient();
                Premeir premier = new Premeir();
                if (drow[3] == null || drow[3].ToString() == string.Empty)
                {
                    bclient.ClientNum = int.Parse(drow[0].ToString());
                    bclient.ClientName = drow[1].ToString();
                    bclient.Balance = decimal.Parse(drow[2].ToString());
                    bankClients.Add(bclient);
                }
                else
                {
                    premier.ClientNum = int.Parse(drow[0].ToString());
                    premier.ClientName = drow[1].ToString();
                    premier.Balance = decimal.Parse(drow[2].ToString());
                    premier.Invest = decimal.Parse(drow[3].ToString());
                    bankClients.Add(premier);
                }

            }
        }

        public static void DisplayClient(List<BankClient> bankClients)
        {
            
            foreach (BankClient bankClient in bankClients)
            {
                Console.WriteLine(bankClient.Display());
            }
            Console.ReadLine();
        }

    }

}

