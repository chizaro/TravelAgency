using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;

namespace TravelAgency.EntityFramework.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(TravelAgencyContext context) :base(context)
        {
        }

        public IList<Order> GetByDate(DateTime date, params Expression<Func<Order, object>>[] includeProperties)
        {
            return Include(includeProperties).Where(order => order.Date == date).ToList();
        }

        public (IList<Order> tours, int count) GetPyPage(int pageNumber, int pageCapacity, params Expression<Func<Order, object>>[] includeProperties)
        {
            var tours = Include(includeProperties).OrderByDescending(order => order.Date);
            return (tours.Skip(pageNumber * pageCapacity).Take(pageCapacity).ToList(), tours.Count());
        }
    }
}
