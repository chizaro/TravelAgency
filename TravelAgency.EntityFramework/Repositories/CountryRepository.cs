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
    }
}
