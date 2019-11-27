using System;

public class Booking
{
	public int RoomLocation { get; set; }

    public DateTime ArrivalDateTime { get; set; }

    public DateTime DepartureDateTime { get; set; }

    public DateTime BookingDateTime { get; set; }

    public int ClientPassportSeriesAndNumber { get; set; }

    public int OrderPrice { get; set; }
}
