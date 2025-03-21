﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.EntityFramework;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TAdd(Category entity)
        {
           _categoryDal.Add(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);       }

        public List<Category> TGetAll()
        {
           return _categoryDal.GetAll();
        }

        public Category TGetbyID(int id)
        {
            return _categoryDal.GetbyID(id);
        }

        

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
