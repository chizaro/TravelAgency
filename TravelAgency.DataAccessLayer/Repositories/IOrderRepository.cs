using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.DataAccessLayer.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        (IList<Order> tours, int count) GetPyPage(int pageNumber, int pageCapacity, params Expression<Func<Order, object>>[] includeProperties);

        IList<Order> GetByDate(DateTime date, params Expression<Func<Order, object>>[] includeProperties);
    }
}
