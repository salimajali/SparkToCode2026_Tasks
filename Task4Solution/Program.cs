namespace Task4Solution
{
		internal class Program
		{
			public static void PrintWelcome(string name)
			{
				Console.WriteLine("Welcome to the application, " + name);
			}

			static void Main(string[] args)
			{
				Console.Write("Enter your name: ");
				string userName = Console.ReadLine();

				PrintWelcome(userName);
			}
		}
	}