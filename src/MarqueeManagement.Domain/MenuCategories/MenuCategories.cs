using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace MarqueeManagement.MenuCategories;

public class MenuCategories : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public string? Description { get; set; }

    private MenuCategories()
    {
        //constructor 
    }
    internal MenuCategories(Guid id, string name, string? description)
        : base(id)
    {
        SetName(name);
        SetDescription(description);
    }
    private void SetDescription(string? description)
    {
        if (description == null || description.Length > 500)
        {
            throw new UserFriendlyException("Description cannot exceed 500 characters.");
        }
        Description = description;
    }
    public void SetName(string name)
    {
       Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: MenuCategoriesConsts.MaxNameLength);
    }

}
