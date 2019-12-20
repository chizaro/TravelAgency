using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.DataAccessLayer.Repositories
{
    public interface ITourTypeRepostiory : IRepository<TourType>
    {
        (IList<TourType> tourTypes, int count) GetPyPage(int pageNumber, int pageCapacity);
    }
}
