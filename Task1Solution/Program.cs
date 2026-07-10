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


		}
	}
}
		}
	}
}
	}
}
