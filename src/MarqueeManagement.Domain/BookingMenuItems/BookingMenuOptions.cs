using System;
using Volo.Abp.Domain.Entities.Auditing;
namespace MarqueeManagement.BookingMenuItems;
public class BookingMenuOptions : FullAuditedAggregateRoot<Guid>
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    private BookingMenuOptions()
    {
        //constructor 
    }
    internal BookingMenuOptions(Guid id, int quantity, decimal price)
        : base(id)
    {
        Quantity = quantity;
        Price = price;
    }
}