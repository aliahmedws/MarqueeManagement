using System;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace MarqueeManagement.BookingMenuOptions;

public class MenuItemOptionManager : DomainService
{
    public BookingMenuOption Create(Guid bookingId,
        int quantity,
        decimal price
        )
    {
        if (quantity <= 0)
        {
            throw new BusinessException("Quantity must be greater than zero");
        }
        return new BookingMenuOption(
            GuidGenerator.Create(),
            quantity,
            price
        );
    }
    public void Update(BookingMenuOption menuOption, int quantity, decimal price)
    {
        Check.NotNull(menuOption, nameof(menuOption));

        if (quantity <= 0)
        {
            throw new BusinessException("Quantity must be greater than zero");
        }

        menuOption.Quantity = quantity;
        menuOption.Price = price;
    }

}
