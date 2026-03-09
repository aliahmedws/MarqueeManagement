using MarqueeManagement.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MarqueeManagement.BookingMenuOptions;

[RemoteService(IsEnabled = false)]
[Authorize(MarqueeManagementPermissions.BookingMenuOptions.Default)]
public class BookingMenuOptionAppService : MarqueeManagementAppService, IBookingMenuOptionAppService
{
    private readonly IRepository<BookingMenuOption, Guid> _bookingMenuOptionRepository;
    private readonly MenuItemOptionManager _menuItemOptionManager;

    public BookingMenuOptionAppService(
        IRepository<BookingMenuOption, Guid> bookingMenuOptionRepository,
        MenuItemOptionManager menuItemOptionManager)
    {
        _bookingMenuOptionRepository = bookingMenuOptionRepository;
        _menuItemOptionManager = menuItemOptionManager;
    }

    public async Task<BookingMenuOptionDto> GetAsync(Guid id)
    {
        var entity = await _bookingMenuOptionRepository.GetAsync(id);
        return ObjectMapper.Map<BookingMenuOption, BookingMenuOptionDto>(entity);
    }

    public async Task<PagedResultDto<BookingMenuOptionDto>> GetListAsync(GetBookingMenuOptionListDto input)
    {
        var allItems = await _bookingMenuOptionRepository.GetListAsync();

        if (!string.IsNullOrWhiteSpace(input.Filter))
        {
            allItems = allItems
                .FindAll(x => x.Quantity.ToString().Contains(input.Filter)
                           || x.Price.ToString().Contains(input.Filter));
        }

        var totalCount = allItems.Count;

        if (input.Sorting.IsNullOrWhiteSpace() || input.Sorting == nameof(BookingMenuOption.Price))
        {
            allItems.Sort((a, b) => a.Price.CompareTo(b.Price));
        }
        else if (input.Sorting == nameof(BookingMenuOption.Quantity))
        {
            allItems.Sort((a, b) => a.Quantity.CompareTo(b.Quantity));
        }

        var pagedItems = allItems
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .ToList();

        var dtoList = ObjectMapper.Map<List<BookingMenuOption>, List<BookingMenuOptionDto>>(pagedItems);

        return new PagedResultDto<BookingMenuOptionDto>(totalCount, dtoList);
    }

    [Authorize(MarqueeManagementPermissions.BookingMenuOptions.Create)]
    public async Task<BookingMenuOptionDto> CreateAsync(CreateBookingMenuOptionDto input)
    {
        var entity = _menuItemOptionManager.Create(
            Guid.NewGuid(), 
            input.Quantity,
            input.Price
        );

        await _bookingMenuOptionRepository.InsertAsync(entity);

        return ObjectMapper.Map<BookingMenuOption, BookingMenuOptionDto>(entity);
    }

    [Authorize(MarqueeManagementPermissions.BookingMenuOptions.Edit)]
    public async Task UpdateAsync(Guid id, UpdateBookingMenuOptionDto input)
    {
        var entity = await _bookingMenuOptionRepository.GetAsync(id);
        _menuItemOptionManager.Update(entity, input.Quantity, input.Price);
        await _bookingMenuOptionRepository.UpdateAsync(entity);
    }

    [Authorize(MarqueeManagementPermissions.BookingMenuOptions.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _bookingMenuOptionRepository.DeleteAsync(id);
    }
}