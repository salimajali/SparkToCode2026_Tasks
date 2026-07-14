namespace OOP_Task2_Solution;

/// <summary>
/// Represents one hotel guest.
/// </summary>
public class Guest
{
	public string GuestId { get; set; }
	public string GuestName { get; set; }
	public string RoomNumber { get; set; }
	public string CheckInDate { get; set; }
	public int TotalNights { get; set; }

	// The room price is saved when the booking is made so that
	// CalculateTotalCost() can work without receiving parameters.
	public double BookedPricePerNight { get; set; }

	public Guest(
		string guestId,
		string guestName,
		string checkInDate,
		int totalNights)
	{
		GuestId = guestId;
		GuestName = guestName;
		RoomNumber = "Not Assigned";
		CheckInDate = checkInDate;
		TotalNights = totalNights;
		BookedPricePerNight = 0;
	}

	public void DisplayGuest()
	{
		Console.WriteLine(
			$"ID: {GuestId} | Name: {GuestName} | Room: {RoomNumber} | " +
			$"Check-in: {CheckInDate} | Nights: {TotalNights}");
	}

	public double CalculateTotalCost()
	{
		return TotalNights * BookedPricePerNight;
	}
}
