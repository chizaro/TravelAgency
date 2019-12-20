using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;

namespace TravelAgency.EntityFramework.Repositories
{
    public class TourTypeRepository : BaseRepository<TourType>, ITourTypeRepostiory
    {
        public TourTypeRepository(TravelAgencyContext context) : base(context)
        {
        }

        public (IList<TourType> tourTypes, int count) GetPyPage(int pageNumber, int pageCapacity)
        {
            var tourTypes = dbSet.AsNoTracking().OrderBy(c => c.Name);
            return (tourTypes.Skip(pageNumber * pageCapacity).Take(pageCapacity).ToList(), tourTypes.Count());
        }
    }
}
