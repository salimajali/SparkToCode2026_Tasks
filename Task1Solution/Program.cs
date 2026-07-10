namespace Task1Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
			// Task 1 : Personal Info Card

			{
				string name = "Salima";
				int age = 24;
				double height = 1.53;
				bool isStudent = true;

				Console.WriteLine("Personal Information Card");
				Console.WriteLine("-------------------------");
				Console.WriteLine("Name: " + name);
				Console.WriteLine("Age: " + age);
				Console.WriteLine("Height: " + height);
				Console.WriteLine("Student: " + isStudent);

				// Task 2 : Rectangle Calculator


				Console.Write("Enter the rectangle length: ");
				double length = double.Parse(Console.ReadLine());

				Console.Write("Enter the rectangle width: ");
				double width = double.Parse(Console.ReadLine());

				double area = length * width;
				double perimeter = 2 * (length + width);

				Console.WriteLine("Area: " + area);
				Console.WriteLine("Perimeter: " + perimeter);


				// Task 3 : Even or Odd Checker

				Console.Write("Enter a whole number: ");
				int number = int.Parse(Console.ReadLine());

				if (number % 2 == 0)
				{
					Console.WriteLine("The number is even.");
				}
				else
				{
					Console.WriteLine("The number is odd.");
				}

				// Task 4 : Voting Eligibility

				Console.Write("Enter your age: ");
				int age = int.Parse(Console.ReadLine());

				Console.Write("Do you have a valid national ID? yes/no: ");
				string idAnswer = Console.ReadLine();

				bool hasValidId;

				if (idAnswer == "yes")
				{
					hasValidId = true;
				}
				else
				{
					hasValidId = false;
				}

				if (age >= 18 && hasValidId == true)
				{
					Console.WriteLine("You are eligible to vote.");
				}
				else
				{
					Console.WriteLine("You are not eligible to vote.");
				}

				// Task 5 : Grade Letter Lookup
				Console.Write("Enter your grade: ");
				string grade = Console.ReadLine();

				switch (grade)
				{
					case "A":
						Console.WriteLine("Excellent");
						break;

					case "B":
						Console.WriteLine("Very Good");
						break;

					case "C":
						Console.WriteLine("Good");
						break;

					case "D":
						Console.WriteLine("Pass");
						break;

					case "F":
						Console.WriteLine("Fail");
						break;

					default:
						Console.WriteLine("Invalid grade");
						break;
				}

				// Task 6 : Temperature Converter

				Console.Write("Enter the temperature in Celsius: ");
				double celsius = double.Parse(Console.ReadLine());

				double fahrenheit = (celsius * 9 / 5) + 32;

				Console.WriteLine("Temperature in Fahrenheit: " + fahrenheit);

				if (celsius < 10)
				{
					Console.WriteLine("Weather classification: Cold");
				}
				else if (celsius <= 30)
				{
					Console.WriteLine("Weather classification: Mild");
				}
				else
				{
					Console.WriteLine("Weather classification: Hot");
				}
				// Task 7 : Movie Ticket Pricing

				Console.Write("Enter your age: ");
				int age = int.Parse(Console.ReadLine());

				string category;
				double price;

				if (age >= 0 && age <= 12)
				{
					category = "Child";
					price = 2.000;
				}
				else if (age >= 13 && age <= 59)
				{
					category = "Adult";
					price = 5.000;
				}
				else
				{
					category = "Senior";
					price = 3.000;
				}

				Console.WriteLine("Category: " + category);
				Console.WriteLine("Ticket Price: " + price + " OMR");


				// Task 8 : Restaurant Bill with Membership Discount

				Console.Write("Enter the total bill amount: ");
				double originalBill = double.Parse(Console.ReadLine());

				Console.Write("Are you a loyalty member? yes/no: ");
				string memberAnswer = Console.ReadLine();

				bool isMember;

				if (memberAnswer == "yes")
				{
					isMember = true;
				}
				else
				{
					isMember = false;
				}

				double discountAmount = 0;

				if (originalBill > 20 && isMember == true)
				{
					discountAmount = originalBill * 0.15;
				}

				double finalAmount = originalBill - discountAmount;

				Console.WriteLine("Original Bill: " + originalBill + " OMR");
				Console.WriteLine("Discount Amount: " + discountAmount + " OMR");
				Console.WriteLine("Final Amount: " + finalAmount + " OMR");

				//Task 9 : Day Name Finder

				Console.Write("Enter a day number from 1 to 7: ");
				int dayNumber = int.Parse(Console.ReadLine());

				switch (dayNumber)
				{
					case 1:
						Console.WriteLine("Sunday");
						break;

					case 2:
						Console.WriteLine("Monday");
						break;

					case 3:
						Console.WriteLine("Tuesday");
						break;

					case 4:
						Console.WriteLine("Wednesday");
						break;

					case 5:
						Console.WriteLine("Thursday");
						break;

					case 6:
						Console.WriteLine("Friday");
						break;

					case 7:
						Console.WriteLine("Saturday");
						break;

					default:
						Console.WriteLine("Invalid day number");
						break;
				}

				//Task 10 : Mini Calculator

				Console.Write("Enter the first number: ");
				double firstNumber = double.Parse(Console.ReadLine());

				Console.Write("Enter the second number: ");
				double secondNumber = double.Parse(Console.ReadLine());

				Console.Write("Enter an operator (+, -, *, /, %): ");
				string operatorChoice = Console.ReadLine();

				switch (operatorChoice)
				{
					case "+":
						Console.WriteLine("Result: " + (firstNumber + secondNumber));
						break;

					case "-":
						Console.WriteLine("Result: " + (firstNumber - secondNumber));
						break;

					case "*":
						Console.WriteLine("Result: " + (firstNumber * secondNumber));
						break;

					case "/":
						if (secondNumber != 0)
						{
							Console.WriteLine("Result: " + (firstNumber / secondNumber));
						}
						else
						{
							Console.WriteLine("Cannot divide by zero");
						}
						break;

					case "%":
						if (secondNumber != 0)
						{
							Console.WriteLine("Result: " + (firstNumber % secondNumber));
						}
						else
						{
							Console.WriteLine("Cannot divide by zero");
						}
						break;

					default:
						Console.WriteLine("Invalid operator");
						break;
				}



			}
		}
}
		}
	}
}
	}
}
