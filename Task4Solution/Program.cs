namespace Task4Solution
{
    internal class Program
    {
		public static void PrintWelcome(string name)
		{
			Console.WriteLine("Welcome to the application, " + name);
		}

		public static int Square(int number)
		{
			int result = number * number;

			return result;
		}

		public static double CelsiusToFahrenheit(double celsius)
		{
			double fahrenheit = (celsius * 9 / 5) + 32;

			return fahrenheit;
		}

		public static void DisplayMenu()
		{
			Console.WriteLine("Main Menu");
			Console.WriteLine("1. Start");
			Console.WriteLine("2. Help");
			Console.WriteLine("3. Exit");
		}

		public static bool IsEven(int number)
		{
			if (number % 2 == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static double CalculateArea(double length, double width)
		{
			double area = length * width;

			return area;
		}

		// Calculate rectangle perimeter
		public static double CalculatePerimeter(double length, double width)
		{
			double perimeter = 2 * (length + width);

			return perimeter;
		}

		public static string GetGradeLetter(int score)
		{
			if (score >= 90)
			{
				return "A";
			}
			else if (score >= 80)
			{
				return "B";
			}
			else if (score >= 70)
			{
				return "C";
			}
			else if (score >= 60)
			{
				return "D";
			}
			else
			{
				return "F";
			}
		}


		static void Main(string[] args)
        {
			// Task 1 : Personalized Welcome Function: 
			Console.WriteLine("Enter your name:");
			string userName = Console.ReadLine();

			// Function call
			PrintWelcome(userName);

			// Task 2 : Square Number Function

			Console.WriteLine("Enter a number:");
			int userNumber = int.Parse(Console.ReadLine());

			int squareResult = Square(userNumber);

			Console.WriteLine("Square result: " + squareResult);


			// Task 3 : Celsius to Fahrenheit Function
			Console.WriteLine("Enter temperature in Celsius:");
			double celsius = double.Parse(Console.ReadLine());

			double result = CelsiusToFahrenheit(celsius);

			Console.WriteLine("Temperature in Fahrenheit: " + result);

			// Task 4 : Fixed Menu Display Function
			// Function call
			DisplayMenu();

			// Task 5 : Even or Odd Function
			Console.WriteLine("Enter a number:");
			int userNumber1 = int.Parse(Console.ReadLine());

			bool result2 = IsEven(userNumber);

			if (result2 == true)
			{
				Console.WriteLine("Even");
			}
			else
			{
				Console.WriteLine("Odd");
			}

			// Task 6 : Rectangle Area & Perimeter Functions
			Console.WriteLine("Enter rectangle length:");
			double length = double.Parse(Console.ReadLine());

			Console.WriteLine("Enter rectangle width:");
			double width = double.Parse(Console.ReadLine());

			double area = CalculateArea(length, width);
			double perimeter = CalculatePerimeter(length, width);

			Console.WriteLine("Area: " + area);
			Console.WriteLine("Perimeter: " + perimeter);

			// Task 7 : Grade Letter Function
			Console.WriteLine("Enter your score:");
			int score = int.Parse(Console.ReadLine());

			string grade = GetGradeLetter(score);

			Console.WriteLine("Grade: " + grade);






		}
	}
}
