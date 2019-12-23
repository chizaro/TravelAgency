using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.DataAccessLayer.Repositories
{
    public interface ITourPageRepository : IRepository<TourPage>
    {
        (IList<TourPage> pages, int count) GetPyPage(int pageNumber, int pageCapacity);

        TourPage GetByUrl(string url);
    }
}
