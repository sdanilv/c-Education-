using System;
using BankLibrary;

namespace BankAplication
{
    class Program
    {
        static Bank<Account> bank = new Bank<Account>("FBank");
        int id;
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
                            OpenAccount(bank);
                            break;
                        case "2":
                            Withdraw(bank);
                            break;
                        case "3":
                            Put(bank);
                            break;
                        case "4":
                            CloseAccount(bank);
                            break;
                        case "5":
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void OpenAccount(Bank<Account> bank)
        {
            Console.WriteLine("If you want: credit press 1, debit 2");
            if (Console.ReadLine().Equals("1"))
            {
                Console.WriteLine("How long you want repay a loan");
                Int32.TryParse(Console.ReadLine(), out int timeRepay);
                Console.WriteLine("How much you want to take");
                Decimal.TryParse(Console.ReadLine(), out decimal credit);
                CreditAccount creditAccount = new CreditAccount(0, timeRepay, credit);
                bank.Open(creditAccount);
                
            }
            else
            {
                Console.WriteLine("How much you want to put");
                Decimal.TryParse(Console.ReadLine(), out decimal summ);
                bank.Open(new DepositAccount(summ, TypeDeposit.Bronze));
            }

        }

        private static void WriteIntoConsole()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
            Console.WriteLine("1. Открыть счет \t 2. Вывести средства  \t 3. Добавить на счет");
            Console.WriteLine("4. Закрыть счет \t 5. Пропустить день \t 6. Выйти из программы");
            Console.WriteLine("Введите номер пункта:");
            Console.ForegroundColor = color;
        }
    }
}
