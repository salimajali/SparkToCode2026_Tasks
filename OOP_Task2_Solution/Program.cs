using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OOP_Task2_Solution;

internal class Program
{
	private const string NotAssigned = "Not Assigned";

	private static void Main()
	{
		// The task requires both lists to be declared before the menu starts.
		List<Room> rooms = new List<Room>();
		List<Guest> guests = new List<Guest>();

		// Preload at least six rooms with mixed room types.
		rooms.Add(new Room(101, "Single", 25.000));
		rooms.Add(new Room(102, "Single", 28.500));
		rooms.Add(new Room(103, "Double", 40.000));
		rooms.Add(new Room(104, "Double", 45.750));
		rooms.Add(new Room(105, "Suite", 75.000));

		// This room is unavailable but has no guest assigned.
		// It provides a valid test case for Case 12.
		rooms.Add(new Room(106, "Suite", 90.000, false));

		bool running = true;

		while (running)
		{
			DisplayMainMenu();
			int choice = ReadInt("Enter your choice: ");
			Console.WriteLine();

			switch (choice)
			{
				case 1:
					AddNewRoom(rooms);
					break;
				case 2:
					RegisterNewGuest(guests);
					break;
				case 3:
					BookRoomForGuest(rooms, guests);
					break;
				case 4:
					ViewAllRooms(rooms);
					break;
				case 5:
					ViewAllGuests(guests);
					break;
				case 6:
					SearchAndFilterRooms(rooms);
					break;
				case 7:
					DisplayGuestAndBookingStatistics(rooms, guests);
					break;
				case 8:
					UpdateRoomPrice(rooms);
					break;
				case 9:
					LookupGuestByName(guests);
					break;
				case 10:
					DisplayRoomTypeBreakdown(rooms);
					break;
				case 11:
					CheckOutGuest(rooms, guests);
					break;
				case 12:
					RemoveUnavailableRooms(rooms, guests);
					break;
				case 13:
					ExtendGuestStay(guests);
					break;
				case 14:
					DisplayHighestRevenueBooking(guests);
					break;
				case 15:
					DisplayGuestPagination(guests);
					break;
				case 0:
					running = false;
					Console.WriteLine("Thank you for using the hotel management system.");
					break;
				default:
					Console.WriteLine("Invalid menu choice. Please enter a number from 0 to 15.");
					break;
			}

			if (running)
			{
				Console.WriteLine("\nPress Enter to return to the main menu...");
				Console.ReadLine();
				Console.Clear();
			}
		}
	}

	private static void DisplayMainMenu()
	{
		Console.WriteLine("================================================");
		Console.WriteLine("GRAND VISTA HOTEL - MANAGEMENT SYSTEM");
		Console.WriteLine("================================================");
		Console.WriteLine(" 1. Add New Room");
		Console.WriteLine(" 2. Register New Guest");
		Console.WriteLine(" 3. Book a Room for a Guest");
		Console.WriteLine(" 4. View All Rooms");
		Console.WriteLine(" 5. View All Guests");
		Console.WriteLine(" 6. Search & Filter Rooms");
		Console.WriteLine(" 7. Guest & Booking Statistics");
		Console.WriteLine(" 8. Update Room Price");
		Console.WriteLine(" 9. Guest Lookup by Name");
		Console.WriteLine("10. Room Type Breakdown Report");
		Console.WriteLine("11. Check Out a Guest");
		Console.WriteLine("12. Remove Unavailable Rooms");
		Console.WriteLine("13. Extend Guest Stay");
		Console.WriteLine("14. Highest Revenue Booking");
		Console.WriteLine("15. Guest Pagination Viewer");
		Console.WriteLine(" 0. Exit");
		Console.WriteLine("================================================");
	}

	// ================================================================
	// EASY CASES: 01-05
	// ================================================================

