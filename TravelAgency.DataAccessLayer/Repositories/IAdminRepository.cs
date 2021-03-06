﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.DataAccessLayer.Repositories
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Admin GetByLogin(string login);

        bool IsExist(string login);

        (IList<Admin> admins, int count) GetPyPage(int pageNumber, int pageCapacity);
    }
}
