namespace Task2Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
			// Task 1 : Countdown Timer
			Console.Write("Enter a starting number: ");
			int startingNumber = int.Parse(Console.ReadLine());

			for (int counter = startingNumber; counter >= 1; counter--)
			{
				Console.WriteLine(counter);
			}

			Console.WriteLine("Liftoff!");

			// Task 2 : Sum of Numbers 1 to N
			Console.Write("Enter a positive whole number: ");
			int number = int.Parse(Console.ReadLine());

			int total = 0;

			for (int counter = 1; counter <= number; counter++)
			{
				total = total + counter;
			}

			Console.WriteLine("Final Sum: " + total);

			// Task 3 : Multiplication Table

			Console.Write("Enter a number: ");
			int number1 = int.Parse(Console.ReadLine());

			for (int counter = 1; counter <= 10; counter++)
			{
				int result = number * counter;

				Console.WriteLine(
					number + " x " + counter + " = " + result
				);
			}
		}
	}
}
