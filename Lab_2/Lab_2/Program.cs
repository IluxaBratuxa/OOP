using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1 - variables & types
            //Types C#

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n/////////////////Task 1////////////////\n");
            Console.ResetColor();

            //Console.WriteLine();
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("//////////////////////////////////////////////////");
            //Console.ResetColor();
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("//////////////////////Task 1//////////////////////");
            //Console.ResetColor();
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("//////////////////////////////////////////////////");
            //Console.ResetColor();
            //Console.WriteLine();


            int Int = 25;
            uint UInt = 2510;
            short Short = 32138;
            ushort UShort = 62319;
            long Long = 20345227281887;
            ulong ULong = 52528602034522;
            float Float = 25.10f;
            bool Boolean = true;
            char Char = 'C';
            double Double = 25.10;
            string Str = "Andrej";
            byte Byte = 10;
            sbyte SByte = -100;
            Console.WriteLine("My name is " + Str);
            Console.Write("Enter the number: ");
            Int = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            /// Преобразование типов & Convert
            Float = Int;
            Int = Short;
            Double = Float;
            Long = UInt;
            UInt = UShort;

            Int = (int)Float;
            Short = (short)Char;
            Char = (char)Int;
            Float = (float)Double;
            Byte = (byte)Int;
            Console.WriteLine("Явное преобразование int в byte: " + Byte);
            Int = Convert.ToInt32(Boolean);
            Console.WriteLine("Convert Boolean to int :" + Int);
            Console.WriteLine();

            //Boxing & Unboxing
            int bi = 2510;
            object box = bi;
            int unb = (int)box;
            Console.WriteLine("Unboxing: " + unb);
            Console.WriteLine();

            //Var
            var anonVar = 10.25;
            double d = Double + anonVar;
            Console.WriteLine("Var: " + d);
            Console.WriteLine();

            //Nullable
            int? nullVar = null;
            // nullVar = Int;
            if (nullVar.HasValue)
                Console.WriteLine("nullVar is equal " + nullVar.Value);
            else
                Console.WriteLine("nullVar is empty");
            Console.WriteLine();

            // Var error
            var v = 10;
            //v = 10.25; - тип переменной var сохроняется до конца ее существования


            //Task 2 - strings
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n/////////////////Task 2////////////////\n");
            Console.ResetColor();

            //Compare
            string name = "Andrej";
            string surname = "Pisarik";
            if (String.Compare(name, surname) == 0)
                Console.WriteLine("Strings are equal");
            else
                Console.WriteLine("Strings aren't equal");
            Console.WriteLine();

            // Operations with String 
            string str1 = "Evening in the house.";
            string str2 = "Long live Belarus. ";
            string str3 = "We belive, we can, we will win. ";
            Console.WriteLine("Concat: " + String.Concat(str3, str2));
            char[] copyStr = new char[25];
            str1.CopyTo(0, copyStr, 0, 7);
            Console.WriteLine(copyStr);
            Console.WriteLine("Substring: " + str2.Substring(5, 4));
            string[] words = str1.Split(new char[] { ' ' });
            Console.WriteLine("Split: ");
            for (int j = 0; j < words.Length; j++)
                Console.WriteLine(words[j]);
            Console.WriteLine("Insert: " + str1.Insert(8, str2));
            str1 = str1.Remove(0, 7);
            Console.WriteLine($"Remove: {str1}");
            Console.WriteLine();

            //isNullOrEmpty
            string strTemp = String.Empty;
            string nullString = null;
            if (String.IsNullOrEmpty(strTemp))
            {
                strTemp = "Liberty";
                Console.WriteLine(strTemp);
            }
            else
                Console.WriteLine("String isn't empty");
            Console.WriteLine();

            //StringBuilder
            StringBuilder strBuild = new StringBuilder("Hello world");
            Console.WriteLine("Build string: " + strBuild);
            Console.WriteLine("Length: " + strBuild.Length);
            Console.WriteLine("Capacity: " + strBuild.Capacity);
            strBuild = strBuild.Remove(5, 1);
            Console.WriteLine("Remove some index: " + strBuild);
            strBuild = strBuild.Insert(0, "*");
            strBuild = strBuild.Append("*");
            Console.WriteLine("Add some symbol: " + strBuild);


            //Task 3 - arrays
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n/////////////////Task 3////////////////\n");
            Console.ResetColor();

            int[,] arr = { { 10, 2, 3 }, { 25, 10, 384 } };
            for (var k = 0; k < 2; k++)
            {
                for (var t = 0; t < 3; t++)
                {
                    Console.Write("\t" + arr[k, t]);
                }
                Console.WriteLine("\n\n");
            }

            string[] arrString = { "Hello", "World", "Freedom", "London", "Belarus" };
            int arrSize = arrString.Length;
            int index;
            Console.WriteLine("Array size: " + arrSize);
            foreach (var r in arrString)
                Console.Write("  " + r);
            Console.WriteLine();
            do
            {
                Console.WriteLine("Enter the index of the element which you want to replace: ");
                index = Convert.ToInt32(Console.ReadLine());
                if (index >= arrSize)
                    Console.WriteLine("Entered index is more than the array size. Try again, please");
            } while (index >= arrSize);

            Console.WriteLine("Enter a new string: ");
            arrString[index - 1] = Convert.ToString(Console.ReadLine());
            foreach (var r in arrString)
                Console.Write("  " + r);
            Console.WriteLine();

            double[][] arrJag = { new double[2], new double[3], new double[4] };
            Console.WriteLine("Enter the array elements: ");
            for (var j = 0; j < arrJag.Length; j++)
            {
                for (var k = 0; k < arrJag[j].Length; k++)
                {
                    arrJag[j][k] = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            for (var j = 0; j < arrJag.Length; j++)
            {
                for (var k = 0; k < arrJag[j].Length; k++)
                {
                    Console.Write("\t" + arrJag[j][k]);
                }
                Console.WriteLine();
            }

            var arrVar = new[] { 10, 23, 135 };
            var varString = "Hello world";

            //Task 4 - tuples
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n/////////////////Task 4////////////////\n");
            Console.ResetColor();

            (string name, string surname, int age, char word, ulong number) person = ("Elon", "Musk", 49, 'X', 729439101451);
            Console.WriteLine($"About founder of SpaceX: \n Name: {person.name}\n Surname: {person.surname}\n Age:{person.age}\n Some word: {person.word}\n Number: {person.number}");
            Console.WriteLine($"Elemets:\n First: {person.Item1} \n Third: {person.Item3} \n Fourth: {person.Item4}");

            var tuple1 = ("BSTU", 19);
            (string university, int age) = tuple1;

            var tuple2 = ("Kamenets", 1276);
            var (city, date) = tuple2;

            var BSTU = String.Empty;
            var varAge = 0;
            (BSTU, varAge) = tuple1;

            var tuple3 = ("Hello", "World", 1276, true);
            string[] arr3 = new string[3];
            (arr3[0], arr3[1], _, _) = tuple3;
            Console.WriteLine($"arr[0] = {arr3[0]}\narr[1] = {arr3[1]}");

            if (tuple1 == tuple2)
                Console.WriteLine("Tuples are equal");
            else
                Console.WriteLine("Tuples aren't equal");

            //Task 5 - local function 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n/////////////////Task 5////////////////\n");
            Console.ResetColor();

            string localString = "Hello, bro";
            int[] localArray = { 10, 20, 35, 1, 25, 0, 8 };

            Console.WriteLine($"String: {localString}");
            Console.Write("Array: ");
            foreach (var n in localArray)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine("\n");

            (int min, int max, int sum, char firstWord) TestFunction(string tempStr,int[] tempArr)
            {
                int min = tempArr[0];
                int max = tempArr[0];
                int sum = 0;
                char[] allWords = tempStr.ToArray();
                char firstWord = allWords[0];

                for (var i = 0; i < tempArr.Length; i++)
                {
                    if (tempArr[i] > max)
                        max = tempArr[i];
                    else if (tempArr[i] < min)
                        min = tempArr[i];

                    sum = sum + tempArr[i];
                }

                return (min, max, sum, firstWord);
            }

            (int min, int max, int sum, char firstWord) result = TestFunction(localString, localArray);
            Console.WriteLine($"Elements from function:\n Min: {result.min}\n Max: {result.max}\n Sum: {result.sum}\n First word: {result.firstWord}");

            //Task 6 - checked & unchecked 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n/////////////////Task 6////////////////\n");
            Console.ResetColor();

            int Checked()
            {
                int a = checked(2_147_483_647); // 2_147_483_647 + 10 - Error
                return a;
            }

            int Unchecked()
            {
                int b = unchecked(2_147_483_647 + 10);
                return b;
            }

            int checkedVar = Checked();
            int uncheckedVar = Unchecked();
            Console.WriteLine($"Result of checked: {checkedVar}\nResult of unchecked: {uncheckedVar}");
            Console.Read();


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
