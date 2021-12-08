using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGC_219001683
{
    interface IClient
    {
        void Deposit(decimal amt);
        void Withdrawal(decimal amt);
    }
}
