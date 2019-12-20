using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Web
{
    public static class PageCounter
    {
        public static int CountTotalPages(int itemCount, int pagingSize)
        {
            return (itemCount + pagingSize - 1) / pagingSize;
        }

    }
}