	private static void AddNewRoom(List<Room> rooms)
	{
		Console.WriteLine("CASE 01 - ADD NEW ROOM");

		int roomNumber = ReadPositiveInt("Enter room number: ");

		// LINQ Any() checks for a duplicate room number.
		bool roomExists = rooms.Any(room => room.RoomNumber == roomNumber);
		if (roomExists)
		{
			Console.WriteLine("Error: A room with this number already exists.");
			return;
		}

		string roomType = ReadRoomType();
		double price = ReadPositiveDouble("Enter price per night: ");

		Room newRoom = new Room(roomNumber, roomType, price, true);
		rooms.Add(newRoom);

		Console.WriteLine("\nRoom added successfully:");
		newRoom.DisplayRoom();
		Console.WriteLine($"Updated total room count: {rooms.Count()}");
	}

	private static void RegisterNewGuest(List<Guest> guests)
	{
		Console.WriteLine("CASE 02 - REGISTER NEW GUEST");

		string guestName = ReadRequiredText("Enter guest name: ");
		string checkInDate = ReadRequiredText("Enter check-in date: ");
		int totalNights = ReadPositiveInt("Enter number of nights: ");

		// Start from the current list size and ensure the generated ID is unique.
		int nextGuestNumber = guests.Count() + 1;
		string guestId = $"G{nextGuestNumber:D3}";

		while (guests.Any(guest => guest.GuestId.Equals(
				   guestId,
				   StringComparison.OrdinalIgnoreCase)))
		{
			nextGuestNumber++;
			guestId = $"G{nextGuestNumber:D3}";
		}

		Guest newGuest = new Guest(
			guestId,
			guestName,
			checkInDate,
			totalNights);

		guests.Add(newGuest);

		Console.WriteLine("\nGuest registered successfully:");
		newGuest.DisplayGuest();
	}

	private static void BookRoomForGuest(List<Room> rooms, List<Guest> guests)
	{
		Console.WriteLine("CASE 03 - BOOK A ROOM FOR A GUEST");

		string guestId = ReadRequiredText("Enter guest ID: ");
		int roomNumber = ReadPositiveInt("Enter desired room number: ");

		// Both lookups use LINQ FirstOrDefault().
		Guest? guest = guests.FirstOrDefault(g =>
			g.GuestId.Equals(guestId, StringComparison.OrdinalIgnoreCase));

		if (guest is null)
		{
			Console.WriteLine("Guest was not found.");
			return;
		}

		Room? room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

		if (room is null)
		{
			Console.WriteLine("Room was not found.");
			return;
		}

		if (!guest.RoomNumber.Equals(NotAssigned, StringComparison.OrdinalIgnoreCase))
		{
			Console.WriteLine("This guest already has an active room booking.");
			return;
		}

		if (!room.IsAvailable)
		{
			Console.WriteLine("Room is already booked or unavailable.");
			return;
		}

		guest.RoomNumber = room.RoomNumber.ToString(CultureInfo.InvariantCulture);
		guest.BookedPricePerNight = room.PricePerNight;
		room.IsAvailable = false;

		Console.WriteLine("\nBooking confirmed:");
		Console.WriteLine($"Guest: {guest.GuestName}");
		Console.WriteLine($"Room: {room.RoomNumber}");
		Console.WriteLine($"Room type: {room.RoomType}");
		Console.WriteLine($"Price per night: OMR {room.PricePerNight:F2}");
		Console.WriteLine($"Total nights: {guest.TotalNights}");
		Console.WriteLine($"Total cost: OMR {guest.CalculateTotalCost():F2}");
	}

	private static void ViewAllRooms(List<Room> rooms)
	{
		Console.WriteLine("CASE 04 - VIEW ALL ROOMS");

		if (!rooms.Any())
		{
			Console.WriteLine("No rooms have been added yet.");
			return;
		}

		Console.WriteLine($"Total rooms: {rooms.Count()}\n");

		// LINQ OrderBy() sorts the rooms without changing the original list.
		IEnumerable<string> roomLines = rooms
			.OrderBy(room => room.RoomNumber)
			.Select(room =>
				$"Room {room.RoomNumber} | Type: {room.RoomType} | " +
				$"Price: OMR {room.PricePerNight:F2} | " +
				$"Status: {(room.IsAvailable ? "Available" : "Booked / Unavailable")}");

		foreach (string line in roomLines)
		{
			Console.WriteLine(line);
		}
	}

