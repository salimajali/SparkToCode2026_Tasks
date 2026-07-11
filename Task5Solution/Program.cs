namespace Task5Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
			//Task 1 : Fixed Grades Array
			int[] grades = new int[5];

			// Enter grades using for loop
			for (int counter = 0; counter < grades.Length; counter++)
			{
				Console.WriteLine("Enter grade number " + (counter + 1) + ":");
				grades[counter] = int.Parse(Console.ReadLine());
			}

			// Print grades using foreach loop
			Console.WriteLine("Student Grades:");

			foreach (int grade in grades)
			{
				Console.WriteLine(grade);
			}

			// Task 2 : Dynamic To-Do List
			List<string> todoList = new List<string>();

			for (int counter = 0; counter < 5; counter++)
			{
				Console.WriteLine("Enter task number " + (counter + 1) + ":");
				string task = Console.ReadLine();

				todoList.Add(task);
			}

			Console.WriteLine("To-Do List:");

			int taskNumber = 1;

			foreach (string task in todoList)
			{
				Console.WriteLine(taskNumber + ". " + task);
				taskNumber++;
			}

			//Task 3 : Browsing History Stack
			Stack<string> browserHistory = new Stack<string>();

			for (int counter = 0; counter < 3; counter++)
			{
				Console.WriteLine("Enter website URL:");
				string url = Console.ReadLine();

				browserHistory.Push(url);
			}

			string currentPage = browserHistory.Pop();

			Console.WriteLine("Going back from: " + currentPage);

			if (browserHistory.Count > 0)
			{
				string previousPage = browserHistory.Peek();

				Console.WriteLine("You are now on: " + previousPage);
			}

			// Task 4 : Customer Service Queue
			Queue<string> customerQueue = new Queue<string>();

			for (int counter = 0; counter < 3; counter++)
			{
				Console.WriteLine("Enter customer name:");
				string customerName = Console.ReadLine();

				customerQueue.Enqueue(customerName);
			}

			string servedCustomer = customerQueue.Dequeue();

			Console.WriteLine("Customer served: " + servedCustomer);

			Console.WriteLine("Customers still waiting:");

			foreach (string customer in customerQueue)
			{
				Console.WriteLine(customer);
			}

			// Task 5 : Array Grade Range
			int[] grades1 = new int[5];
			int total = 0;

			for (int counter = 0; counter < grades.Length; counter++)
			{
				Console.WriteLine("Enter grade number " + (counter + 1) + ":");
				grades[counter] = int.Parse(Console.ReadLine());

				total = total + grades[counter];
			}

			Array.Sort(grades);

			int lowestGrade = grades[0];
			int highestGrade = grades[grades.Length - 1];

			double average = total / 5.0;

			Console.WriteLine("Lowest Grade: " + lowestGrade);
			Console.WriteLine("Highest Grade: " + highestGrade);
			Console.WriteLine("Average Grade: " + average);

			// Task 6 : Filtered Shopping List

			List<string> shoppingList = new List<string>();

			string item = "";

			while (item.ToLower() != "done")
			{
				Console.WriteLine("Enter an item or type done:");
				item = Console.ReadLine();

				if (item.ToLower() != "done")
				{
					shoppingList.Add(item);
				}
			}

			Console.WriteLine("Shopping List Before Removal:");

			foreach (string shoppingItem in shoppingList)
			{
				Console.WriteLine(shoppingItem);
			}

			Console.WriteLine("Enter an item to remove:");
			string itemToRemove = Console.ReadLine();

			bool itemRemoved = shoppingList.Remove(itemToRemove);

			if (itemRemoved == true)
			{
				Console.WriteLine("Item removed successfully.");
			}
			else
			{
				Console.WriteLine("Item was not found.");
			}

			Console.WriteLine("Shopping List After Removal:");

			foreach (string shoppingItem in shoppingList)
			{
				Console.WriteLine(shoppingItem);
			}

			// Task 7 : High Score Podium

			List<int> gameScores = new List<int>();

			for (int counter = 0; counter < 5; counter++)
			{
				Console.WriteLine("Enter game score number " + (counter + 1) + ":");
				int score = int.Parse(Console.ReadLine());

				gameScores.Add(score);
			}

			gameScores.Sort();
			gameScores.Reverse();

			Console.WriteLine("High Score Podium:");

			Console.WriteLine("1st place: " + gameScores[0]);
			Console.WriteLine("2nd place: " + gameScores[1]);
			Console.WriteLine("3rd place: " + gameScores[2]);






		}
	}
}
