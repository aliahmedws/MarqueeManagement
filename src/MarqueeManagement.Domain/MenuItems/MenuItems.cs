using MarqueeManagement.Marquees;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MarqueeManagement.MenuItems;

public class MenuItems : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }
    public bool IsAvailable { get; set; }
    public Guid? TenantId { get; set; }


    public MenuItems()
    {
    }

    internal MenuItems(Guid id,
        string name,
        string? description,
        int price,
        bool isAvailable
        ) : base(id)
    {
        SetName(name);
        SetDescription(description);
        SetPrice(price);
        IsAvailable = isAvailable;
    }

    private void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: MenuItemConsts.MaxNameLength
        );
    }

    internal MenuItems ChangeName(string name)
    {
        SetName(name);
        return this;
    }

    internal MenuItems ChangeDescription(string description)
    {
        SetDescription(description);
        return this;
    }

    private void SetDescription(string? description)
    {
        if (!description.IsNullOrWhiteSpace())
        {
            Description = Check.Length(description,
                nameof(description),
                MenuItemConsts.MaxDescriptionLength
            );
        }
        else
        {
            Description = null;
        }
    }
    internal MenuItems ChangePrice(int price)
    {
        SetPrice(price);
        return this;
    }
    private void SetPrice(int price)
    {
        Price = Check.Range(
            price,
            nameof(price),
            minimumValue: MenuItemConsts.MinPriceValue,
            maximumValue: MenuItemConsts.MaxPriceValue
        );
    }
}
