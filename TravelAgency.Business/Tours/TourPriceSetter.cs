using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.Business.Tours
{
    public static class TourPriceSetter
    {
        public static IList<Tour> SetPriceWithSale(IList<Tour> tours)
        {
            foreach (var item in tours)
            {
                if (item.Sale != null)
                    item.Price = CountSale(item);
            }
            return tours;
        }

        public static Tour SetPriceWithSale(Tour tour)
        {
            if (tour.Sale == null)
                return tour;

            tour.Price = CountSale(tour);
            return tour;
        }

        private static int CountSale(Tour item)
        {
            return (int)Math.Round(item.Price * (1 - item.Sale.Size / 100));
        }

    }
}
