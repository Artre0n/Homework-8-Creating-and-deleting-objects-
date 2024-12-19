using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тумаков___Лабораторная_9_главы.ClassesTumakov
{
    public class BankTransaction
    {
        /// <summary>
        /// Дата и время транзакции
        /// </summary>
        public DateTime TransactionDateTime { get; }
        /// <summary>
        /// Сумма транзакции
        /// </summary>
        public decimal Sum { get; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public BankTransaction()
        {
            TransactionDateTime = DateTime.Now;
            Sum = 0;
        }
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="amount">Сумма транзакции</param>
        public BankTransaction(decimal sum)
        {
            TransactionDateTime = DateTime.Now;
            Sum = sum;
        }

    }
}