	private static void ViewAllGuests(List<Guest> guests)
	{
		Console.WriteLine("CASE 05 - VIEW ALL GUESTS");

		if (!guests.Any())
		{
			Console.WriteLine("No guests have been registered yet.");
			return;
		}

		Console.WriteLine($"Total guests: {guests.Count()}\n");

		IEnumerable<string> guestLines = guests
			.OrderBy(guest => guest.GuestName)
			.Select(guest =>
				$"ID: {guest.GuestId} | Name: {guest.GuestName} | " +
				$"Room: {guest.RoomNumber} | Check-in: {guest.CheckInDate} | " +
				$"Nights: {guest.TotalNights}");

		foreach (string line in guestLines)
		{
			Console.WriteLine(line);
		}
	}

	// ================================================================
	// MEDIUM CASES: 06-10
	// ================================================================

	private static void SearchAndFilterRooms(List<Room> rooms)
	{
		bool inSubMenu = true;

		while (inSubMenu)
		{
			Console.WriteLine("CASE 06 - SEARCH & FILTER ROOMS");
			Console.WriteLine("1. Show all available rooms");
			Console.WriteLine("2. Filter by room type");
			Console.WriteLine("3. Filter by maximum price");
			Console.WriteLine("4. Room price statistics");
			Console.WriteLine("0. Back");

			int choice = ReadInt("Choose an option: ");
			Console.WriteLine();

			switch (choice)
			{
				case 1:
					{
						List<Room> availableRooms = rooms
							.Where(room => room.IsAvailable)
							.OrderBy(room => room.PricePerNight)
							.ToList();

						DisplayFilteredRooms(availableRooms);
						break;
					}
				case 2:
					{
						string roomType = ReadRoomType();

						List<Room> roomsByType = rooms
							.Where(room => room.RoomType.Equals(
								roomType,
								StringComparison.OrdinalIgnoreCase))
							.OrderBy(room => room.RoomNumber)
							.ToList();

						DisplayFilteredRooms(roomsByType);
						break;
					}
				case 3:
					{
						double maximumPrice = ReadPositiveDouble("Enter maximum price: ");

						List<Room> roomsByPrice = rooms
							.Where(room => room.IsAvailable &&
										   room.PricePerNight <= maximumPrice)
							.OrderBy(room => room.PricePerNight)
							.ToList();

						DisplayFilteredRooms(roomsByPrice);
						break;
					}
				case 4:
					{
						if (!rooms.Any())
						{
							Console.WriteLine("No rooms are available for statistics.");
							break;
						}

						int totalRooms = rooms.Count();
						int availableRooms = rooms.Count(room => room.IsAvailable);
						double averagePrice = rooms.Average(room => room.PricePerNight);
						double cheapestPrice = rooms.Min(room => room.PricePerNight);
						double mostExpensivePrice = rooms.Max(room => room.PricePerNight);

						Console.WriteLine($"Total rooms: {totalRooms}");
						Console.WriteLine($"Available rooms: {availableRooms}");
						Console.WriteLine($"Average price: OMR {averagePrice:F2}");
						Console.WriteLine($"Cheapest price: OMR {cheapestPrice:F2}");
						Console.WriteLine($"Most expensive price: OMR {mostExpensivePrice:F2}");
						break;
					}
				case 0:
					inSubMenu = false;
					continue;
				default:
					Console.WriteLine("Invalid sub-menu choice.");
					break;
			}

			if (inSubMenu)
			{
				Console.WriteLine("\nPress Enter to continue in the room search menu...");
				Console.ReadLine();
				Console.Clear();
			}
		}
	}

