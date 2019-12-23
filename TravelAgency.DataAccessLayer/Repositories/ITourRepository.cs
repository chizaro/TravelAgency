using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.DataAccessLayer.Repositories
{
    public interface ITourRepository : IRepository<Tour>
    {
        (IList<Tour> tours, int count) GetPyPage<TOrderKey>(int pageNumber, int pageCapacity, Expression<Func<Tour, TOrderKey>> orderBy,
            QueryOrder order, params Expression<Func<Tour, object>>[] includeProperties);

        (IList<Tour> tours, int count) GetPyPage(int pageNumber, int pageCapacity, int countryId, DateTime dateFrom, DateTime dateTo,
             params Expression<Func<Tour, object>>[] includeProperties);

        Tour GetByTourPageId(int id);
    }
}
