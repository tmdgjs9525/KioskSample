using KioskSample.Core.Models;
using KioskSample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.Services
{
    public class DishMenuRepositoryStub : IDishMenuRepository
    {
        private List<DishMenu> _dishMenuList = new();
        public DishMenuRepositoryStub()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                _dishMenuList.Add(new DishMenu()
                {
                    Id = i,
                    Name = i.ToString() + "메인 메뉴",
                    Price = new Money(random.Next(0, 50000), "KRW"),
                    Category = "메인 메뉴"
                });
            }
            
            for (int i = 10; i < 20; i++)
            {
                _dishMenuList.Add(new DishMenu()
                {
                    Id = i,
                    Name = i.ToString() + "사이드",
                    Price = new Money(random.Next(0, 40000), "KRW"),
                    Category = "사이드"
                });
            }

            for (int i = 20; i < 30; i++)
            {
                _dishMenuList.Add(new DishMenu()
                {
                    Id = i,
                    Name = i.ToString() + "음료",
                    Price = new Money(random.Next(1000, 30000), "KRW"),
                    Category = "음료"
                });
            }
        }

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
            return _dishMenuList;
        }

        public Task<IEnumerable<DishMenu>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllCategories()
        {
            return new List<string>() {"전체", "메인 메뉴", "사이드", "음료" };
        }

        public Task<List<DishMenu>> GetByCateogryAsync(string category)
        {
            if (category == "전체")
            {
                return Task.FromResult(_dishMenuList);
            }

            //인터페이스 수정 없이 반환
            var result = _dishMenuList.Where(d => d.Category == category).ToList();
            return Task.FromResult(result);
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
