using System;
using System.ComponentModel.DataAnnotations;

public class Admin
{
    [Key]
    public string Login { get; set; }

    public string Password { get; set; }
}
