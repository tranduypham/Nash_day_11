using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_2.Models;
using EF_Core_2.Repository;

namespace EF_Core_2.Services
{
    public class CategoryServices : ICategoryServices
    {
        private ICategoriesRepository _categoriesRepository;

        public CategoryServices(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public void Add(Category category)
        {
            _categoriesRepository.Add(category);
        }

        public void Delete(int id)
        {
            _categoriesRepository.Delete(id);
        }

        public List<Category> GetAll()
        {
            return _categoriesRepository.GetAll();
        }

        public void Update(int id, Category category)
        {
            _categoriesRepository.Update(id, category);
        }
    }
}