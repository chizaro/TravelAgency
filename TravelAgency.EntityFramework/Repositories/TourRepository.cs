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
    public class TourRepository : BaseRepository<Tour>, ITourRepository
    {
        public TourRepository(TravelAgencyContext context) : base(context)
        {
        }

        public Tour GetByTourPageId(int id)
        {
            return dbSet.Where(t => t.TourPageId == id).FirstOrDefault();
        }

        public (IList<Tour> tours, int count) GetPyPage<TOrderKey>(int pageNumber, int pageCapacity, Expression<Func<Tour, TOrderKey>> orderBy, QueryOrder order,
                params Expression<Func<Tour, object>>[] includeProperties)
        {
            var tours = Include(includeProperties);
            tours = order == QueryOrder.Asc ? tours.OrderBy(orderBy) : tours.OrderByDescending(orderBy);
            return (tours.Skip(pageNumber * pageCapacity).Take(pageCapacity).ToList(), tours.Count());
        }
    }
}
