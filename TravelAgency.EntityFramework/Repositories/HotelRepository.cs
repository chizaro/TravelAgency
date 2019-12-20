using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;

namespace TravelAgency.EntityFramework.Repositories
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(TravelAgencyContext context): base(context)
        {
        }

        public (IList<Hotel> hotels, int count) GetPyPage<TOrderKey>(int pageNumber, int pageCapacity, Expression<Func<Hotel, TOrderKey>> orderBy,
            QueryOrder order, params Expression<Func<Hotel, object>>[] includeProperties)
        {
            var hotels = Include(includeProperties);
            hotels = order == QueryOrder.Asc ? hotels.OrderBy(orderBy) : hotels.OrderByDescending(orderBy);
            return (hotels.Skip(pageNumber * pageCapacity).Take(pageCapacity).ToList(), hotels.Count());
        }
    }
}
