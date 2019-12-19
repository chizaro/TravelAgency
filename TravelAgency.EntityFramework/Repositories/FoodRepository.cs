using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;

namespace TravelAgency.EntityFramework.Repositories
{
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {
        public FoodRepository(TravelAgencyContext context) : base(context)
        {
        }
    }
}
