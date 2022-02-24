using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_2.Models;

namespace EF_Core_2.Repository
{
    public interface IProductsRepository
    {
        public List<Product> GetAll();
        public void Add(Product product);
        public void Update(int id, Product product);
        public void Delete(int id);
    }
}