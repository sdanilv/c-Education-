using System;
using BankLibrary;

namespace BankAplication
{
    class Program
    {
        static Bank<Account> bank = new Bank<Account>("FBank");
        static Account account;
        static int id;
        static bool isCredit ;
        static void Main(string[] args)
        {

            while (true)
            {
                if (!bank.HasAccounts()) AddAccount();
                isCredit = account is CreditAccount;
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
                        case "5":
                            OpenAccount();
                            break;
                        case "6":
                            AccountManipulation();
                            break;
                        case "7":
                            prediction();
                            break;

                    }
                    Console.WriteLine("---------------------------\n");
                    bank.DayGone();
                    Console.WriteLine("---------------------------\n" + "Your id now " + id);

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void prediction()
        {
            if (isCredit) Console.WriteLine((account as CreditAccount).creditAfterDuration());
            else
            {
                Console.WriteLine("How long you want keep deposit");
                Console.WriteLine((account as DepositAccount).AmountOfIncome(Convert.ToInt32(Console.ReadLine()))); }
        }

        private static void AccountManipulation()
        {
            if (isCredit) Console.WriteLine(((CreditAccount)account).Percent+"%");
            else bank.ChangeDeposit(id);
        }

        private static void OpenAccount()
        {
            Console.WriteLine("Write id");
            OpenAccount(Convert.ToInt32(Console.ReadLine()));
        }

        private static void CloseAccount()
        {
            bank.Close(id);
            Console.WriteLine("You delete account id"+id);
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
                account = creditAccount;
                creditAccount.Send += str => {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(str);
                    Console.ForegroundColor = ConsoleColor.Gray;
                };
                bank.Add(creditAccount);
                Console.WriteLine($"You succesed creat credit account with id{id}");
            }
            else
            {
                Console.WriteLine("How much you want to put");
                Decimal.TryParse(Console.ReadLine(), out decimal summ);
                DepositAccount depositAccount = new DepositAccount(summ, TypeDeposit.Bronze);
                id = depositAccount.Id;
                account = depositAccount;
                bank.Add(depositAccount);
                Console.WriteLine($"You succesed creat deposit account with id{id}");
            }

        }
        private static void OpenAccount(int _id)
        {
            id = _id;
            account = bank.FindAccountForID(_id);
            Console.WriteLine("You change active account for id"+id);
        }



        private static void WriteIntoConsole()
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
            Console.WriteLine("1. Add new account\t 2. Вывести средства  ");
            Console.WriteLine("3. Добавить на счет\t 4. Закрыть счет  ");
            if (isCredit) Console.Write("5. Open account \t 6. See yor percent\n7. See you credit after duration.");
            else Console.Write("5. Open account \t 6. If you want change type of diposite\n7. See invoice for you account after n days");
            Console.Write("\nВведите номер пункта:  ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
