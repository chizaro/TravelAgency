using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.DataAccessLayer.Repositories
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        (IList<Hotel> hotels, int count) GetPyPage<TOrderKey>(int pageNumber, int pageCapacity, Expression<Func<Hotel, TOrderKey>> orderBy,
            QueryOrder order, params Expression<Func<Hotel, object>>[] includeProperties);
    }
}
