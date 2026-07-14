namespace Task5Solution
{
    internal class Program
    {

		//Task 9 
		public static double CalculateAverage(List<int> grades)
		{
			int total = 0;

			foreach (int grade in grades)
			{
				total = total + grade;
			}

			if (grades.Count == 0)
			{
				return 0;
			}

			double average = (double)total / grades.Count;

			return average;
		}

		// Find the first grade below 60
		public static int FindFirstFailing(List<int> grades)
		{
			int firstFailingGrade = grades.Find(grade => grade < 60);

			return firstFailingGrade;
		}

		// Task 10 
		public static Queue<string> RemoveJob(
		   Queue<string> printQueue,
		   string jobToRemove
	   )
		{
			Queue<string> updatedQueue = new Queue<string>();

			while (printQueue.Count > 0)
			{
				string currentJob = printQueue.Dequeue();

				if (currentJob.ToLower() != jobToRemove.ToLower())
				{
					updatedQueue.Enqueue(currentJob);
				}
			}

			return updatedQueue;
		}


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

			// Task 8 : Undo Last Action
			Stack<string> editorActions = new Stack<string>();

			string action = "";

			while (action.ToLower() != "stop")
			{
				Console.WriteLine("Enter an action or type stop:");
				action = Console.ReadLine();

				if (action.ToLower() != "stop")
				{
					editorActions.Push(action);
				}
			}

			Console.WriteLine("Undo Actions:");

			if (editorActions.Count > 0)
			{
				string firstUndo = editorActions.Pop();

				Console.WriteLine("Undone: " + firstUndo);
			}

			if (editorActions.Count > 0)
			{
				string secondUndo = editorActions.Pop();

				Console.WriteLine("Undone: " + secondUndo);
			}

			Console.WriteLine("Remaining Actions:");

			if (editorActions.Count == 0)
			{
				Console.WriteLine("No actions remaining.");
			}
			else
			{
				foreach (string remainingAction in editorActions)
				{
					Console.WriteLine(remainingAction);
				}
			}

			// Task 9 : Grade Analyzer with Functions

			List<int> grades2 = new List<int>();

			Console.WriteLine("How many grades do you want to enter?");
			int numberOfGrades = int.Parse(Console.ReadLine());

			for (int counter = 0; counter < numberOfGrades; counter++)
			{
				Console.WriteLine("Enter grade number " + (counter + 1) + ":");
				int grade = int.Parse(Console.ReadLine());

				grades2.Add(grade);
			}

			double average1 = CalculateAverage(grades2);

			Console.WriteLine("Average Grade: " + average1);

			int failingGrade = FindFirstFailing(grades2);

			if (failingGrade == 0)
			{
				Console.WriteLine("No failing grade was found.");
			}
			else
			{
				Console.WriteLine("First Failing Grade: " + failingGrade);
			}


			// Task 10 : Print Queue Manager
			Queue<string> printQueue = new Queue<string>();

			string printJob = "";

			while (printJob.ToLower() != "done")
			{
				Console.WriteLine("Enter print job name or type done:");
				printJob = Console.ReadLine();

				if (printJob.ToLower() != "done")
				{
					printQueue.Enqueue(printJob);
				}
			}

			Console.WriteLine("Print Queue Before Cancellation:");

			if (printQueue.Count == 0)
			{
				Console.WriteLine("The print queue is empty.");
			}
			else
			{
				foreach (string job in printQueue)
				{
					Console.WriteLine(job);
				}
			}

			Console.WriteLine("Enter the print job you want to cancel:");
			string jobToRemove = Console.ReadLine();

			printQueue = RemoveJob(printQueue, jobToRemove);

			Console.WriteLine("Print Queue After Cancellation:");

			if (printQueue.Count == 0)
			{
				Console.WriteLine("The print queue is empty.");
			}
			else
			{
				foreach (string job in printQueue)
				{
					Console.WriteLine(job);
				}
			}





		}
	}
}
