namespace TrybeHotel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 1. Implemente as models da aplicação
public class User
{
  [Key]
  public int UserId { get; set; }

  public string? Name { get; set; }

  public string? Email { get; set; }

  public string? Password { get; set; }

  public string? UserType { get; set; }

  public List<Booking>? Bookings { get; set; }
}