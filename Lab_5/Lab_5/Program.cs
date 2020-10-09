using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
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

        //public void Print()
        //{
        //    Console.WriteLine($"Страна производитель:{countryOfOrigin} \nСтоимость:{costOfObject}");
        //}
        public override string ToString()
        {
            return $"Тип объекта: {this.GetType()}\n" +
                $"Страна производитель:{this.countryOfOrigin}\n" +
                $"Стоимость:{this.CostOfObject}\n";

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
        public override string ToString()
        {
            return $"Тип объекта: {this.GetType()}\n" + 
                $"Мощность двигателя: {this.PowerOfEngine}\n" +
                $"Страна производитель:{this.countryOfOrigin}\n" +
                $"Стоимость:{this.CostOfObject}\n";

        }

    }

    class Car : Engine
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

        public Car(string brand, string transmission, long power, long cost, string country) : base(power, country, cost)
        {
            carBrand = brand;
            transmissionType = transmission;
        }

        public override void GenerateWIN()
        {
            Random rand = new Random();
            int ID = rand.Next(0, 100);
            base.GenerateWIN();
            WIN += ID;
        }
        public override int GetHashCode()
        {
            return carBrand.GetHashCode() + transmissionType.GetHashCode() + WIN.GetHashCode() + PowerOfEngine.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Car car = (Car)obj;

            return (this.GetHashCode() == car.GetHashCode());
        }

        public override string ToString()
        {
            return $"Тип объекта: {this.GetType()}\n" +
                $"Страна производитель:{this.countryOfOrigin}\n" +
                $"Марка автомобиля: {this.carBrand}\n" +
                $"Трансмиссия: {this.transmissionType}\n" +
                $"Мощность двигателя: {this.PowerOfEngine}\n" +
                //$"WIN номер: {this.WIN}\n" +
                $"Стоимость:{this.CostOfObject}\n";
                
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

    sealed class Train : Carriage
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
       
        public void AllRouteCost()
        {
            Console.WriteLine("Стоимость всего маршрута: " + this.CostOfObject * this.NumberOfTickets);
        }
        
        public override string ToString()
        {
            return $"Тип объекта: {this.GetType()}\n" +
                $"Страна производитель:{this.countryOfOrigin}\n" +
                $"Компания: {this.companyType}\n" +
                $"Тип вагона: {this.CarriageClass}\n" +
                $"Количество вагонов:{this.AmountOfCarriages}\n" +
                $"Маршрут: {this.route}\n"+
                $"Количество билетов: {this.numberOfTickets}\n" +
                $"Стоимость билета: {this.CostOfObject}\n";
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Mercedes", "АКП", 125, 12000, "Germany");
            Console.WriteLine(car.ToString());
            Car car2 = new Car("AUDI", "МКП", 300, 20000, "Germany");
            Console.WriteLine(car2.ToString());
            car2.GenerateWIN();
            Console.WriteLine($"WIN номер: {car2.WIN}");
            bool eq = car.Equals(car2);
            Console.WriteLine("\n" + eq + "\n");
            
            Train train = new Train("Belarussian railway", "Belarus", 100, 10, "Бизнесс", 200, "Брест-Витебск");
            Console.WriteLine(train.ToString());
            train.AllRouteCost();
            Carriage newCarr = new Carriage("RR", "Russia", 1000, 25, "Бизнесс");
            Console.WriteLine("\n" + newCarr.ToString());
            Train tr = newCarr as Train;
            if(tr == null)
                Console.WriteLine("\nПреобразование не удалось\n");
            else
                Console.WriteLine(tr.ToString());

            newCarr = train as Carriage;
            if (newCarr == null)
                Console.WriteLine("\nПреобразование не удалось\n");
            else
            {
                Console.WriteLine("Результат преобразования: ");
                Console.WriteLine(newCarr.ToString());
            }

            Engine[] veh = new Engine[3];
            Engine eng = car2 as Car;
            veh[0] = eng;
            veh[1] = car;
            veh[2] = car2;
           

            Print print = new Print();
            for(int i = 0; i<veh.Length;i++)
            {
                print.IamPrinting(veh[i]);
            }
           


        }
    }
}
