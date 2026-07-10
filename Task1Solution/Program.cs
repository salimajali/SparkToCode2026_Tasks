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


			}
		}
}
		}
	}
}
	}
}