	private static void DisplayGuestAndBookingStatistics(
		List<Room> rooms,
		List<Guest> guests)
	{
		Console.WriteLine("CASE 07 - GUEST & BOOKING STATISTICS");

		List<Guest> bookedGuests = guests
			.Where(guest => !guest.RoomNumber.Equals(
				NotAssigned,
				StringComparison.OrdinalIgnoreCase))
			.ToList();

		Console.WriteLine($"Total registered guests: {guests.Count()}");
		Console.WriteLine($"Guests with active bookings: {bookedGuests.Count()}");
		Console.WriteLine($"Total rooms: {rooms.Count()}");
		Console.WriteLine($"Currently booked/unavailable rooms: " +
						  $"{rooms.Count(room => !room.IsAvailable)}");

		if (!bookedGuests.Any())
		{
			Console.WriteLine("No active bookings recorded.");
			return;
		}

		double averageNights = bookedGuests.Average(guest => guest.TotalNights);
		Console.WriteLine($"Average nights for booked guests: {averageNights:F2}");

		Console.WriteLine("\nTop 3 highest-spending guests:");

		IEnumerable<string> topThreeGuests = bookedGuests
			.OrderByDescending(guest => guest.CalculateTotalCost())
			.Take(3)
			.Select(guest =>
				$"{guest.GuestName} | Room {guest.RoomNumber} | " +
				$"OMR {guest.CalculateTotalCost():F2}");

		foreach (string line in topThreeGuests)
		{
			Console.WriteLine(line);
		}

		Console.WriteLine("\nBooked guest summaries:");

		IEnumerable<string> bookingSummaries = bookedGuests
			.Select(guest =>
				$"{guest.GuestName} - Room {guest.RoomNumber} - " +
				$"{guest.TotalNights} nights - " +
				$"OMR {guest.CalculateTotalCost():F2}");

		foreach (string summary in bookingSummaries)
		{
			Console.WriteLine(summary);
		}
	}

	private static void UpdateRoomPrice(List<Room> rooms)
	{
		Console.WriteLine("CASE 08 - UPDATE ROOM PRICE");

		int roomNumber = ReadPositiveInt("Enter room number: ");

		Room? room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
		if (room is null)
		{
			Console.WriteLine("Room was not found.");
			return;
		}

		if (!TryReadPositiveDouble("Enter new price per night: ", out double newPrice))
		{
			Console.WriteLine("Invalid price. No changes were made.");
			return;
		}

		double oldPrice = room.PricePerNight;
		room.PricePerNight = newPrice;

		Console.WriteLine(
			$"Room {room.RoomNumber} price updated from " +
			$"OMR {oldPrice:F2} to OMR {newPrice:F2}.");
	}

	private static void LookupGuestByName(List<Guest> guests)
	{
		Console.WriteLine("CASE 09 - GUEST LOOKUP BY NAME");

		string searchText = ReadRequiredText("Enter a guest name or partial name: ");

		List<Guest> matches = guests
			.Where(guest => guest.GuestName.Contains(
				searchText,
				StringComparison.OrdinalIgnoreCase))
			.OrderBy(guest => guest.GuestName)
			.ToList();

		if (!matches.Any())
		{
			Console.WriteLine("No guests matched that search.");
			return;
		}

		Console.WriteLine($"Matches found: {matches.Count()}\n");

		foreach (Guest guest in matches)
		{
			Console.WriteLine(
				$"ID: {guest.GuestId} | Name: {guest.GuestName} | " +
				$"Room: {guest.RoomNumber}");
		}
	}

	private static void DisplayRoomTypeBreakdown(List<Room> rooms)
	{
		Console.WriteLine("CASE 10 - ROOM TYPE BREAKDOWN REPORT");

		DisplayOneRoomTypeBreakdown(rooms, "Single");
		DisplayOneRoomTypeBreakdown(rooms, "Double");
		DisplayOneRoomTypeBreakdown(rooms, "Suite");

		if (!rooms.Any())
		{
			Console.WriteLine("Overall average price: N/A");
			return;
		}

		double overallAverage = rooms.Average(room => room.PricePerNight);
		Console.WriteLine($"Overall average price: OMR {overallAverage:F2}");
	}

	private static void DisplayOneRoomTypeBreakdown(
		List<Room> rooms,
		string roomType)
	{
		int roomCount = rooms.Count(room => room.RoomType.Equals(
			roomType,
			StringComparison.OrdinalIgnoreCase));

		if (roomCount == 0)
		{
			Console.WriteLine($"{roomType}: Count = 0 | Average price = N/A");
			return;
		}

		double averagePrice = rooms
			.Where(room => room.RoomType.Equals(
				roomType,
				StringComparison.OrdinalIgnoreCase))
			.Average(room => room.PricePerNight);

		Console.WriteLine(
			$"{roomType}: Count = {roomCount} | " +
			$"Average price = OMR {averagePrice:F2}");
	}

