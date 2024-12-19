using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тумаков___Лабораторная_9_главы.ClassesTumakov
{
    public class BankAccount : IDisposable
    {
        /// <summary>
        /// Статическая переменная для генерации уникального номера счета
        /// </summary>
        private static int lastAccountNumber = 1;

        /// <summary>
        /// Закрытые поля
        /// </summary>
        private int accountNumber;
        private decimal balance;
        private AccountType accountType;
        private Queue<BankTransaction> transactions;
        private bool disposed = false;

        /// <summary>
        /// Номер счета
        /// </summary>
        public int AccountNumber { get { return accountNumber; } }

        /// <summary>
        /// Баланс счета
        /// </summary>
        public decimal Balance { get { return balance; } }

        /// <summary>
        /// Тип банковского счета
        /// </summary>
        public AccountType AccountType { get { return accountType; } }

        /// <summary>
        /// Конструктор по умолчпнию
        /// </summary> 
        public BankAccount()
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = 0;
            this.accountType = AccountType.Текущий;
            this.transactions = new Queue<BankTransaction>();
        }
        /// <summary>
        /// Конструктор для заполнения поля баланс
        /// </summary>
        /// <param name="initialBalance">Начальный баланс</param>
        /// <exception cref="ArgumentException"></exception>

        public BankAccount(decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentException("Начальный баланс не может быть отрицательным\n");
            }

            this.accountNumber = GenerateAccountNumber();
            this.balance = initialBalance;
            this.accountType = AccountType.Текущий;
            this.transactions = new Queue<BankTransaction>();
        }
        /// <summary>
        /// Конструктор для заполнения поля тип банковского счета
        /// </summary>
        /// <param name="accountType">Тип банковского аккаунта</param>
        
        public BankAccount(AccountType accountType)
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = 0;
            this.accountType = accountType;
            this.transactions = new Queue<BankTransaction>();
        }
        /// <summary>
        /// Конструктор для заполнения баланса и типа банковского счета
        /// </summary>
        /// <param name="accountType">Тип банковского аккаунта</param>
        /// <param name="initialBalance">Начальный баланс</param>
        /// <exception cref="ArgumentException"></exception>
        public BankAccount(AccountType accountType, decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentException("Начальный баланс не может быть отрицательным\n");
            }

            this.accountNumber = GenerateAccountNumber();
            this.accountType = accountType;
            this.balance = initialBalance;
            this.transactions = new Queue<BankTransaction>();
        }
        /// <summary>
        /// Метод, генерирующий номер счёта
        /// </summary>
        /// <returns>Сгенерированный номер счёта</returns>
        private static int GenerateAccountNumber()
        {
            return lastAccountNumber++;
        }

        /// <summary>
        /// Метод для вывода информации о счёте
        /// </summary>
        public void ShowAccountInfo()
        {
            Console.WriteLine("Информация о счёте:\n");
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Тип счета: {accountType}");
            Console.WriteLine($"Баланс: {balance}\n");
        }
        /// <summary>
        /// Метод для вывода информации о транзакциях
        /// </summary>
        public void ShowTransactions()
        {
            Console.WriteLine("История транзакций:\n");
            foreach (var transaction in transactions)
            {
                if (transaction.Sum > 0)
                {
                    Console.WriteLine($"Дата: {transaction.TransactionDateTime}, Сумма: +{transaction.Sum}");
                }
                else
                {
                    Console.WriteLine($"Дата: {transaction.TransactionDateTime}, Сумма: {transaction.Sum}");
                }
            }
        }
        /// <summary>
        /// Метод для снятия со счета
        /// </summary>
        /// <param name="amount">Сумма для снятия</param>
        /// <returns>Возвращает true, если операция выполнена успешно, иначе false</returns>
        public bool Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Сумма для снятия не может быть отрицательной\n");
                return false;
            }

            if (amount > balance)
            {
                Console.WriteLine("Недостаточно средств на счете\n");
                return false;
            }
            else
            {
                balance -= amount;
                transactions.Enqueue(new BankTransaction(-amount));
                Console.WriteLine($"Снято {amount}. Новый баланс: {balance}\n");
                return true;
            }
        }

        /// <summary>
        /// Метод для пополнения счета
        /// </summary>
        /// <param name="amount">Сумма для пополнения</param>
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Сумма для пополнения не может быть отрицательной\n");
                return;
            }

            balance += amount;
            transactions.Enqueue(new BankTransaction(amount));
            Console.WriteLine($"Положено {amount}. Новый баланс: {balance}\n");
        }

        /// <summary>
        /// Метод для перевода денег с одного счета на другой
        /// </summary>
        /// <param name="paymentAccount">Счёт, с которого переводятся деньги</param>
        /// <param name="destinationAccount">Счет, на который переводятся деньги</param>
        /// <param name="amount">Сумма для перевода</param>
        /// <returns>Возвращает true, если операция выполнена успешно, иначе false</returns>
        public bool Transfer(BankAccount paymentAccount, BankAccount destinationAccount, decimal amount)
        {
            if (destinationAccount == null && destinationAccount is not BankAccount)
            {
                Console.WriteLine("Указан недействительный счет назначения\n");
                return false;
            }

            if (amount < 0)
            {
                Console.WriteLine("Сумма для перевода не может быть отрицательной\n");
                return false;
            }

            Console.WriteLine($"Перевод c счёта {paymentAccount.AccountNumber} на счёт {destinationAccount.AccountNumber}:");
            if (paymentAccount.Withdraw(amount))
            {
                destinationAccount.Deposit(amount);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Освобождает используемые ресурсы
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Освобождает используемые ресурсы
        /// </summary>
        /// <param name="disposing">True, если вызывается метод Dispose; иначе - false</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    using StreamWriter writer = new StreamWriter("transactions.txt", true);
                    foreach (var transaction in transactions)
                    {
                        writer.WriteLine($"Дата: {transaction.TransactionDateTime}, Сумма: {transaction.Sum}");
                    }
                }
                disposed = true;
            }
        }
    }
}
