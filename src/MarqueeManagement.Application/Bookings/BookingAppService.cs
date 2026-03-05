using Microsoft.AspNetCore.Authorization;
using MarqueeManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace MarqueeManagement.Bookings;

[RemoteService(IsEnabled = false)]
[Authorize(MarqueeManagementPermissions.Bookings.Default)]
public class BookingAppService : MarqueeManagementAppService, IBookingAppService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly BookingManager _bookingManager;

    public BookingAppService(
        IBookingRepository bookingRepository,
        BookingManager bookingManager)
    {
        _bookingRepository = bookingRepository;
        _bookingManager = bookingManager;
    }

    public async Task<BookingDto> GetAsync(Guid id)
    {
        var entity = await _bookingRepository.GetAsync(id);
        return ObjectMapper.Map<Booking, BookingDto>(entity);
    }
    public async Task<PagedResultDto<BookingDto>> GetListAsync(GetBookingListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Booking.EventDate);
        }

        var list = await _bookingRepository.GetListAsync(
         input.SkipCount,
         input.MaxResultCount,
         input.Sorting,
         input.Filter,
         input.EventType,
         input.Status
        );

        var totalCount = await _bookingRepository.GetCountAsync(
            input.Filter,
            input.EventType,
            input.Status
        );

        var dtoList = ObjectMapper.Map<List<Booking>, List<BookingDto>>(list);
        return new PagedResultDto<BookingDto>(totalCount, dtoList);
    }

    [Authorize(MarqueeManagementPermissions.Bookings.Create)]
    public async Task<BookingDto> CreateAsync(CreateBookingDto input)
    {
        var entity = await _bookingManager.CreateAsync(
            input.EventDate,
            input.EventType,
            input.GuestCount,
            input.TotalAmount,
            input.Status
        );

        await _bookingRepository.InsertAsync(entity);
        return ObjectMapper.Map<Booking, BookingDto>(entity);
    }

    [Authorize(MarqueeManagementPermissions.Bookings.Edit)]
    public async Task UpdateAsync(Guid id, UpdateBookingDto input)
    {
        var entity = await _bookingRepository.GetAsync(id);
        await _bookingManager.UpdateAsync(
            entity,
            input.EventDate,
            input.EventType,
            input.GuestCount,
            input.TotalAmount,
            input.Status
        );

        await _bookingRepository.UpdateAsync(entity);
    }

    [Authorize(MarqueeManagementPermissions.Bookings.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _bookingRepository.DeleteAsync(id);
    }
}