	// ================================================================
	// ADVANCED CASES: 11-15
	// ================================================================

	private static void CheckOutGuest(List<Room> rooms, List<Guest> guests)
	{
		Console.WriteLine("CASE 11 - CHECK OUT A GUEST");

		string guestId = ReadRequiredText("Enter guest ID: ");

		Guest? guest = guests.FirstOrDefault(g =>
			g.GuestId.Equals(guestId, StringComparison.OrdinalIgnoreCase));

		if (guest is null)
		{
			Console.WriteLine("Guest was not found.");
			return;
		}

		if (guest.RoomNumber.Equals(NotAssigned, StringComparison.OrdinalIgnoreCase))
		{
			Console.WriteLine("This guest has no active booking.");
			return;
		}

		Room? room = rooms.FirstOrDefault(r =>
			r.RoomNumber.ToString(CultureInfo.InvariantCulture) == guest.RoomNumber);

		if (room is null)
		{
			Console.WriteLine(
				"The linked room could not be found. Checkout was cancelled " +
				"to keep both lists consistent.");
			return;
		}

		Console.WriteLine("\nFINAL BILL");
		Console.WriteLine($"Guest: {guest.GuestName}");
		Console.WriteLine($"Room: {room.RoomNumber}");
		Console.WriteLine($"Room type: {room.RoomType}");
		Console.WriteLine($"Check-in date: {guest.CheckInDate}");
		Console.WriteLine($"Total nights: {guest.TotalNights}");
		Console.WriteLine($"Price per night: OMR {guest.BookedPricePerNight:F2}");
		Console.WriteLine($"Total cost: OMR {guest.CalculateTotalCost():F2}");

		bool confirmed = ReadYesNo("Confirm checkout (Y/N): ");
		if (!confirmed)
		{
			Console.WriteLine("Checkout cancelled. No changes were made.");
			return;
		}

		// The room must be freed before the guest is removed.
		room.IsAvailable = true;
		guests.Remove(guest);

		bool roomIsNowAvailable = rooms.Any(r =>
			r.RoomNumber == room.RoomNumber && r.IsAvailable);

		Console.WriteLine("\nCheckout completed successfully.");
		Console.WriteLine($"Remaining guests: {guests.Count()}");
		Console.WriteLine($"Total rooms: {rooms.Count()}");
		Console.WriteLine(
			$"Room {room.RoomNumber} available: " +
			$"{(roomIsNowAvailable ? "Yes" : "No")}");
	}

	private static void RemoveUnavailableRooms(
		List<Room> rooms,
		List<Guest> guests)
	{
		Console.WriteLine("CASE 12 - REMOVE UNAVAILABLE ROOMS");

		List<Room> removableRooms = rooms
			.Where(room =>
				!room.IsAvailable &&
				!guests.Any(guest =>
					guest.RoomNumber == room.RoomNumber.ToString(
						CultureInfo.InvariantCulture)))
			.OrderBy(room => room.RoomNumber)
			.ToList();

		if (!removableRooms.Any())
		{
			Console.WriteLine(
				"All unavailable rooms are currently occupied. " +
				"No rooms can be decommissioned.");
			return;
		}

		Console.WriteLine("Rooms safe to remove:");

		IEnumerable<string> previewLines = removableRooms.Select(room =>
			$"Room {room.RoomNumber} | Type: {room.RoomType} | " +
			$"Price: OMR {room.PricePerNight:F2}");

		foreach (string line in previewLines)
		{
			Console.WriteLine(line);
		}

		Console.WriteLine($"Total removable rooms: {removableRooms.Count()}");

		bool confirmed = ReadYesNo("Confirm removal (Y/N): ");
		if (!confirmed)
		{
			Console.WriteLine("Removal cancelled. No rooms were removed.");
			return;
		}

		int removedCount = rooms.RemoveAll(room =>
			!room.IsAvailable &&
			!guests.Any(guest =>
				guest.RoomNumber == room.RoomNumber.ToString(
					CultureInfo.InvariantCulture)));

		Console.WriteLine($"Removed rooms: {removedCount}");
		Console.WriteLine($"Updated total room count: {rooms.Count()}");
		Console.WriteLine("Remaining rooms:");

		IEnumerable<string> remainingRooms = rooms
			.OrderBy(room => room.RoomNumber)
			.Select(room => $"Room {room.RoomNumber} - {room.RoomType}");

		foreach (string roomSummary in remainingRooms)
		{
			Console.WriteLine(roomSummary);
		}
	}

