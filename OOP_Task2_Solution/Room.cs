namespace OOP_Task2_Solution;

/// <summary>
/// Represents one hotel room.
/// </summary>
public class Room
{
	public int RoomNumber { get; set; }
	public string RoomType { get; set; }
	public double PricePerNight { get; set; }
	public bool IsAvailable { get; set; }

	public Room(int roomNumber, string roomType, double pricePerNight, bool isAvailable = true)
	{
		RoomNumber = roomNumber;
		RoomType = roomType;
		PricePerNight = pricePerNight;
		IsAvailable = isAvailable;
	}

	public void DisplayRoom()
	{
		string status = IsAvailable ? "Available" : "Booked / Unavailable";

		Console.WriteLine(
			$"Room {RoomNumber} | Type: {RoomType} | " +
			$"Price: OMR {PricePerNight:F2} | Status: {status}");
	}
}