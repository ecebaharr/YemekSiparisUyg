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
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is OrderDetailManager manager &&
                   EqualityComparer<IOrderDetailDal>.Default.Equals(_orderDetailDal, manager._orderDetailDal);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_orderDetailDal);
        }

        public void TAdd(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
        public void TDelete(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
        public List<OrderDetail> TGetAll()
        {
            throw new NotImplementedException();
        }
        public OrderDetail TGetbyID(int id)
        {
            throw new NotImplementedException();
        }
        public void TUpdate(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
   
}
