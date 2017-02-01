using Business.Enums;
using Business.Exceptions;
using Business.Interfaces;
using Data;
using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        IRepository<Category> categoryRepository = new Repository<Category>();

        #region Default actions
        public IQueryable<Category> GetAll(int take = -1, int offset = 0)
        {
            var query = categoryRepository.Query().OrderBy(x => x.Name).Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public void SaveOrUpdate(Category set)
        {
            categoryRepository.Save(set);
        }

        public void Delete(int id)
        {
            var set = categoryRepository.GetById(id);
            if (set != null)
            {
                categoryRepository.Delete(set);
            }
            else
            {
                throw new DataException("Category not found!");
            }
        }

        #endregion

    }
}
