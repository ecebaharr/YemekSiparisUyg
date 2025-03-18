using System;
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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About entity)
        {
           _aboutDal.Add(entity);
        }

        public void TDelete(About entity)
        {_aboutDal.Delete(entity);
        }

        public List<About> TGetAll()
        {
            return _aboutDal.GetAll();
        }

        public About TGetbyID(int id)
        {
            return _aboutDal.GetbyID(id);
        }

       

        public void TUpdate(About entity)
        {
           _aboutDal.Update(entity);
        }
    }
}
