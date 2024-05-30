using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank myBank = new Bank { Name = "Мой банк" };
            Branch myBranch = new Branch { Name = "Отделение 1", TotalDeposits = 1000000 };

            Deposit longTermDeposit = new LongTermDeposit
            {
                FullName = "Иванов Иван Иванович",
                Amount = 50000,
                Months = 12
            };

            Deposit demandDeposit = new DemandDeposit
            {
                FullName = "Петров Петр Петрович",
                Amount = 10000,
                Months = 6
            };

            Console.WriteLine($"Название банка: {myBank.Name}");
            Console.WriteLine($"Название отделения: {myBranch.Name}");
            Console.WriteLine($"Сумма всех вкладов в отделении: {myBranch.TotalDeposits}");

            Console.WriteLine($"Сумма долгосрочного вклада через 12 месяцев: {longTermDeposit.CalculateDepositAmount(12)}");
            Console.WriteLine($"Сумма вклада до востребования через 6 месяцев: {demandDeposit.CalculateDepositAmount(6)}");
        }
        class Bank
        {
            public string Name { get; set; }
        }

        class Branch
        {
            public string Name { get; set; }
            public double TotalDeposits { get; set; }
        }

        class Deposit
        {
            public string FullName { get; set; }
            public double Amount { get; set; }
            public int Months { get; set; }

            public virtual double CalculateDepositAmount(int months)
            {
                return 0;
            }
        }

        class LongTermDeposit : Deposit
        {
            public override double CalculateDepositAmount(int months)
            {
                double interestRate = 0.16;
                return Amount + Amount * interestRate * months;
            }
        }

        class DemandDeposit : Deposit
        {
            public override double CalculateDepositAmount(int months)
            {
                double interestRate = 0.03;
                return Amount + Amount * interestRate * months;
            }
        }

        class ShortTermDeposit : Deposit
        {
            public override double CalculateDepositAmount(int months)
            {
                double interestRate = 0.03;
                return Amount + Amount * interestRate * months;
            }
        }
    }
}