using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM
{
    class Program
    {

        static void Main(string[] args)
        {
            #region All Users
            User[] users = new User[5]
            {
                /* User 1 */
              new User
              {Name = "Tammy", Surname = "Woods" ,

                 CreditCard = new Card()
                 {
                     PAN =  "4532518225923473",
                     PIN = "9206",
                     CVC = "111",
                     ExpireDate = DateTime.Now.AddYears(3),
                     Balance = 9000
                 }
              },

                      /* User 2 */
              new User
              {Name = "Kelly", Surname = "Bowman" ,

                 CreditCard = new Card()
                 {
                     PAN =  "4350013977216317",
                     PIN = "4849",
                     CVC = "222",
                     ExpireDate = DateTime.Now.AddYears(5),
                     Balance = 1000
                 }
              },
                      

                    /* User 3 */ 
              new User
              {Name = "Alan", Surname = "Wallace" ,

                 CreditCard = new Card()
                 {
                     PAN =  "4485440734429263",
                     PIN = "5392",
                     CVC = "333",
                     ExpireDate = DateTime.Now.AddYears(2),
                     Balance = 1000
                 }
              },
               
                         /* User 4 */ 
              new User
              {Name = "Deborah", Surname = "Duncan" ,

                 CreditCard = new Card()
                 {
                     PAN =  "4929836831378309",
                     PIN = "3972",
                     CVC = "444",
                     ExpireDate = DateTime.Now.AddYears(7),
                     Balance = 1000
                 }
              },
                            /* User 5 */  
              new User
              {Name = "Stephanie", Surname = "Keller" ,

                 CreditCard = new Card()
                 {
                     PAN =  "4716458409370860",
                     PIN = "5728",
                     CVC = "555",
                     ExpireDate = DateTime.Now.AddYears(5),
                     Balance = 999999
                 }
              },
            };
            #endregion


            string pin = null;
            string pan = null;
            int Money_Amount = 0;
            while (true)
            {
            MainMenu:
                Console.Clear();
                Console.WriteLine("Enter PAN : ");
                pan = Console.ReadLine();

                Console.WriteLine("Enter PIN : ");
                pin = Console.ReadLine();


                int numb = Manager.UserNumb(users, pan, pin);
                int MenuNumber = 0;

                if (numb >= 0)
                {
                    Console.Clear();

                    while (true)
                    {
                        //   MENU 
                        Console.Clear();
                        Console.WriteLine("Menu");
                        Console.WriteLine("1.Balance");
                        Console.WriteLine("2.Withdraw money");
                        Console.WriteLine("3.List of operations");
                        Console.WriteLine("4.Transfer money");
                        Console.WriteLine("5.Get Full Information");
                        Console.WriteLine("6.Back to main menu");

                        MenuNumber = int.Parse(Console.ReadLine());

                        switch (MenuNumber)
                        {
                            case 1:
                                {
                                    Console.Clear();
                                    Console.WriteLine($"BALANCE : ${users[numb].CreditCard.Balance}");
                                    Console.ReadLine();
                                    break;
                                }
                            case 2:
                                {
                                    Console.Clear();
                                    Console.WriteLine("1.$10");
                                    Console.WriteLine("2.$20");
                                    Console.WriteLine("3.$50");
                                    Console.WriteLine("4.$100");
                                    Console.WriteLine("5.Other");
                                    Console.WriteLine("Choose action");
                                    MenuNumber = int.Parse(Console.ReadLine());

                                    switch (MenuNumber)
                                    {
                                        case 1:
                                            {
                                                users[numb].MoneyOperations[++users[numb].OperationCount] = Manager.GetCash(users, numb, 10);                                                
                                                break;
                                            }

                                        case 2:
                                            {
                                                users[numb].MoneyOperations[++users[numb].OperationCount] = Manager.GetCash(users, numb, 20);

                                                break;
                                            }

                                        case 3:
                                            {
                                                users[numb].MoneyOperations[++users[numb].OperationCount] = Manager.GetCash(users, numb, 50);

                                                break;
                                            }

                                        case 4:
                                            {
                                                users[numb].MoneyOperations[++users[numb].OperationCount] = Manager.GetCash(users, numb, 100);


                                                break;
                                            }

                                        case 5:
                                            {
                                                Console.WriteLine("Amount : ");
                                                Money_Amount = int.Parse(Console.ReadLine());
                                                users[numb].MoneyOperations[++users[numb].OperationCount] = Manager.GetCash(users, numb, Money_Amount);
                                                break;
                                            }
                                        default:
                                            break;
                                    } 

                                    break;
                                }

                            case 3:
                                {
                                    Console.Clear();                               
                                    users[numb].DisplayOperations();
                                    Console.ReadLine();
                                    break;
                                }

                            case 4: //Money Transfering
                                {
                                    Console.Clear();
                                    string receiverPAN;
                                    string receivePIN;

                                    Console.WriteLine("Enter PAN : ");
                                    receiverPAN = Console.ReadLine();

                                    Console.WriteLine("Enter PIN : ");
                                    receivePIN = Console.ReadLine();

                                    Console.WriteLine("Enter Amount : ");
                                    Money_Amount = int.Parse(Console.ReadLine());
                                    int receiverNUMB = Manager.UserNumb(users, receiverPAN, receivePIN);
                                    users[numb].MoneyOperations[++users[numb].OperationCount] = Manager.TransferTo(users, users, numb, receiverNUMB, Money_Amount);

                                   
                                    break;
                                }
                            case 5:
                                {
                                    Console.Clear();
                                    Console.WriteLine(users[numb].ToString());
                                    Console.ReadLine();
                                    break;
                                }
                            case 6: goto MainMenu; break;
                            default:
                                break;
                        }
                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Wrong details ...");
                    Thread.Sleep(300);
                }
                Console.Clear();
            }




            Console.WriteLine();
            

        }
    }
}
