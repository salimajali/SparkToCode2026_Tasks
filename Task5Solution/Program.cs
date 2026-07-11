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



		}
	}
}
