using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.DataAccessLayer.Repositories
{
    public interface ISaleRepository : IRepository<Sale>
    {
        (IList<Sale> sales, int count) GetPyPage<TOrderKey>(int pageNumber, int pageCapacity, Expression<Func<Sale, TOrderKey>> orderBy, QueryOrder order);
    }
}
