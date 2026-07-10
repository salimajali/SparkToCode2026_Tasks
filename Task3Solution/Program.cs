namespace Task3Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
			// Task 1 : Absolute Difference 
			Console.Write("Enter the first number: ");
			double firstNumber = double.Parse(Console.ReadLine());

			Console.Write("Enter the second number: ");
			double secondNumber = double.Parse(Console.ReadLine());

			double difference = firstNumber - secondNumber;
			double positiveDifference = Math.Abs(difference);

			Console.WriteLine("Positive Difference: " + positiveDifference);

			// Task 2 : Power & Root Explorer
			Console.Write("Enter a number: ");
			double number = double.Parse(Console.ReadLine());

			double square = Math.Pow(number, 2);
			double squareRoot = Math.Sqrt(number);

			Console.WriteLine("Square: " + square);
			Console.WriteLine("Square Root: " + squareRoot);

			// Task 3 : Name Formatter
			Console.Write("Enter your full name: ");
			string fullName = Console.ReadLine();

			string upperName = fullName.ToUpper();
			string lowerName = fullName.ToLower();
			int characterCount = fullName.Length;

			Console.WriteLine("Uppercase: " + upperName);
			Console.WriteLine("Lowercase: " + lowerName);
			Console.WriteLine("Number of Characters: " + characterCount);

		}
	}
}
