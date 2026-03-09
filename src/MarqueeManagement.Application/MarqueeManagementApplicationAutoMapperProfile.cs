using AutoMapper;
using MarqueeManagement.BookingMenuOptions;
using MarqueeManagement.Bookings;
using MarqueeManagement.Customers;
using MarqueeManagement.Marquees;
using MarqueeManagement.MenuCategories;
using MarqueeManagement.MenuItems;

namespace MarqueeManagement;

public class MarqueeManagementApplicationAutoMapperProfile : Profile
{
    public MarqueeManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

         CreateMap<Booking, BookingDto>();
         CreateMap<BookingMenuOption, BookingMenuOptionDto>();
         CreateMap<Customer, CustomerDto>();
         CreateMap<Marquee, MarqueeDto>();
         CreateMap<MenuCategory, MenuCategoryDto>();
         CreateMap<MenuItem, MenuItemDto>();

    }
}
