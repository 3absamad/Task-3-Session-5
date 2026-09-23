using Common;
using System.Runtime.InteropServices;
namespace Task_3_Session_5
{
    enum WeekDays
    { 
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    enum Colors
    {
        Red,
        Green,
        Blue
    }
    internal class Program
    {
        static void ValueTypeByValue(int number)
        {
            number = 100;
        }

        static void ValueTypeByRef(ref int number)
        {
            number = 20;
        }

        static void RefTypeByValue(string message)
        {
            message = "Hello World";
        }

        static void RefTypeByRef(ref string message)
        {
            message = "Hello World";
        }

        static void Calculate(int num1, int num2, out int sum, out int subtraction)
        {
            sum = num1 + num2;
            subtraction = num1 - num2;
        }

        static int SumOfDigits(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                int digit = number % 10;
                sum += digit;
                number /= 10;
            }

            return sum;
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        static void MinMaxArray(int[] arr, ref int min, ref int max)
        {
            min = arr[0];
            max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];

                if (arr[i] > max)
                    max = arr[i];
            }
        }

        static int Factorial(int number)
        {
            int result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        static string ChangeChar(string text, int position, char newChar)
        {
            char[] chars = text.ToCharArray();

            chars[position] = newChar;

            return new string(chars);
        }

        static double CalculateDistance(Point p1, Point p2)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }


        static void Main(string[] args)
        {
            /*
             * Function Q1: Value Type by Value vs By Reference
             * - By Value: A copy of the actual value is passed. Modifying the parameter inside the function 
             *   does not affect the original variable.
             * - By Reference (using 'ref' or 'out'): The memory address is passed. Modifying the parameter 
             *   inside the function directly affects the original variable.
             */

            int val1 = 10;
            ValueTypeByValue(val1); // val1 remains 10
            Console.WriteLine(val1);
            ValueTypeByRef(ref val1); // val1 becomes 20
            Console.WriteLine(val1);

            ///*
            // * Function Q2: Reference Type by Value vs By Reference
            // * - By Value: A copy of the reference (pointer) is passed. You can modify the object's properties, 
            // *   but if you assign a completely NEW object to the parameter, the original variable won't point to it.
            // * - By Reference: A reference to the reference is passed. If you assign a completely new object 
            // *   inside the method, the original variable will update to point to the new object.
            // */

            string msg = "Hello";
            RefTypeByValue(msg); // Message remains Hello.
            Console.WriteLine(msg);
            RefTypeByRef(ref msg); // Completely reassigns the array to a new one.
            Console.WriteLine(msg);
            ////------------------------------------------------------------------------------------------------------------------

            // Function Q3:
            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine());

            Calculate(num1, num2, out int sum, out int subtraction);

            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Subtraction = " + subtraction);

            //Function Q4:
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            int result = SumOfDigits(number);

            Console.WriteLine($"The sum of the digits of the number {number} is: {result}");

            //Function Q5:
            Console.Write("Enter a number: ");
            int number1 = int.Parse(Console.ReadLine());

            if (IsPrime(number1))
                Console.WriteLine("The number is prime.");
            else
                Console.WriteLine("The number is not prime.");

            //Function Q6:
            int[] numbers = { 10, 5, 20, 3, 15 };

            int min = 0;
            int max = 0;

            MinMaxArray(numbers, ref min, ref max);

            Console.WriteLine("Minimum = " + min);
            Console.WriteLine("Maximum = " + max);

            //Function Q7:
            Console.Write("Enter a number: ");
            int number2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Factorial = " + Factorial(number2));

            //Function Q8:
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            Console.Write("Enter position: ");
            int position = int.Parse(Console.ReadLine());

            Console.Write("Enter new character: ");
            char newChar = char.Parse(Console.ReadLine());

            string result1 = ChangeChar(text, position, newChar);

            Console.WriteLine("Result: " + result1);
            //------------------------------------------------------------------------------------------------------------------

            //Enum Q1:
            foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine(day);
            }

            //Struct Q2:
            Person[] persons = new Person[3];

            persons[0] = new Person { Name = "Omar", Age = 20 };
            persons[1] = new Person { Name = "Ahmed", Age = 19 };
            persons[2] = new Person { Name = "Youssef", Age = 21 };

            foreach (Person person in persons)
            {
                Console.WriteLine($"Name: {person.Name}, Age:{person.Age}");
            }

            //Enum Q3:
            Console.Write("Enter a season: ");
            string input = Console.ReadLine();

            if (Enum.TryParse(input, true, out Season season))
            {
                switch (season)
                {
                    case Season.Spring:
                        Console.WriteLine("March to May");
                        break;

                    case Season.Summer:
                        Console.WriteLine("June to August");
                        break;

                    case Season.Autumn:
                        Console.WriteLine("September to November");
                        break;

                    case Season.Winter:
                        Console.WriteLine("December to February");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid season.");
            }

            //Enum Q4: SO hard, I didnt get it

            //Enum Q5:
            Console.WriteLine("Enter A Color: ");
            string input1 = Console.ReadLine();

            if (Enum.TryParse(input1, true, out Colors color))
            {
                if (color == Colors.Red || color == Colors.Blue || color == Colors.Green)
                {
                    Console.WriteLine("The color is primary color");
                }
            }
            else
            {
                Console.WriteLine("Invalid Color");
            }

            //Struct Q6:
            Point p1 = new Point();
            Point p2 = new Point();

            Console.Write("Enter X1: ");
            p1.X = double.Parse(Console.ReadLine());

            Console.Write("Enter Y1: ");
            p1.Y = double.Parse(Console.ReadLine());

            Console.Write("Enter X2: ");
            p2.X = double.Parse(Console.ReadLine());

            Console.Write("Enter Y2: ");
            p2.Y = double.Parse(Console.ReadLine());

            double distance = CalculateDistance(p1, p2);

            Console.WriteLine("Distance = " + distance);

            //Struct Q7:
            Person[] persons1 = new Person[3];

            for (int i = 0; i < persons1.Length; i++)
            {
                Console.Write("Enter name: ");
                persons1[i].Name = Console.ReadLine();

                Console.Write("Enter age: ");
                persons1[i].Age = int.Parse(Console.ReadLine());
            }

            Person oldest = persons1[0];

            for (int i = 1; i < persons1.Length; i++)
            {
                if (persons1[i].Age > oldest.Age)
                {
                    oldest = persons1[i];
                }
            }

            Console.WriteLine(
                $"Oldest person: {oldest.Name}, Age: {oldest.Age}"
            );

        }
    }
}
