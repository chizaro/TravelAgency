using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Entities;
using TravelAgency.DataAccessLayer.Repositories;

namespace TravelAgency.EntityFramework.Repositories
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(TravelAgencyContext context) : base(context)
        {
        }

        public Admin GetByLogin(string login)
        {
            return dbSet.Where(a => a.Login == login).FirstOrDefault();
        }
    }
}
