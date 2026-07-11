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

			//




		}
	}
}
