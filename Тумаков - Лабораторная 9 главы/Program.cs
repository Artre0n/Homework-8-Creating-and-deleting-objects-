using Тумаков___Лабораторная_9_главы.ClassesTumakov;
using Тумаков___Лабораторная_9_главы;
using System.Security.Principal;


public class Programm
{
    public static void Main()
    {
        Task1();
        Task2();
    }
    public static void Task1()
    {
        Console.WriteLine("Упражнения 9.1, 9.2 и 9.3\n");
        #region Условия задач
        //Упражнение 9.1
        //В классе банковский счет, созданном в предыдущих упражнениях, удалить
        //методы заполнения полей. Вместо этих методов создать конструкторы.Переопределить
        //конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор
        //для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа
        //банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер
        //счета.
        //Упражнение 9.2
        //Создать новый класс BankTransaction, который будет хранить информацию
        //о всех банковских операциях.При изменении баланса счета создается новый объект класса
        //BankTransaction, который содержит текущую дату и время, добавленную или снятую со
        //счета сумму.Поля класса должны быть только для чтения(readonly). Конструктору класса
        //передается один параметр – сумма.В классе банковский счет добавить закрытое поле типа
        //System.Collections.Queue, которое будет хранить объекты класса BankTransaction для
        //данного банковского счета; изменить методы снятия со счета и добавления на счет так,
        //чтобы в них создавался объект класса BankTransaction и каждый объект добавлялся в
        //переменную типа System.Collections.Queue.
        //Упражнение 9.3
        //В классе банковский счет создать метод Dispose, который данные о
        //проводках из очереди запишет в файл.Не забудьте внутри метода Dispose вызвать метод
        //GC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод
        //завершения для указанного объекта.
        #endregion
        BankAccount account1 = new BankAccount(AccountType.Текущий, 1000);

        account1.ShowAccountInfo();
        account1.Withdraw(500);
        account1.Deposit(200);

        BankAccount account2 = new BankAccount(AccountType.Накопительный);

        account2.ShowAccountInfo();

        account1.Transfer(account1, account2, 300);

        account1.ShowAccountInfo();
        account2.ShowAccountInfo();

        account1.ShowTransactions();
        account1.Dispose();
    }
    public static void Task2()
    {
        Console.WriteLine("\nДомашнее задание 9.1\n");
        #region Условия задачи
        //В класс Song(из домашнего задания 8.2) добавить следующие
        //конструкторы:
        //1) параметры конструктора – название и автор песни, указатель на предыдущую песню инициализировать null.
        //2) параметры конструктора – название, автор песни, предыдущая песня.В методе Main
        //создать объект mySong. Возникнет ли ошибка при инициализации объекта mySong
        //следующим образом: Song mySong = new Song(); ?
        //Исправьте ошибку, создав необходимый конструктор.
        // Пример:
        // Селфхарм - Монеточка
        // Моя невеста - Егор Крид
        // В белом невесте - 4k
        // Tramp - Otis Redding
        // Заходи - Амбисаша
        #endregion
        List<Song> songs = new List<Song>();

        for (int i = 0; i < 4; i++)
        {
            Song song = new Song(); // не вызовет ошибку из-за null, т.к. есть конструктор по умолчанию
            string songName, songAuthor;

            Console.Write($"Введите название песни {i + 1}: ");
            songName = (Console.ReadLine());

            Console.Write($"Введите автора песни {i + 1}: ");
            songAuthor = Console.ReadLine();

            song.SetName(songName);
            song.SetAuthor(songAuthor);

            if (i > 0)
            {
                song.SetPrev(songs[i - 1]);
            }

            songs.Add(song);
        }

        Console.WriteLine("\nИнформация о песнях:");
        foreach (var song in songs)
        {
            song.Title();
        }

        if (songs.Count >= 2)
        {
            bool areEqual = songs[0].Equals(songs[1]);
            if (areEqual)
            {
                Console.WriteLine("\nПервая и вторая песни одинаковые.");
            }
            else
            {
                Console.WriteLine("\nПервая и вторая песни разные.");
            }
        }
    }
}