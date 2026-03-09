using Volo.Abp.Application.Dtos;

namespace MarqueeManagement.BookingMenuOptions;

public class GetBookingMenuOptionListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }

}