	private static void ExtendGuestStay(List<Guest> guests)
	{
		Console.WriteLine("CASE 13 - EXTEND GUEST STAY");

		string guestId = ReadRequiredText("Enter guest ID: ");

		Guest? guest = guests.FirstOrDefault(g =>
			g.GuestId.Equals(guestId, StringComparison.OrdinalIgnoreCase));

		if (guest is null)
		{
			Console.WriteLine("Guest was not found.");
			return;
		}

		if (guest.RoomNumber.Equals(NotAssigned, StringComparison.OrdinalIgnoreCase))
		{
			Console.WriteLine("This guest has no active booking to extend.");
			return;
		}

		if (!TryReadPositiveInt("Enter additional nights: ", out int additionalNights))
		{
			Console.WriteLine("Invalid number of nights. The booking was not changed.");
			return;
		}

		guest.TotalNights += additionalNights;

		Console.WriteLine("Stay extended successfully.");
		Console.WriteLine($"Updated total nights: {guest.TotalNights}");
		Console.WriteLine($"New total cost: OMR {guest.CalculateTotalCost():F2}");
	}

	private static void DisplayHighestRevenueBooking(List<Guest> guests)
	{
		Console.WriteLine("CASE 14 - HIGHEST REVENUE BOOKING");

		List<Guest> activeGuests = guests
			.Where(guest => !guest.RoomNumber.Equals(
				NotAssigned,
				StringComparison.OrdinalIgnoreCase))
			.ToList();

		if (!activeGuests.Any())
		{
			Console.WriteLine("No active bookings recorded.");
			return;
		}

		var highestRevenueBooking = activeGuests
			.Select(guest => new
			{
				guest.GuestName,
				guest.RoomNumber,
				TotalCost = guest.CalculateTotalCost()
			})
			.OrderByDescending(booking => booking.TotalCost)
			.Take(1)
			.FirstOrDefault();

		if (highestRevenueBooking is null)
		{
			Console.WriteLine("No active bookings recorded.");
			return;
		}

		Console.WriteLine("Top revenue booking:");
		Console.WriteLine($"Guest: {highestRevenueBooking.GuestName}");
		Console.WriteLine($"Room: {highestRevenueBooking.RoomNumber}");
		Console.WriteLine($"Total cost: OMR {highestRevenueBooking.TotalCost:F2}");
	}

	private static void DisplayGuestPagination(List<Guest> guests)
	{
		Console.WriteLine("CASE 15 - GUEST PAGINATION VIEWER");

		const int pageSize = 3;
		int totalGuests = guests.Count();
		int totalPages = (int)Math.Ceiling(totalGuests / (double)pageSize);

		if (totalPages == 0)
		{
			Console.WriteLine("No guests have been registered yet.");
			return;
		}

		int pageNumber = ReadPositiveInt("Enter page number: ");

		if (pageNumber > totalPages)
		{
			Console.WriteLine("That page does not exist.");
			return;
		}

		List<Guest> guestsOnPage = guests
			.OrderBy(guest => guest.GuestId)
			.Skip((pageNumber - 1) * pageSize)
			.Take(pageSize)
			.ToList();

		Console.WriteLine($"Page {pageNumber} of {totalPages}");
		Console.WriteLine($"Total guests: {totalGuests}\n");

		foreach (Guest guest in guestsOnPage)
		{
			guest.DisplayGuest();
		}
	}

	// ================================================================
	// SHARED DISPLAY AND INPUT METHODS
	// ================================================================

