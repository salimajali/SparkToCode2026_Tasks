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

			// Task 7 : Clean Name Comparator
			Console.Write("Enter the first name: ");
			string firstName = Console.ReadLine();

			Console.Write("Enter the second name: ");
			string secondName = Console.ReadLine();

			string cleanFirstName = firstName.Trim().ToUpper();
			string cleanSecondName = secondName.Trim().ToUpper();

			if (cleanFirstName == cleanSecondName)
			{
				Console.WriteLine("Match");
			}
			else
			{
				Console.WriteLine("No Match");
			}

			// Task 8 : Membership Expiry Checker
			try
			{
				Console.Write("Enter the membership start date (yyyy-MM-dd): ");
				DateTime startDate = DateTime.Parse(Console.ReadLine());

				Console.Write("Enter the number of valid membership days: ");
				int validDays = int.Parse(Console.ReadLine());

				DateTime expiryDate = startDate.AddDays(validDays);

				Console.WriteLine(
					"Expiry Date: " +
					expiryDate.ToString("yyyy-MM-dd")
				);

				if (expiryDate >= DateTime.Today)
				{
					Console.WriteLine("Membership Status: Active");
				}
				else
				{
					Console.WriteLine("Membership Status: Expired");
				}
			}
			catch (FormatException)
			{
				Console.WriteLine(
					"Invalid input. Please enter a valid date and number."
				);
			}

			// Task 9 : Round Up / Round Down Explorer
			Console.Write("Enter a decimal number: ");
			double number = double.Parse(Console.ReadLine());

			double nearestNumber = Math.Round(number);
			double roundedUp = Math.Ceiling(number);
			double roundedDown = Math.Floor(number);

			Console.WriteLine("Nearest Whole Number: " + nearestNumber);
			Console.WriteLine("Always Rounded Up: " + roundedUp);
			Console.WriteLine("Always Rounded Down: " + roundedDown);












		}
	}
}

