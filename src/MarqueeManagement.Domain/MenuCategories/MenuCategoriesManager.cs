using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace MarqueeManagement.MenuCategories;

public class MenuCategoriesManager : DomainService
{
    private readonly IMenuCategoriesRepository _menuCategoriesRepository;
    public MenuCategoriesManager(IMenuCategoriesRepository menuCategoriesRepository)
    {
        _menuCategoriesRepository = menuCategoriesRepository;
    }
    public async Task<MenuCategories> CreateAsync(Guid id, string name, string? description)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        var existing = await _menuCategoriesRepository.FindByNameAsync(name);
        if (existing != null)
        {
            throw new UserFriendlyException("MenuCategoryAlreadyExists");
                
        }
        return new MenuCategories
        (
            GuidGenerator.Create(),
            name,
            description);
     }
    public async Task ChangeNameAsync(
        MenuCategories menucategories,
        string newName)
    {
        Check.NotNullOrWhiteSpace(newName, nameof(newName));
        var existing = await _menuCategoriesRepository.FindByNameAsync(newName);
        if (existing != null && existing.Id != menucategories.Id)
        {
            throw new UserFriendlyException("MenuCategoryAlreadyExists");
        }
        menucategories.SetName(newName);
    }
 }
