using System;
using System.ComponentModel.DataAnnotations;

public class Booking
{
    [Key]
    public int RoomLocation { get; set; }

    [Key]
    public DateTime ArrivalDateTime { get; set; }

    [Key]
    public DateTime DepartureDateTime { get; set; }

    public DateTime BookingDateTime { get; set; }

    public int ClientPassportSeriesAndNumber { get; set; }

    public int OrderPrice { get; set; }
}
