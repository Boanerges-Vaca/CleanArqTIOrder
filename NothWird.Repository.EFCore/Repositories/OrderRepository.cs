using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using NorthWind.Repository.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repository.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly NorthWindContext context;

        public OrderRepository(NorthWindContext context)
        {
            this.context = context;
        }

        public void Create(Order order)
        {
            context.Orders.Add(order);
        }

        public IEnumerable<Order> GetOrdersBySpecification(Specification<Order> specification)
        {
            var ExpressionDelegate = specification.Expression.Compile();
            return context.Orders.Where(ExpressionDelegate);
        }
    }
}
