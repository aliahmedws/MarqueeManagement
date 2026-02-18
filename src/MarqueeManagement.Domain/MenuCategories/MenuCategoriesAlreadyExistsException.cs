using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace MarqueeManagement.MenuCategories;

public class MenuCategoriesAlreadyExistsException : BusinessException
{
    public MenuCategoriesAlreadyExistsException(string name)
        : base(MarqueeManagementDomainErrorCodes.MenuCategoryAlreadyExists)
    {
        WithData("name", name);
    }
}
