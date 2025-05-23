﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }


        public void TAdd(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public List<Contact> TGetAll()
        {
            return _contactDal.GetAll();
        }

        public Contact TGetbyID(int id)
        {
            return _contactDal.GetbyID(id);        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
