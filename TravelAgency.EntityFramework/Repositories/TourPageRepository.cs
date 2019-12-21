using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;

namespace TravelAgency.EntityFramework.Repositories
{
    public class TourPageRepository : BaseRepository<TourPage>, ITourPageRepository
    {
        public TourPageRepository(TravelAgencyContext context) : base(context)
        {
        }

        public (IList<TourPage> pages, int count) GetPyPage(int pageNumber, int pageCapacity)
        {
            var pages = dbSet.AsNoTracking().OrderBy(p => p.Title);
            return (pages.Skip(pageNumber * pageCapacity).Take(pageCapacity).ToList(), pages.Count());
        }
    }
}
