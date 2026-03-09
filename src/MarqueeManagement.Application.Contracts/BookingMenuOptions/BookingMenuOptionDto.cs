using System;
using Volo.Abp.Application.Dtos;

namespace MarqueeManagement.BookingMenuOptions;

public class BookingMenuOptionDto : EntityDto<Guid>
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }

}
