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




		}
	}
}
