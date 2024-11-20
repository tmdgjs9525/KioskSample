using KioskSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.Services
{
    public interface IDishMenuRepository
    {
        Task<DishMenu?> GetByIdAsync(int id);

        Task<List<DishMenu>> GetByCateogryAsync(string category);

        List<string> GetAllCategories();

        IEnumerable<DishMenu> GetAll();
        Task<IEnumerable<DishMenu>> GetAllAsync();
        Task AddAsync(DishMenu product);
        Task UpdateAsync(DishMenu product);
        Task DeleteAsync(int id);
    }
}
