using System.ComponentModel.DataAnnotations;

namespace MarqueeManagement.BookingMenuOptions;

public class CreateBookingMenuOptionDto
{
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal Price { get; set; }

}
