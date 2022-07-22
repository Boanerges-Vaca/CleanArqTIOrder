using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.Repository.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repository.EFCore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        readonly NorthWindContext context;

        public OrderDetailRepository(NorthWindContext context)
        {
            this.context = context;
        }

        public void Create(OrderDetail orderDetail)
        {
            context.Add(orderDetail);
        }
    }
}
