using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace MarqueeManagement.MenuItems;

public class MenuItemManager : DomainService
{
    private readonly IMenuItemRepository _menuItemRepository;
    public MenuItemManager(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    public async Task<MenuItem> CreateAsync(
        string name,
        string? description,
        int price,
        bool isAvailable
        )
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingMenuItem = await _menuItemRepository.FindByNameAsync(name);
        if (existingMenuItem != null)
        {
            throw new MenuItemAlreadyExistsException(name);
        }
        return new MenuItem(
            GuidGenerator.Create(),
            name,
            description,
            price,
            isAvailable
            );

    }
    public async Task UpdateAsync(
       MenuItem menuItem,
       string name,
       string? description,
       int price,
       bool isAvailable
   )
    {
        Check.NotNull(menuItem, nameof(menuItem));
        Check.NotNullOrWhiteSpace(name, nameof(name));
        var existingMenuItem = await _menuItemRepository.FindByNameAsync(name);
        if (existingMenuItem != null && existingMenuItem.Id != menuItem.Id)
        {
            throw new MenuItemAlreadyExistsException(name);
        }

        menuItem.ChangeName(name)
               .ChangeDescription(description)
               .ChangePrice(price);
        menuItem.IsAvailable = isAvailable;
    }
}
