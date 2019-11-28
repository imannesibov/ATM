using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM
{
    class User
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public Card CreditCard { get; set; }

        public string[] MoneyOperations = new string[100];
        public int OperationCount = -1;

        public void DisplayOperations()
        {
            if (OperationCount < 0)
            {
                Console.WriteLine("There is no any operation");
                Thread.Sleep(500);

            }
            else
            {
                
                for (int i = 1; i <= OperationCount + 1; i++)
                {
                    Console.WriteLine("Operation " + i+"\n");
                    Console.WriteLine(MoneyOperations[i-1]);
                }
            }
        }

        public override string ToString()
        {
            return $"Name : {Name}\nSurname : {Surname}\nPAN : {CreditCard.PAN}\nPIN : {CreditCard.PIN}\nCVC : {CreditCard.CVC}\nExpire Date : {CreditCard.ExpireDate.ToString("dd.MM.yyyy")}\nBalance : ${CreditCard.Balance} ";
        }

        public void DisplayUser()
        {
            Console.WriteLine(Name.ToString());
            Console.WriteLine(Surname.ToString());

        }

    }


}
