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
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(TravelAgencyContext context) : base(context)
        {
        }

        public (IList<Sale> sales, int count) GetPyPage<TOrderKey>(int pageNumber, int pageCapacity, Expression<Func<Sale, TOrderKey>> orderBy, QueryOrder order)
        {
            IQueryable<Sale> sales = dbSet.AsNoTracking();
            sales = order == QueryOrder.Asc ? sales.OrderBy(orderBy) : sales.OrderByDescending(orderBy);
            return (sales.Skip(pageNumber * pageCapacity).Take(pageCapacity).ToList(), sales.Count());
        }
    }
}
