using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    enum CarColor
    {
        White = 1,
        Black,
        Green,
        DarkBlue
    }

    struct Driver
    {
        string name;
        int age;
        string hometown;

        Driver(string name, int age, string hometown)
        {
            this.name = name;
            this.age = age;
            this.hometown = hometown;
        }

        void PrintDriver()
        {
            Console.WriteLine("Информация о водителе:");
            Console.WriteLine($"Имя:{name} \nВозраст:{age} \nГород: {hometown}");
        }
    }
    class Print
    {
        public virtual void IamPrinting(Engine obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }
    interface IWIN
    {
        long WIN { get; set; }
        void GenerateWIN();
    }
    class Vehicle
    {
        public string countryOfOrigin { get; set; }
        private long costOfObject;
        public long CostOfObject
        {
            get
            {
                return costOfObject;
            }
            set
            {
                if (value < 1)
                    costOfObject = 0;
                else
                    costOfObject = value;
            }
        }

        public Vehicle(long cost, string country)
        {
            countryOfOrigin = country;
            costOfObject = cost;
        }
        public Vehicle() { }
        
        public override string ToString()
        {
            return $"Страна производитель:{this.countryOfOrigin}\n" +
                $"Стоимость:{this.CostOfObject}\n" + 
                $"Тип объекта: {this.GetType()}\n";

        }


    }
    abstract class Engine : Vehicle,IWIN
    {
        private long powerOfEngine;
        public long PowerOfEngine
        {
            get
            {
                return powerOfEngine;
            }
            set
            {
                if (value < 1)
                    powerOfEngine = 1;
                else
                    powerOfEngine = value;
            }
        }
        public long WIN { get; set; }
        public virtual void GenerateWIN()
        {
            WIN = (powerOfEngine * 101) / 2;
        }

        public Engine(long power, string country, long cost) : base(cost, country)
        {
            powerOfEngine = power;
        }
        public Engine() { }
        public override string ToString()
        {
            return $"Мощность двигателя: {this.PowerOfEngine}\n" + base.ToString();


        }

    }

    sealed class Car : Engine
    {
        public string carBrand { get; set; }
        private string transmissionType;
        public string TransmissionType
        {
            get
            {
                return transmissionType;
            }
            set
            {
                if (value == "АКП" || value == "МКП")
                    transmissionType = value;
                else
                    transmissionType = "No information";
            }
        }
        private int gasExpense;
        public int GasExpense
        {
            get
            {
                return gasExpense;
            }
            set
            {
                if (value < 1)
                    gasExpense = 0;
                else
                    gasExpense = value;
            }
        }
        
        public Car(string brand, string transmission, int gas, long power, long cost, string country) : base(power, country, cost)
        {
            carBrand = brand;
            transmissionType = transmission;
            gasExpense = gas;
        }
        public Car() { }

        public override void GenerateWIN()
        {
            Random rand = new Random();
            int ID = rand.Next(0, 100);
            base.GenerateWIN();
            WIN += ID;
        }
        public override int GetHashCode()
        {
            return carBrand.GetHashCode() + transmissionType.GetHashCode() + PowerOfEngine.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Car car = (Car)obj;

            return (this.GetHashCode() == car.GetHashCode());
        }

        public override string ToString()
        {
            return
                $"Марка автомобиля: {this.carBrand}\n" +
                $"Трансмиссия: {this.transmissionType}\n" +
                $"Расход топлива: {this.gasExpense}\n" + base.ToString();

        }
    }

    class Express : Vehicle
    {
        public string companyType { get; set; }
        public Express(string company, string country, int cost) : base(cost, country)
        {
            companyType = company;
        }
        public override string ToString()
        {
            return $"Тип объекта: {this.GetType()}\n" +
                $"Страна производитель:{this.countryOfOrigin}\n" +
                $"Компания: {this.companyType}\n" +
                $"Стоимость:{this.CostOfObject}\n";

        }
    }

    class Carriage : Express
    {
        private string carriageClass;
        public string CarriageClass
        {
            get
            {
                return carriageClass;
            }
            set
            {
                if (value == "Бизнесс" || value == "Эконом")
                    carriageClass = value;
                else
                    carriageClass = "No information";
            }
        }

        private int amountOfCarriages;
        public int AmountOfCarriages
        {
            get
            {
                return amountOfCarriages;
            }
            set
            {
                if (value < 0)
                    amountOfCarriages = 0;
                else
                    amountOfCarriages = value;
            }
        }
        public Carriage(string company, string country, int cost, int amount, string type) : base(company, country, cost)
        {
            amountOfCarriages = amount;
            carriageClass = type;
        }
        public override string ToString()
        {
            return $"Тип объекта: {this.GetType()}\n" +
                $"Страна производитель:{this.countryOfOrigin}\n" +
                $"Компания: {this.companyType}\n" +
                $"Тип вагона: {this.carriageClass}\n " +
                $"Количество вагонов:{this.amountOfCarriages}\n " +
                $"Стоимость:{this.CostOfObject}\n";
            
        }
    }

    partial class Train : Carriage
    {
        public string route { get; set; }
        private int numberOfTickets;
        public int NumberOfTickets
        {
            get
            {
                return numberOfTickets;
            }
            set
            {
                if (value < 0)
                    numberOfTickets = 0;
                else
                    numberOfTickets = value;
            }
        }
        public Train(string company, string country, int cost, int amount, string type, int tickets, string routeName) : base(company, country, cost,amount,type)
        {
            numberOfTickets = tickets;
            route = routeName;
        }
       
        

    }

    class TransportAgency
    {
        public List<Car> carList { get; set; }
        public TransportAgency()
        {
            carList = new List<Car>();
        }
        public void Print()
        {
            Console.WriteLine("\nСписок автомобилей агенства:\n");
            foreach (var i in carList)
            {
                Console.WriteLine(i);
            }
        }
        

    }

    class TransportController : IComparer<Car>
    {
        public long GeneralCost(TransportAgency TA)
        {
            long sum = 0;
            foreach(var i in TA.carList)
            {
                sum += i.CostOfObject;
            }
            return sum;
        }

        public int Compare(Car list1, Car list2)
        {
            if(list1.GasExpense > list2.GasExpense)
            {
                return 1;
            }
            else if(list1.GasExpense < list2.GasExpense)
            {
                return -1;
            }

            return 0;
        }

        public void Power(TransportAgency TA, int[] power)
        {
            int count = 0;
            for(int i = 0; i< TA.carList.Count;i++)
            {
                if(TA.carList[i].PowerOfEngine >= power[0] && TA.carList[i].PowerOfEngine <= power[1])
                {
                    Console.WriteLine(TA.carList[i]);
                    count++;
                }
            }
            if (count == 0)
                Console.WriteLine("В данном диапазоне ничего не найдено");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Mercedes", "АКП",10, 125, 12000, "Germany");
            Car car2 = new Car("AUDI", "МКП", 15,300, 20000, "Germany");
            car2.GenerateWIN();
            TransportController control = new TransportController();
            TransportAgency TA1 = new TransportAgency();
            TA1.carList.Add(car);
            TA1.carList.Add(car2);
            TA1.carList.Add(new Car("BMW", "МКП", 22, 201, 21100, "Germany"));
            TA1.carList.Sort(control);
            TA1.Print();
            Console.WriteLine($"Общая стоимость всех автомобилей: {control.GeneralCost(TA1)}");
            int[] powerArray = new int[2];
            Console.WriteLine("Введите диапазон мощности автомобиля: ");
            Console.WriteLine("Первая точка диапазона: ");
            powerArray[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Вторая точка диапазона: ");
            powerArray[1] = Convert.ToInt32(Console.ReadLine());
            if(powerArray[0]>powerArray[1])
                throw new Exception("Первая точка диапазона не может быть больше второй");

            control.Power(TA1, powerArray);

            //bool eq = car.Equals(car2);
            //Console.WriteLine("\n" + eq + "\n");

            //Train train = new Train("Belarussian railway", "Belarus", 100, 10, "Бизнесс", 200, "Брест-Витебск");
            //Console.WriteLine(train.ToString());
            //train.AllRouteCost();
            //Carriage newCarr = new Carriage("RR", "Russia", 1000, 25, "Бизнесс");
            //Console.WriteLine("\n" + newCarr.ToString());
            //Train tr = newCarr as Train;
            //if(tr == null)
            //    Console.WriteLine("\nПреобразование не удалось\n");
            //else
            //    Console.WriteLine(tr.ToString());

            //newCarr = train as Carriage;
            //if (newCarr == null)
            //    Console.WriteLine("\nПреобразование не удалось\n");
            //else
            //{
            //    Console.WriteLine("Результат преобразования: ");
            //    Console.WriteLine(newCarr.ToString());
            //}

            //Engine[] veh = new Engine[3];
            //Engine eng = car2 as Car;
            //veh[0] = eng;
            //veh[1] = car;
            //veh[2] = car2;


            //Print print = new Print();
            //for(int i = 0; i<veh.Length;i++)
            //{
            //    print.IamPrinting(veh[i]);
            //}



        }
    }
}
