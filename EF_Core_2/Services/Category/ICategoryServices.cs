using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_2.Models;

namespace EF_Core_2.Services
{
    public interface ICategoryServices
    {
        public List<Category> GetAll();
        public void Add(Category category);
        public void Update(int id, Category category);
        public void Delete(int id);
    }
}