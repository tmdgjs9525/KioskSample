using KioskSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.Services
{
    public class DishMenuRepository : IDishMenuRepository
    {
        public Task AddAsync(DishMenu product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DishMenu> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DishMenu>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<List<DishMenu>> GetByCateogryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<DishMenu?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DishMenu product)
        {
            throw new NotImplementedException();
        }
    }
}
