using System.ComponentModel.DataAnnotations;

namespace MarqueeManagement.BookingMenuOptions;

public class UpdateBookingMenuOptionDto
{
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal Price { get; set; }

}
