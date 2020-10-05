using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public partial class Work // partial class - является частичным классом, partial показывает, что класс может быть разбит на несколько классов
    {
        public void Student()
        {
            Console.WriteLine("The work perfomed by Andrjushka)");
        }
    }
    public partial class Work
    {
        public void Teacher()
        {
            Console.WriteLine("The work accepted by Alex Victorovich)\n");
        }
    }

    class Bus
    {
        public string driverFullName { get; set; }
        private int busNumber;
        public int BusNumber
        {
            set
            {
                if (value < 0)
                    Console.WriteLine("Bus number can't be less than 0");
                else
                    busNumber = value;
            }
            get
            {
                return busNumber;
            }
        }
        private int numberOfPath;
        public int NumberOfPath
        {
            set
            {
                if (value < 0)
                    Console.WriteLine("Path number can't be less than 0");
                else
                    numberOfPath = value;
            }
            get
            {
                return numberOfPath;
            }
        }
        public string busBrand { get; set; }
        public int yearOfExp;
        public int YearOfExp
        {
            set
            {
                if (value > 1980 && value < 2021)
                    yearOfExp = value;
                else
                    Console.WriteLine("Bus can't be more than 40 years old");
            }

        }
        public readonly double ID;
        public const int constVar = 2;
        private static int counter = 0;

        public Bus() // Конструктор без параметров (по-умолчанию)
        {
            driverFullName = "No information";
            busNumber = 100;
            NumberOfPath = 100;
            busBrand = "No information";
            yearOfExp = 2000;
            ID = (busNumber*NumberOfPath)/ constVar;
            counter++;
        }
       
        public Bus(string fullName, int number, int path, string brand, int year) // Конструктор с параметрами
        {
           driverFullName = fullName;
           busNumber = number;
           NumberOfPath = path;
           busBrand = brand;
           yearOfExp = year;
           ID = (busNumber * NumberOfPath) / constVar;
           counter++;
        }

        public Bus(string fullName)
        {
            driverFullName = fullName;
            busNumber = 26;
            NumberOfPath = 26;
            busBrand = "MAZ";
            yearOfExp = 1994;
            ID = (busNumber * NumberOfPath) / constVar;
            counter++;
        }

        public void BusAge(ref int yearOfExp, out int busAge) // Метод для рассчета возраста автобуса
        {
            busAge = DateTime.Now.Year - yearOfExp;
            
        }

        static Bus() // Статический метод, который запускается при создании объекта класса Bus
        {
            Console.WriteLine("Welcome to the bus station!\n");
        }

        //private Bus() { } - закрытый конструктор. В данном случае не нужно использовать, т.к. он запрещает создания экземпляров класса по-умолчанию

        public static void CounterOfBuses(out int amountBuses) // Метод, который считает количество созданных объектов класса
        {
            amountBuses = counter;
            Console.WriteLine($"Amount of buses: {counter} \n");
        }

        public void Info() // Метод, который выводит информацию об объекте
        {
            Console.WriteLine("Information about bus:");
            Console.WriteLine($"Driver name: {driverFullName}\n" +
                              $"Number: {busNumber}\n" +
                              $"Number of the path: {numberOfPath}\n" +
                              $"Brand: {busBrand}\n" +
                              $"Year of exploitation: {yearOfExp}\n" +
                              $"ID: {ID}\n");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Work lab = new Work();
            lab.Student();
            lab.Teacher();

            var anonObj = new { name = "John S", age = 40, hometown = "Minsk", number = 375298543709 };
            Console.WriteLine($"Анонимный объект:\n" +
                              $"Имя: {anonObj.name}\n" +
                              $"Возраст: {anonObj.age}\n" +
                              $"Город: {anonObj.hometown}\n" +
                              $"Номер: {anonObj.number}\n");
            Bus[] busArray = new Bus[5];
            busArray[0] = new Bus();
            busArray[1] = new Bus("Musk I", 16, 25, "Tesla", 2019);
            busArray[2] = new Bus("Gates B", 90, 10, "Windows", 1984);
            busArray[3] = new Bus("Shiman D", 10, 25, "FIT", 2015);
            busArray[4] = new Bus("BigLu A");

            int amountBuses;
            Bus.CounterOfBuses(out amountBuses);

            int choice;
            do
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("0 - Выход");
                Console.WriteLine("1 - Вывести информацию об автобусе");
                Console.WriteLine("2 - Вывести возраст автобуса");
                Console.WriteLine("3 - Вывести список автобусов по заданному маршруту");
                Console.WriteLine("4 - Вывести список автобусов которые эксплуатируются больше заданного срока");
                Console.WriteLine("5 - Сравнить данные автобусов");
                Console.WriteLine("Ваш выбор: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        {
                            //Console.WriteLine("Goodbye :)");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("Введите порядковый номер автобуса (1-5): ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            if (number > 0 && number <= amountBuses)
                            {
                                busArray[number-1].Info();
                            }
                            else
                                Console.WriteLine("Такого автобуса нет");

                            break;
                        }
                    case 2:
                        {
                           Console.WriteLine("Введите порядковый номер автобуса (1-5): ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            int busAge;
                            if (number > 0 && number <= amountBuses)
                            {
                                busArray[number-1].BusAge(ref busArray[number-1].yearOfExp, out busAge);
                                Console.WriteLine($"Возраст автобуса = {busAge}\n");
                            }
                            else
                                Console.WriteLine("Такого автобуса нет");

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Введите номер маршрута, чтобы узнать, какие автобусы по нему ходят: ");
                            int path = Convert.ToInt32(Console.ReadLine());
                            int counter = 0;
                            Console.WriteLine("Автобусы по маршруту №" + path+":\n");
                            for(int i=0;i<busArray.Length;i++)
                            {
                                if (busArray[i].NumberOfPath == path)
                                {
                                    busArray[i].Info();
                                    counter++;
                                }
                            }
                            if (counter <= 0)
                                Console.WriteLine("Ничего не найдено");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Введите срок эксплуатации автобуса: ");
                            int exploitation = Convert.ToInt32(Console.ReadLine());
                            int busAge;
                            if (exploitation<0)
                            {
                                Console.WriteLine("Срок эксплуатации не может быть меньше нуля");
                                break;
                            }
                            Console.WriteLine("Список автобусов со сроком эксплуатации больше заданного: ");
                            for(int i=0;i < busArray.Length; i++)
                            {
                                busArray[i].BusAge(ref busArray[i].yearOfExp, out busAge);
                                if (busAge>exploitation)
                                {
                                    busArray[i].Info();
                                }
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Введите порядковый номер первого автобуса (1-5): ");
                            int number1 = Convert.ToInt32(Console.ReadLine());
                            if(number1<=0 && number1>5)
                            {
                                Console.WriteLine("Такого автобуса нет");
                                break;
                            }
                            Console.WriteLine("Введите порядковый номер второго автобуса (1-5): ");
                            int number2 = Convert.ToInt32(Console.ReadLine());
                            if (number2 <= 0 && number2 > 5)
                            {
                                Console.WriteLine("Такого автобуса нет");
                                break;
                            }
                            Console.WriteLine("Первый автобус: ");
                            busArray[number1-1].Info();
                            Console.WriteLine("Второй автобус: ");
                            busArray[number2-1].Info();

                            bool compare = busArray[number1-1].Equals(busArray[number2-1]);
                            if (compare)
                                Console.WriteLine("Данные автобусов одинаковые");
                            else
                                Console.WriteLine("Данные автобусов не совпадают");
                            Console.WriteLine($"Hash код первого автобуса: {busArray[number1-1].GetHashCode()}\n" +
                                              $"Hash код второго автобуса: {busArray[number2-1].GetHashCode()}\n" +
                                              $"Тип данных первого автобуса: {busArray[number1-1].GetType()}\n" +
                                              $"Тип данных второго автобуса: {busArray[number2 - 1].GetType()}\n" +
                                              $"Имя водителя первого автобуса: {busArray[number1 - 1].driverFullName.ToString()}\n" +
                                              $"Имя водителя второго автобуса: {busArray[number2 - 1].driverFullName.ToString()}\n");

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Такого пункта в меню нет. Попробуйте еще раз");
                            break;
                        }
           
                }

            } while (choice!=0);




            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("/////////////////////////////////////////////Primite labu, plz))//////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.ResetColor();
            Console.WriteLine();

            Console.Read();
        }
    }
}
