using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM
{
    class Manager
    {

        public static int UserNumb(User[] user, string pan, string pin)
        {

            for (int i = 0; i < user.Length; i++)
            {
                if (user[i].CreditCard.PAN == pan && user[i].CreditCard.PIN == pin)
                {
                    return i;
                }
            }
            return -1;
        }

        public static string GetCash(User[] user, int index, int amount)
        {

            if (amount > user[index].CreditCard.Balance)
            {
                Console.WriteLine("Not enough money");
                Thread.Sleep(500);
                return "";
            }
            else
            {
                user[index].CreditCard.Balance -= amount;
                return "Withdraw operation(s)\n\n" + "Amount : $" + amount.ToString() + "\nDate : " + user[index].CreditCard.ExpireDate.ToString() + "\n====================================\n";
            }

        }



        public static string TransferTo(User[] sender, User[] receiver, int indexOfsender, int indexOfreceiver, int amount)
        {

            if (indexOfreceiver < 0)
            {
                Console.WriteLine("Wrong detail");
                Thread.Sleep(500);
                return "";

            }
            if (indexOfsender == indexOfreceiver)
            {
                Console.WriteLine("You cannot transfer money to yourself");
                Thread.Sleep(600);
                return "";
            }
            if (sender[indexOfsender].CreditCard.Balance < amount)
            {
                Console.WriteLine("Not enough money");
                Thread.Sleep(500);
                return "";
            }
            else
            {
                sender[indexOfsender].CreditCard.Balance -= amount;
                receiver[indexOfreceiver].CreditCard.Balance += amount;

                Console.WriteLine("Money transfer was successful ");
                Thread.Sleep(500);
                return "Transfer operation(s)\n\n" + "Receiver's name : " + receiver[indexOfreceiver].Name + "\nReceiver's surname : " + receiver[indexOfreceiver].Surname + "\nTranfer amount : $" + amount + "\nReceiver's' balance : $" + receiver[indexOfreceiver].CreditCard.Balance+ "\n====================================\n";
            }


        }

        

    }
}




