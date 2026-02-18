using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MarqueeManagement.MenuCategories;

public interface IMenuCategoriesRepository : IRepository<MenuCategories, Guid>

{
    Task<MenuCategories> FindByNameAsync(string name);
    Task<List<MenuCategories>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
        );
}
