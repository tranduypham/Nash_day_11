using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_2.Models;

namespace EF_Core_2.Repository
{
    public interface ICategoriesRepository
    {
        public List<Category> GetAll();
        public void Add(Category product);
        public void Update(int id, Category product);
        public void Delete(int id);
    }
}