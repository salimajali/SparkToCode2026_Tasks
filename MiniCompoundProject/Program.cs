namespace MiniCompoundProject
{
	internal class Program
	{
		static List<string> customerNames = new List<string>();
		static List<string> accountNumbers = new List<string>();
		static List<double> balances = new List<double>();


		static void Main(string[] args)
		{
			bool exitApp = false;

			while (!exitApp)
			{
				Console.WriteLine();
				Console.WriteLine("Welcome to Spark Bank");
				Console.WriteLine("1. Add New Account");
				Console.WriteLine("2. Deposit Money");
				Console.WriteLine("3. Withdraw Money");
				Console.WriteLine("4. Show Balance");
				Console.WriteLine("5. Transfer Amount");
				Console.WriteLine("6. List All Accounts");
				Console.WriteLine("7. Search Customer");
				Console.WriteLine("8. Exit");
				Console.Write("Choose an option: ");

				int choice;

				try
				{
					choice = int.Parse(Console.ReadLine());
				}
				catch (Exception)
				{
					Console.WriteLine(
						"Invalid input. Please enter a number from 1 to 8."
					);

					continue;
				}

				switch (choice)
				{
					case 1:
						AddAccount();
						break;

					case 2:
						DepositMoney();
						break;

					case 3:
						WithdrawMoney();
						break;

					case 4:
						ShowBalance();
						break;

					case 5:
						TransferAmount();
						break;

					case 6:
						ListAllAccounts();
						break;

					case 7:
						SearchCustomer();
						break;

					case 8:
						exitApp = true;

						Console.WriteLine(
							"Thank you for banking with Spark Bank. Goodbye!"
						);
						break;

					default:
						Console.WriteLine(
							"Invalid option, please choose between 1 and 8."
						);
						break;
				}
			}
		}

		static void AddAccount()
		{
			Console.WriteLine();
			Console.WriteLine("===== Add New Account =====");

			Console.Write("Enter customer name: ");
			string customerName = Console.ReadLine();

			Console.Write("Enter new account number: ");
			string accountNumber = Console.ReadLine();

			bool accountExists = false;

			for (int counter = 0;
				 counter < accountNumbers.Count;
				 counter++)
			{
				if (accountNumbers[counter] == accountNumber)
				{
					accountExists = true;
				}
			}

			if (accountExists == true)
			{
				Console.WriteLine(
					"This account number already exists."
				);

				return;
			}

			double initialDeposit;

			try
			{
				Console.Write("Enter initial deposit amount: ");
				initialDeposit = double.Parse(Console.ReadLine());
			}
			catch (Exception)
			{
				Console.WriteLine("Invalid deposit amount.");
				return;
			}

			if (initialDeposit < 0)
			{
				Console.WriteLine(
					"Initial deposit cannot be negative."
				);

				return;
			}

			customerNames.Add(customerName);
			accountNumbers.Add(accountNumber);
			balances.Add(initialDeposit);

			Console.WriteLine("Account added successfully.");
			Console.WriteLine("Customer Name: " + customerName);
			Console.WriteLine("Account Number: " + accountNumber);

			Console.WriteLine(
				"Starting Balance: " +
				initialDeposit.ToString("0.000") +
				" OMR"
			);
		}

		static void DepositMoney()
		{
			Console.WriteLine();
			Console.WriteLine(" Deposit Money ");

			Console.Write("Enter account number: ");
			string accountNumber = Console.ReadLine();

			int accountIndex = -1;

			for (int counter = 0;
				 counter < accountNumbers.Count;
				 counter++)
			{
				if (accountNumbers[counter] == accountNumber)
				{
					accountIndex = counter;
				}
			}

			if (accountIndex == -1)
			{
				Console.WriteLine("Account not found.");
				return;
			}

			double depositAmount;

			try
			{
				Console.Write("Enter deposit amount: ");
				depositAmount = double.Parse(Console.ReadLine());
			}
			catch (Exception)
			{
				Console.WriteLine("Invalid deposit amount.");
				return;
			}

			if (depositAmount <= 0)
			{
				Console.WriteLine(
					"Deposit amount must be greater than zero."
				);

				return;
			}

			balances[accountIndex] =
				balances[accountIndex] + depositAmount;

			Console.WriteLine("Deposit completed successfully.");

			Console.WriteLine(
				"Updated Balance: " +
				balances[accountIndex].ToString("0.000") +
				" OMR"
			);
		}

		static void WithdrawMoney()
		{
			Console.WriteLine();
			Console.WriteLine(" Withdraw Money ");

			Console.Write("Enter account number: ");
			string accountNumber = Console.ReadLine();

			int accountIndex = -1;

			for (int counter = 0;
				 counter < accountNumbers.Count;
				 counter++)
			{
				if (accountNumbers[counter] == accountNumber)
				{
					accountIndex = counter;
				}
			}

			if (accountIndex == -1)
			{
				Console.WriteLine("Account not found.");
				return;
			}

			double withdrawalAmount;

			try
			{
				Console.Write("Enter withdrawal amount: ");
				withdrawalAmount =
					double.Parse(Console.ReadLine());
			}
			catch (Exception)
			{
				Console.WriteLine("Invalid withdrawal amount.");
				return;
			}

			if (withdrawalAmount <= 0)
			{
				Console.WriteLine(
					"Withdrawal amount must be greater than zero."
				);

				return;
			}

			if (withdrawalAmount > balances[accountIndex])
			{
				Console.WriteLine(
					"Insufficient balance."
				);

				return;
			}

			balances[accountIndex] =
				balances[accountIndex] - withdrawalAmount;

			Console.WriteLine(
				"Withdrawal completed successfully."
			);

			Console.WriteLine(
				"Updated Balance: " +
				balances[accountIndex].ToString("0.000") +
				" OMR"
			);
		}




		static void ShowBalance()
		{
			Console.WriteLine();
			Console.WriteLine(" Show Balance ");

			Console.Write("Enter account number: ");
			string accountNumber = Console.ReadLine();

			int accountIndex = -1;

			for (int counter = 0;
				 counter < accountNumbers.Count;
				 counter++)
			{
				if (accountNumbers[counter] == accountNumber)
				{
					accountIndex = counter;
				}
			}

			if (accountIndex == -1)
			{
				Console.WriteLine("Account not found.");
				return;
			}

			Console.WriteLine(
				"Customer Name: " +
				customerNames[accountIndex]
			);

			Console.WriteLine(
				"Account Number: " +
				accountNumbers[accountIndex]
			);

			Console.WriteLine(
				"Current Balance: " +
				balances[accountIndex].ToString("0.000") +
				" OMR"
			);
		}


		static void TransferAmount()
		{
			Console.WriteLine();
			Console.WriteLine(" Transfer Amount ");

			Console.Write("Enter sender account number: ");
			string senderAccount = Console.ReadLine();

			Console.Write("Enter receiver account number: ");
			string receiverAccount = Console.ReadLine();

			int senderIndex = -1;
			int receiverIndex = -1;

			for (int counter = 0;
				 counter < accountNumbers.Count;
				 counter++)
			{
				if (accountNumbers[counter] == senderAccount)
				{
					senderIndex = counter;
				}

				if (accountNumbers[counter] == receiverAccount)
				{
					receiverIndex = counter;
				}
			}

			if (senderIndex == -1)
			{
				Console.WriteLine(
					"Sender account was not found."
				);

				return;
			}

			if (receiverIndex == -1)
			{
				Console.WriteLine(
					"Receiver account was not found."
				);

				return;
			}

			if (senderIndex == receiverIndex)
			{
				Console.WriteLine(
					"Sender and receiver cannot be the same account."
				);

				return;
			}

			double transferAmount;

			try
			{
				Console.Write("Enter transfer amount: ");
				transferAmount =
					double.Parse(Console.ReadLine());
			}
			catch (Exception)
			{
				Console.WriteLine("Invalid transfer amount.");
				return;
			}

			if (transferAmount <= 0)
			{
				Console.WriteLine(
					"Transfer amount must be greater than zero."
				);

				return;
			}

			if (transferAmount > balances[senderIndex])
			{
				Console.WriteLine(
					"The sender does not have enough balance."
				);

				return;
			}

			balances[senderIndex] =
				balances[senderIndex] - transferAmount;

			balances[receiverIndex] =
				balances[receiverIndex] + transferAmount;

			Console.WriteLine(
				"Transfer completed successfully."
			);

			Console.WriteLine(
				"Sender Updated Balance: " +
				balances[senderIndex].ToString("0.000") +
				" OMR"
			);

			Console.WriteLine(
				"Receiver Updated Balance: " +
				balances[receiverIndex].ToString("0.000") +
				" OMR"
			);
		}



		static void ListAllAccounts()
		{
			Console.WriteLine();
			Console.WriteLine("All Accounts ");

			if (accountNumbers.Count == 0)
			{
				Console.WriteLine(
					"There are no accounts in the system."
				);

				return;
			}

			for (int counter = 0;
				 counter < accountNumbers.Count;
				 counter++)
			{
				Console.WriteLine();
				Console.WriteLine(
					"Customer Name: " +
					customerNames[counter]
				);

				Console.WriteLine(
					"Account Number: " +
					accountNumbers[counter]
				);

				Console.WriteLine(
					"Balance: " +
					balances[counter].ToString("0.000") +
					" OMR"
				);

				Console.WriteLine("");
			}
		}



		static void SearchCustomer()
		{
			Console.WriteLine();
			Console.WriteLine(" Search Customer");

			Console.Write("Enter customer name: ");
			string searchName = Console.ReadLine();

			bool customerFound = false;

			for (int counter = 0;
				 counter < customerNames.Count;
				 counter++)
			{
				if (
					customerNames[counter].ToLower() ==
					searchName.ToLower()
				)
				{
					customerFound = true;

					Console.WriteLine();
					Console.WriteLine(
						"Customer Name: " +
						customerNames[counter]
					);

					Console.WriteLine(
						"Account Number: " +
						accountNumbers[counter]
					);

					Console.WriteLine(
						"Balance: " +
						balances[counter].ToString("0.000") +
						" OMR"
					);
				}
			}

			if (customerFound == false)
			{
				Console.WriteLine("Customer not found.");
			}
		}
	}
}