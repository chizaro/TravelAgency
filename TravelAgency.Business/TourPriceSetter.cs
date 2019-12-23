using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.Business
{
    public class TourPriceSetter
    {
        public static IList<Tour> SetPriceWithSale(IList<Tour> tours)
        {
            foreach (var item in tours)
            {
                if (item.Sale != null)
                    item.Price = (int) Math.Round(item.Price * (1 - item.Sale.Size / 100));
            }
            return tours;
        }
    }
}
