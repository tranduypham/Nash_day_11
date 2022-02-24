using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_2.Models;
using EF_Core_2.Repository;

namespace EF_Core_2.Services
{
    public class ProductServices : IProductServices
    {
        private IProductsRepository _productsRepository;

        public ProductServices(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public void Add(Product product)
        {
            _productsRepository.Add(product);
        }

        public void Delete(int id)
        {
            _productsRepository.Delete(id);
        }

        public List<Product> GetAll()
        {
            return _productsRepository.GetAll();
        }

        public void Update(int id, Product product)
        {
            _productsRepository.Update(id, product);
        }
    }
}