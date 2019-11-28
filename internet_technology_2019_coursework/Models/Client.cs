using System;
using System.ComponentModel.DataAnnotations;

public class Client
{
    [Key]
    public int ClientPassportSeriesAndNumber { get; set; }

    public string FullName { get; set; }
}
