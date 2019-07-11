using System;
using BankLibrary;

namespace BankAplication
{
    class Program
    {
        static Bank<Account> bank = new Bank<Account>("FBank");
        static int id;
        static void Main(string[] args)
        {

            while (true)
            {

                WriteIntoConsole();
                try
                {
                    String command = Console.ReadLine();
                    if (command.Equals(0)) break;
                    switch (command)
                    {
                        case "1":
                            AddAccount();
                            break;
                        case "2":
                            Withdraw();
                            break;
                        case "3":
                            Put();
                            break;
                        case "4":
                            CloseAccount();
                            break;
                      
                    }
                    bank.DayGone();

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
        private static void CloseAccount()
        {
            bank.Close(id);
        }

        private static void Put()
        {
            Console.WriteLine("How many you want to put?");
            Decimal.TryParse(Console.ReadLine(), out decimal summ);
            bank.Put(summ, id);
        }

        private static void Withdraw()
        {
            Console.WriteLine("How many you want to get?");
            Decimal.TryParse(Console.ReadLine(), out decimal withdraw);
            bank.Withdraw(withdraw, id);
        }

        private static void AddAccount()
        {
            Console.WriteLine("If you want: credit press 1, debit 2");
            if (Console.ReadLine().Equals("1"))
            {
                Console.WriteLine("How long you want repay a loan");
                Int32.TryParse(Console.ReadLine(), out int timeRepay);
                Console.WriteLine("How much you want to take");
                Decimal.TryParse(Console.ReadLine(), out decimal credit);
                CreditAccount creditAccount = new CreditAccount(0, timeRepay, credit);
                id = creditAccount.Id;
                bank.Open(creditAccount);

            }
            else
            {
                Console.WriteLine("How much you want to put");
                Decimal.TryParse(Console.ReadLine(), out decimal summ);
                bank.Open(new DepositAccount(summ, TypeDeposit.Bronze));
            }

        }
        private static void OpenAccount(int _id)
        {
            id = _id;
        }



        private static void WriteIntoConsole()
        {
            
            Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
            Console.WriteLine("1. Открыть счет \t 2. Вывести средства  ");
            Console.WriteLine("3.Добавить на счет\t 4. Закрыть счет  ");
            Console.WriteLine("Введите номер пункта:");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
