using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_2.Models;

namespace EF_Core_2.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private ProductDbContext _dbContext;
        public CategoriesRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private void TransactionManager (Action function){
            var transaction = _dbContext.Database.BeginTransaction();
            try{
                function();
                transaction.Commit();
            }catch(Exception e){
                transaction.Rollback();
            }
        }

        public void Add(Category category)
        {
            TransactionManager(()=>{
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
            });
        }

        public void Delete(int id)
        {
            TransactionManager(()=>{
                var category = _dbContext.Categories.Find(id);
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            });
        }

        public List<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public void Update(int id, Category category)
        {
            TransactionManager(()=>{
                var updatedCategory = _dbContext.Categories.Find(id);
                
                updatedCategory.CategoryName = category.CategoryName;

                _dbContext.SaveChanges();
            });
        }
    }
}