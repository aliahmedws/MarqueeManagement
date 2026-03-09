using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MarqueeManagement.BookingMenuOptions;
public class BookingMenuOption : FullAuditedAggregateRoot<Guid>
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    private BookingMenuOption()
    {
    }
    internal BookingMenuOption(Guid id,
        int quantity,
        decimal price
        ) : base(id)
    {
        Quantity = quantity;
        Price = price;
    }
}