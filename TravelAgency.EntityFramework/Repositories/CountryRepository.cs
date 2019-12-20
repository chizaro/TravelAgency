using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;

namespace TravelAgency.EntityFramework.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(TravelAgencyContext context) : base(context)
        {
        }

        public (IList<Country> countries, int count) GetPyPage(int pageNumber, int pageCapacity)
        {
            var countries = dbSet.AsNoTracking().OrderBy(c => c.Name);
            return (countries.Skip(pageNumber * pageCapacity).Take(pageCapacity).ToList(), countries.Count());
        }
    }
}
