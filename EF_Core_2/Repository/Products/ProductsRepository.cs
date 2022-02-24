using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_2.Models;

namespace EF_Core_2.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private ProductDbContext _productDbContext; 
        public ProductsRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        private void TransactionManager (Action function) {
            var transaction = _productDbContext.Database.BeginTransaction();
            try{
                function();
                transaction.Commit();
            }catch (Exception e) {
                transaction.Rollback();
            }
        }

        public void Add(Product product)
        {
            TransactionManager(()=>{
                _productDbContext.Products.Add(product);
                _productDbContext.SaveChanges();
            });
        }

        public void Delete(int id)
        {
            TransactionManager(()=>{
                var product = _productDbContext.Products.Find(id);
                _productDbContext.Products.Remove(product);
                _productDbContext.SaveChanges();
            });
        }

        public List<Product> GetAll()
        {
            return _productDbContext.Products.ToList<Product>();
        }

        public void Update(int id, Product product)
        {
            TransactionManager(()=>{
                var updatedProduct = _productDbContext.Products.Find(id);
                
                updatedProduct.ProductName = product.ProductName;
                updatedProduct.CategoryId = product.CategoryId;
                updatedProduct.Manufacture = product.Manufacture;

                _productDbContext.SaveChanges();
            });
        }
    }
}