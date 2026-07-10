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

			// Task 4 : Subscription End Date
			Console.Write("Enter the number of free trial days: ");
			int trialDays = int.Parse(Console.ReadLine());

			DateTime startDate = DateTime.Today;
			DateTime endDate = startDate.AddDays(trialDays);

			Console.WriteLine(
				"Trial End Date: " +
				endDate.ToString("yyyy-MM-dd")
			);

			// Task 5 : Grade Rounding System

			Console.Write("Enter the raw exam score: ");
			double rawScore = double.Parse(Console.ReadLine());

			double roundedScore = Math.Round(rawScore, 0);

			Console.WriteLine("Rounded Score: " + roundedScore);

			if (roundedScore >= 60)
			{
				Console.WriteLine("Result: Pass");
			}
			else
			{
				Console.WriteLine("Result: Fail");
			}

			// Task 6 : Password Strength Checker
			Console.Write("Enter a password: ");
			string password = Console.ReadLine();

			bool hasMinimumLength = password.Length >= 8;

			bool containsForbiddenWord =
				password.ToLower().Contains("password");

			if (hasMinimumLength && !containsForbiddenWord)
			{
				Console.WriteLine("Password Strength: Strong");
			}
			else
			{
				Console.WriteLine("Password Strength: Weak");

				if (!hasMinimumLength)
				{
					Console.WriteLine(
						"Reason: Password must be at least 8 characters long."
					);
				}

				if (containsForbiddenWord)
				{
					Console.WriteLine(
						"Reason: Password must not contain the word 'password'."
					);
				}
			}





		}
	}
}