	private static void DisplayFilteredRooms(List<Room> filteredRooms)
	{
		if (!filteredRooms.Any())
		{
			Console.WriteLine("No rooms found for the selected criteria.");
			return;
		}

		Console.WriteLine($"Rooms found: {filteredRooms.Count()}\n");

		IEnumerable<string> lines = filteredRooms.Select(room =>
			$"Room {room.RoomNumber} | Type: {room.RoomType} | " +
			$"Price: OMR {room.PricePerNight:F2} | " +
			$"Status: {(room.IsAvailable ? "Available" : "Booked / Unavailable")}");

		foreach (string line in lines)
		{
			Console.WriteLine(line);
		}
	}

	private static int ReadInt(string prompt)
	{
		while (true)
		{
			Console.Write(prompt);
			string? input = Console.ReadLine();

			if (int.TryParse(input, out int value))
			{
				return value;
			}

			Console.WriteLine("Invalid input. Please enter a whole number.");
		}
	}

	private static int ReadPositiveInt(string prompt)
	{
		while (true)
		{
			int value = ReadInt(prompt);

			if (value > 0)
			{
				return value;
			}

			Console.WriteLine("The value must be greater than zero.");
		}
	}

	private static double ReadPositiveDouble(string prompt)
	{
		while (true)
		{
			Console.Write(prompt);
			string? input = Console.ReadLine();

			bool validCurrentCulture = double.TryParse(
				input,
				NumberStyles.Number,
				CultureInfo.CurrentCulture,
				out double currentCultureValue);

			bool validInvariantCulture = double.TryParse(
				input,
				NumberStyles.Number,
				CultureInfo.InvariantCulture,
				out double invariantCultureValue);

			if (validCurrentCulture && currentCultureValue > 0)
			{
				return currentCultureValue;
			}

			if (validInvariantCulture && invariantCultureValue > 0)
			{
				return invariantCultureValue;
			}

			Console.WriteLine(
				"Invalid input. Please enter a positive number, for example 25.50.");
		}
	}


	private static bool TryReadPositiveInt(string prompt, out int value)
	{
		Console.Write(prompt);
		string? input = Console.ReadLine();

		return int.TryParse(input, out value) && value > 0;
	}

	private static bool TryReadPositiveDouble(string prompt, out double value)
	{
		Console.Write(prompt);
		string? input = Console.ReadLine();

		bool validCurrentCulture = double.TryParse(
			input,
			NumberStyles.Number,
			CultureInfo.CurrentCulture,
			out double currentCultureValue);

		if (validCurrentCulture && currentCultureValue > 0)
		{
			value = currentCultureValue;
			return true;
		}

		bool validInvariantCulture = double.TryParse(
			input,
			NumberStyles.Number,
			CultureInfo.InvariantCulture,
			out double invariantCultureValue);

		if (validInvariantCulture && invariantCultureValue > 0)
		{
			value = invariantCultureValue;
			return true;
		}

		value = 0;
		return false;
	}

	private static string ReadRequiredText(string prompt)
	{
		while (true)
		{
			Console.Write(prompt);
			string value = Console.ReadLine()?.Trim() ?? string.Empty;

			if (!string.IsNullOrWhiteSpace(value))
			{
				return value;
			}

			Console.WriteLine("This field cannot be empty.");
		}
	}

	private static string ReadRoomType()
	{
		while (true)
		{
			string roomType = ReadRequiredText(
				"Enter room type (Single / Double / Suite): ");

			if (roomType.Equals("Single", StringComparison.OrdinalIgnoreCase))
			{
				return "Single";
			}

			if (roomType.Equals("Double", StringComparison.OrdinalIgnoreCase))
			{
				return "Double";
			}

			if (roomType.Equals("Suite", StringComparison.OrdinalIgnoreCase))
			{
				return "Suite";
			}

			Console.WriteLine("Invalid room type. Choose Single, Double, or Suite.");
		}
	}

	private static bool ReadYesNo(string prompt)
	{
		while (true)
		{
			string answer = ReadRequiredText(prompt);

			if (answer.Equals("Y", StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}

			if (answer.Equals("N", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}

			Console.WriteLine("Please enter Y or N.");
		}
	}
}