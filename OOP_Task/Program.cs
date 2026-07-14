namespace OOP_Task
{
	
	public class BankAccount
	{
		// Public properties
		public int AccountNumber { get; set; }
		public string HolderName { get; set; } = string.Empty;
		public double Balance { get; set; }

		// Case 18: Read-only property
		// It has a get accessor only, so it cannot be assigned from Program.
		public bool IsOverdrawn
		{
			get
			{
				return Balance < 0;
			}
		}

		// Default constructor
		public BankAccount()
		{
		}

		// Case 16: Parameterized constructor
		public BankAccount(int accountNumber, string holderName, double startingBalance)
		{
			AccountNumber = accountNumber;
			HolderName = holderName;
			Balance = startingBalance;
		}

		// Adds money to the account, then triggers the private email method.
		public void Deposit(double amount)
		{
			Balance += amount;
			SendEmail();
		}

		// Withdraws money only when the balance is sufficient.
		public void Withdraw(double amount)
		{
			if (Balance >= amount)
			{
				Balance -= amount;
				SendEmail();
			}
			else
			{
				Console.WriteLine("Withdrawal failed: insufficient balance.");
			}
		}

		// Displays the account information and returns the balance.
		public double CheckBalance()
		{
			PrintInformation();
			return Balance;
		}

		// Private: can only be called from inside BankAccount.
		private void PrintInformation()
		{
			Console.WriteLine("Holder Name: " + HolderName);
			Console.WriteLine("Balance: " + Balance.ToString("0.000") + " OMR");
		}

		// Private placeholder for an email notification.
		private void SendEmail()
		{
			Console.WriteLine("Account email notification triggered.");
		}
	}


	public class Student
	{
		// Public properties
		public int Grade { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;

		// Private/default-access members
		private string email = string.Empty;
		int age; // Default access is private inside a class.
		private string securityPin = string.Empty;

		// Case 17: Static field shared by all Student objects.
		private static int studentCount = 0;

		// Case 19: Write-only property
		// It has a set accessor only, so Program cannot read the PIN.
		public string SecurityPin
		{
			set
			{
				securityPin = value;

				// The value is checked internally but is never displayed.
				if (securityPin.Length != 4)
				{
					securityPin = string.Empty;
				}
			}
		}

		// Every new Student object increases the shared counter.
		public Student()
		{
			studentCount++;
		}

		// Stores the email privately, then calls the private email method.
		public void Register(string Email)
		{
			email = Email;
			SendEmail();
		}

		// Case 17: Called through the class name: Student.GetTotalStudents()
		public static int GetTotalStudents()
		{
			return studentCount;
		}

		// Private: cannot be called directly from Program.
		private void SendEmail()
		{
			// The private fields are used internally without revealing them.
			if (!string.IsNullOrWhiteSpace(email) && age >= 0)
			{
				Console.WriteLine("Student registration email notification triggered.");
			}
		}
	}


	public class Product
	{
		// Public properties
		public string ProductName { get; set; } = string.Empty;
		public double Price { get; set; }
		public int StockQuantity { get; set; }

		// Reduces stock only when enough units are available.
		public void Sell(int quantity)
		{
			if (StockQuantity >= quantity)
			{
				StockQuantity -= quantity;
			}
			else
			{
				Console.WriteLine("Not enough stock.");
			}

			// The brief requires logging whether the sale succeeds or fails.
			LogTransaction();
		}

		// Adds units to stock.
		public void Restock(int quantity)
		{
			StockQuantity += quantity;
			LogTransaction();
		}

		// Displays product details and returns the total inventory value.
		public double GetInventoryValue()
		{
			PrintDetails();
			return Price * StockQuantity;
		}

		// Private: can only be called from inside Product.
		private void PrintDetails()
		{
			Console.WriteLine("Product Name: " + ProductName);
			Console.WriteLine("Price: " + Price.ToString("0.000") + " OMR");
			Console.WriteLine("Stock Quantity: " + StockQuantity);
		}

		// Private placeholder for transaction logging.
		private void LogTransaction()
		{
			Console.WriteLine("Product transaction logged.");
		}
	}


	internal class Program
	{
		// Exactly two individually named BankAccount objects.
		private static BankAccount account1 = new BankAccount
		{
			AccountNumber = 1163,
			HolderName = "Karim",
			Balance = 120
		};

		private static BankAccount account2 = new BankAccount
		{
			AccountNumber = 15203,
			HolderName = "Ali",
			Balance = 63
		};

		// Exactly two individually named Student objects.
		private static Student student1 = new Student
		{
			Name = "Ali",
			Address = "Muscat",
			Grade = 65
		};

		private static Student student2 = new Student
		{
			Name = "Ahmed",
			Address = "Muscat",
			Grade = 70
		};

		// Exactly two individually named Product objects.
		private static Product product1 = new Product
		{
			ProductName = "Wireless Mouse",
			Price = 5.500,
			StockQuantity = 50
		};

		private static Product product2 = new Product
		{
			ProductName = "Mechanical Keyboard",
			Price = 15.750,
			StockQuantity = 20
		};

		private static void Main()
		{
			bool exitProgram = false;

			while (!exitProgram)
			{
				DisplayMenu();
				int choice = ReadMenuChoice();

				Console.WriteLine();

				switch (choice)
				{
					case 1:
						ViewAccountDetails();
						break;
					case 2:
						UpdateStudentAddress();
						break;
					case 3:
						MakeDeposit();
						break;
					case 4:
						MakeWithdrawal();
						break;
					case 5:
						ViewProductDetails();
						break;
					case 6:
						RegisterStudent();
						break;
					case 7:
						CompareAccountBalances();
						break;
					case 8:
						RestockProductAndCheckLevel();
						break;
					case 9:
						TransferBetweenAccounts();
						break;
					case 10:
						UpdateStudentGrade();
						break;
					case 11:
						DisplayStudentReportCard();
						break;
					case 12:
						DisplayAccountHealthStatus();
						break;
					case 13:
						BulkSaleWithRevenue();
						break;
					case 14:
						CheckScholarshipEligibility();
						break;
					case 15:
						FullBalanceTopUpFlow();
						break;
					case 16:
						QuickAccountOpening();
						break;
					case 17:
						DisplayTotalStudents();
						break;
					case 18:
						CheckOverdrawnAccount();
						break;
					case 19:
						SetStudentSecurityPin();
						break;
					case 20:
						exitProgram = true;
						Console.WriteLine("Goodbye!");
						break;
				}

				if (!exitProgram)
				{
					Pause();
				}
			}
		}

		
		private static void DisplayMenu()
		{
			Console.WriteLine("\n========== OOP PART 1 MENU ==========");
			Console.WriteLine("1.  View Account Details");
			Console.WriteLine("2.  Update Student Address");
			Console.WriteLine("3.  Make a Deposit");
			Console.WriteLine("4.  Make a Withdrawal");
			Console.WriteLine("5.  View Product Details");
			Console.WriteLine("6.  Register a Student");
			Console.WriteLine("7.  Compare Two Account Balances");
			Console.WriteLine("8.  Restock Product & Stock Level Check");
			Console.WriteLine("9.  Transfer Between Accounts");
			Console.WriteLine("10. Update Student Grade (Validated)");
			Console.WriteLine("11. Student Report Card");
			Console.WriteLine("12. Account Health Status");
			Console.WriteLine("13. Bulk Sale With Revenue Calculation");
			Console.WriteLine("14. Scholarship Eligibility Check");
			Console.WriteLine("15. Full Balance Top-Up Flow");
			Console.WriteLine("16. Quick Account Opening");
			Console.WriteLine("17. Total Students Counter");
			Console.WriteLine("18. Overdrawn Account Check");
			Console.WriteLine("19. Set Student Security PIN");
			Console.WriteLine("20. Exit");
			Console.WriteLine("=====================================");
		}

		private static int ReadMenuChoice()
		{
			while (true)
			{
				Console.Write("Choose an option from 1 to 20: ");
				string input = Console.ReadLine() ?? string.Empty;

				if (int.TryParse(input, out int choice) &&
					choice >= 1 && choice <= 20)
				{
					return choice;
				}

				Console.WriteLine("Invalid input. Please enter a number from 1 to 20.");
			}
		}

		private static BankAccount ChooseAccount()
		{
			while (true)
			{
				Console.WriteLine("1. " + account1.HolderName +
								  " (Account " + account1.AccountNumber + ")");
				Console.WriteLine("2. " + account2.HolderName +
								  " (Account " + account2.AccountNumber + ")");
				Console.Write("Choose an account (1 or 2): ");

				string choice = Console.ReadLine() ?? string.Empty;

				if (choice == "1")
				{
					return account1;
				}

				if (choice == "2")
				{
					return account2;
				}

				Console.WriteLine("Invalid choice. Please enter 1 or 2.\n");
			}
		}

		private static Student ChooseStudent()
		{
			while (true)
			{
				Console.WriteLine("1. " + student1.Name);
				Console.WriteLine("2. " + student2.Name);
				Console.Write("Choose a student (1 or 2): ");

				string choice = Console.ReadLine() ?? string.Empty;

				if (choice == "1")
				{
					return student1;
				}

				if (choice == "2")
				{
					return student2;
				}

				Console.WriteLine("Invalid choice. Please enter 1 or 2.\n");
			}
		}

		private static Product ChooseProduct()
		{
			while (true)
			{
				Console.WriteLine("1. " + product1.ProductName);
				Console.WriteLine("2. " + product2.ProductName);
				Console.Write("Choose a product (1 or 2): ");

				string choice = Console.ReadLine() ?? string.Empty;

				if (choice == "1")
				{
					return product1;
				}

				if (choice == "2")
				{
					return product2;
				}

				Console.WriteLine("Invalid choice. Please enter 1 or 2.\n");
			}
		}

		private static double ReadPositiveAmount(string message)
		{
			while (true)
			{
				Console.Write(message);
				string input = Console.ReadLine() ?? string.Empty;

				if (double.TryParse(input, out double amount) && amount > 0)
				{
					return amount;
				}

				Console.WriteLine("Invalid input. Enter a number greater than zero.");
			}
		}

		private static int ReadPositiveQuantity(string message)
		{
			while (true)
			{
				Console.Write(message);
				string input = Console.ReadLine() ?? string.Empty;

				if (int.TryParse(input, out int quantity) && quantity > 0)
				{
					return quantity;
				}

				Console.WriteLine("Invalid input. Enter a whole number greater than zero.");
			}
		}

		private static void Pause()
		{
			Console.WriteLine("\nPress any key to return to the menu...");
			Console.ReadKey();
			Console.Clear();
		}

	

		// Case 1: View Account Details
		private static void ViewAccountDetails()
		{
			BankAccount selectedAccount = ChooseAccount();
			double currentBalance = selectedAccount.CheckBalance();

			Console.WriteLine("Returned Balance: " +
							  currentBalance.ToString("0.000") + " OMR");
		}

		// Case 2: Update Student Address
		private static void UpdateStudentAddress()
		{
			Student selectedStudent = ChooseStudent();

			Console.Write("Enter the new address: ");
			string newAddress = Console.ReadLine() ?? string.Empty;

			if (string.IsNullOrWhiteSpace(newAddress))
			{
				Console.WriteLine("Address was not updated because it cannot be empty.");
				return;
			}

			selectedStudent.Address = newAddress;

			Console.WriteLine("Address updated successfully.");
			Console.WriteLine("Student: " + selectedStudent.Name);
			Console.WriteLine("New Address: " + selectedStudent.Address);
		}

		// Case 3: Make a Deposit
		private static void MakeDeposit()
		{
			BankAccount selectedAccount = ChooseAccount();
			double amount = ReadPositiveAmount("Enter the deposit amount: ");

			selectedAccount.Deposit(amount);

			Console.WriteLine("Deposit completed successfully.");
			Console.WriteLine("Account Holder: " + selectedAccount.HolderName);
			Console.WriteLine("Updated Balance: " +
							  selectedAccount.Balance.ToString("0.000") + " OMR");
		}

		// Case 4: Make a Withdrawal
		private static void MakeWithdrawal()
		{
			BankAccount selectedAccount = ChooseAccount();
			double amount = ReadPositiveAmount("Enter the withdrawal amount: ");
			double balanceBefore = selectedAccount.Balance;

			selectedAccount.Withdraw(amount);

			if (selectedAccount.Balance < balanceBefore)
			{
				Console.WriteLine("Withdrawal completed successfully.");
			}

			Console.WriteLine("Current Balance: " +
							  selectedAccount.Balance.ToString("0.000") + " OMR");
		}

		// Case 5: View Product Details
		private static void ViewProductDetails()
		{
			Product selectedProduct = ChooseProduct();
			double inventoryValue = selectedProduct.GetInventoryValue();

			Console.WriteLine("Total Inventory Value: " +
							  inventoryValue.ToString("0.000") + " OMR");
		}


		// Case 6: Register a Student
		private static void RegisterStudent()
		{
			Student selectedStudent = ChooseStudent();

			Console.Write("Enter the student's email: ");
			string enteredEmail = Console.ReadLine() ?? string.Empty;

			if (string.IsNullOrWhiteSpace(enteredEmail))
			{
				Console.WriteLine("Registration failed: email cannot be empty.");
				return;
			}

			selectedStudent.Register(enteredEmail);

			// Do not display the private email.
			Console.WriteLine(selectedStudent.Name + " registered successfully.");
		}

		// Case 7: Compare Two Account Balances
		private static void CompareAccountBalances()
		{
			Console.WriteLine(account1.HolderName + "'s Balance: " +
							  account1.Balance.ToString("0.000") + " OMR");
			Console.WriteLine(account2.HolderName + "'s Balance: " +
							  account2.Balance.ToString("0.000") + " OMR");

			if (account1.Balance > account2.Balance)
			{
				Console.WriteLine(account1.HolderName + " has the higher balance.");
			}
			else if (account2.Balance > account1.Balance)
			{
				Console.WriteLine(account2.HolderName + " has the higher balance.");
			}
			else
			{
				Console.WriteLine("Both accounts have equal balances.");
			}
		}

		// Case 8: Restock Product & Stock Level Check
		private static void RestockProductAndCheckLevel()
		{
			Product selectedProduct = ChooseProduct();
			int quantity = ReadPositiveQuantity("Enter the quantity to add: ");

			selectedProduct.Restock(quantity);

			string stockLevel;

			if (selectedProduct.StockQuantity < 10)
			{
				stockLevel = "Low";
			}
			else if (selectedProduct.StockQuantity <= 49)
			{
				stockLevel = "Moderate";
			}
			else
			{
				stockLevel = "Well Stocked";
			}

			Console.WriteLine("Product restocked successfully.");
			Console.WriteLine("Updated Stock: " + selectedProduct.StockQuantity);
			Console.WriteLine("Stock Level: " + stockLevel);
		}

	

		// Case 9: Transfer Between Accounts
		private static void TransferBetweenAccounts()
		{
			Console.WriteLine("Choose the source account:");
			BankAccount sourceAccount = ChooseAccount();

			BankAccount destinationAccount;

			if (sourceAccount == account1)
			{
				destinationAccount = account2;
			}
			else
			{
				destinationAccount = account1;
			}

			Console.WriteLine("Destination Account: " + destinationAccount.HolderName);

			double amount = ReadPositiveAmount("Enter the transfer amount: ");

			if (sourceAccount.Balance < amount)
			{
				Console.WriteLine("Transfer failed: the source account has insufficient balance.");
				return;
			}

			sourceAccount.Withdraw(amount);
			destinationAccount.Deposit(amount);

			Console.WriteLine("Transfer completed successfully.");
			Console.WriteLine(sourceAccount.HolderName + "'s New Balance: " +
							  sourceAccount.Balance.ToString("0.000") + " OMR");
			Console.WriteLine(destinationAccount.HolderName + "'s New Balance: " +
							  destinationAccount.Balance.ToString("0.000") + " OMR");
		}

		// Case 10: Update Student Grade (Validated)
		private static void UpdateStudentGrade()
		{
			Student selectedStudent = ChooseStudent();

			Console.Write("Enter the new grade from 0 to 100: ");
			string input = Console.ReadLine() ?? string.Empty;

			if (!int.TryParse(input, out int newGrade))
			{
				Console.WriteLine("Grade update rejected: enter a valid whole number.");
				return;
			}

			if (newGrade < 0 || newGrade > 100)
			{
				Console.WriteLine("Grade update rejected: grade must be between 0 and 100.");
				return;
			}

			selectedStudent.Grade = newGrade;
			Console.WriteLine("Grade updated successfully to " + selectedStudent.Grade + ".");
		}

		// Case 11: Student Report Card
		private static void DisplayStudentReportCard()
		{
			Student selectedStudent = ChooseStudent();
			string result = selectedStudent.Grade >= 60 ? "Pass" : "Fail";

			Console.WriteLine("\n========== STUDENT REPORT CARD ==========");
			Console.WriteLine("Name: " + selectedStudent.Name);
			Console.WriteLine("Address: " + selectedStudent.Address);
			Console.WriteLine("Grade: " + selectedStudent.Grade);
			Console.WriteLine("Result: " + result);
			Console.WriteLine("=========================================");
		}

		// Case 12: Account Health Status
		private static void DisplayAccountHealthStatus()
		{
			BankAccount selectedAccount = ChooseAccount();
			string status;

			if (selectedAccount.Balance < 50)
			{
				status = "Low Balance";
			}
			else if (selectedAccount.Balance <= 1000)
			{
				status = "Healthy";
			}
			else
			{
				status = "Premium";
			}

			Console.WriteLine("Account Holder: " + selectedAccount.HolderName);
			Console.WriteLine("Balance: " +
							  selectedAccount.Balance.ToString("0.000") + " OMR");
			Console.WriteLine("Account Status: " + status);
		}

		// Case 13: Bulk Sale With Revenue Calculation
		private static void BulkSaleWithRevenue()
		{
			Product selectedProduct = ChooseProduct();
			int quantity = ReadPositiveQuantity("Enter the quantity to sell: ");

			if (selectedProduct.StockQuantity < quantity)
			{
				int additionalUnitsNeeded =
					quantity - selectedProduct.StockQuantity;

				Console.WriteLine("Sale cannot be completed.");
				Console.WriteLine("Additional units needed: " + additionalUnitsNeeded);
				return;
			}

			double revenue = quantity * selectedProduct.Price;
			selectedProduct.Sell(quantity);

			Console.WriteLine("Sale completed successfully.");
			Console.WriteLine("Revenue: " + revenue.ToString("0.000") + " OMR");
			Console.WriteLine("Remaining Stock: " + selectedProduct.StockQuantity);
		}



		// Case 14: Scholarship Eligibility Check
		private static void CheckScholarshipEligibility()
		{
			Student selectedStudent = ChooseStudent();
			BankAccount selectedAccount = ChooseAccount();

			bool gradeConditionPassed = selectedStudent.Grade >= 80;
			bool balanceConditionPassed = selectedAccount.Balance >= 100;

			if (gradeConditionPassed && balanceConditionPassed)
			{
				Console.WriteLine("Eligible");
			}
			else
			{
				Console.WriteLine("Not Eligible");

				if (!gradeConditionPassed)
				{
					Console.WriteLine("Reason: the student's grade is below 80.");
				}

				if (!balanceConditionPassed)
				{
					Console.WriteLine("Reason: the account balance is below 100 OMR.");
				}
			}
		}

		// Case 15: Full Balance Top-Up Flow
		private static void FullBalanceTopUpFlow()
		{
			BankAccount selectedAccount = ChooseAccount();
			double balanceBefore = selectedAccount.Balance;

			if (selectedAccount.Balance < 50)
			{
				double topUpAmount = 100 - selectedAccount.Balance;
				selectedAccount.Deposit(topUpAmount);

				Console.WriteLine("Balance Before: " +
								  balanceBefore.ToString("0.000") + " OMR");
				Console.WriteLine("Top-Up Amount: " +
								  topUpAmount.ToString("0.000") + " OMR");
				Console.WriteLine("Balance After: " +
								  selectedAccount.Balance.ToString("0.000") + " OMR");
			}
			else
			{
				Console.WriteLine("No top-up is needed because the balance is 50 OMR or more.");
			}
		}

	

		// Case 16: Quick Account Opening using a parameterized constructor
		private static void QuickAccountOpening()
		{
			Console.Write("Enter the new account number: ");
			string accountNumberInput = Console.ReadLine() ?? string.Empty;

			if (!int.TryParse(accountNumberInput, out int accountNumber))
			{
				Console.WriteLine("Account creation failed: invalid account number.");
				return;
			}

			Console.Write("Enter the holder name: ");
			string holderName = Console.ReadLine() ?? string.Empty;

			if (string.IsNullOrWhiteSpace(holderName))
			{
				Console.WriteLine("Account creation failed: holder name cannot be empty.");
				return;
			}

			Console.Write("Enter the starting balance: ");
			string balanceInput = Console.ReadLine() ?? string.Empty;

			if (!double.TryParse(balanceInput, out double startingBalance))
			{
				Console.WriteLine("Account creation failed: invalid starting balance.");
				return;
			}

			// Replace account2 instead of declaring account3.
			// This keeps only two individually named BankAccount variables.
			account2 = new BankAccount(accountNumber, holderName, startingBalance);

			Console.WriteLine("Account opened successfully using the parameterized constructor.");
			account2.CheckBalance();
		}

		// Case 17: Total Students Counter
		private static void DisplayTotalStudents()
		{
			Console.WriteLine("Total Student Objects Created: " +
							  Student.GetTotalStudents());
		}

		// Case 18: Overdrawn Account Check
		private static void CheckOverdrawnAccount()
		{
			BankAccount selectedAccount = ChooseAccount();

			if (selectedAccount.IsOverdrawn)
			{
				Console.WriteLine("The account is currently overdrawn.");
			}
			else
			{
				Console.WriteLine("The account is not overdrawn.");
			}
		}

		// Case 19: Set Student Security PIN
		private static void SetStudentSecurityPin()
		{
			Student selectedStudent = ChooseStudent();

			Console.Write("Enter a 4-digit security PIN: ");
			string pin = Console.ReadLine() ?? string.Empty;

			if (pin.Length != 4 || !int.TryParse(pin, out _))
			{
				Console.WriteLine("PIN was not set. Enter exactly four numeric digits.");
				return;
			}

			// Write-only: the PIN can be assigned but cannot be read back.
			selectedStudent.SecurityPin = pin;

			Console.WriteLine("Security PIN set successfully for " +
							  selectedStudent.Name + ".");
		}
	}
}