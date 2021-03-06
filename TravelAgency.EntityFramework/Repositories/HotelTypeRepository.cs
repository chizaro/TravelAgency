﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;

namespace TravelAgency.EntityFramework.Repositories
{
    public class HotelTypeRepository : BaseRepository<HotelType>, IHotelTypeRepository
    {
        public HotelTypeRepository(TravelAgencyContext context) : base(context)
        {
        }
    }
}
