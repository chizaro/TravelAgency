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
            return dbSet.AsNoTracking().Where(a => a.Login == login).FirstOrDefault();
        }

        public (IList<Admin> admins, int count) GetPyPage(int pageNumber, int pageCapacity)
        {
            var admins = dbSet.AsNoTracking().OrderBy(a => a.FirstName).ThenBy(a => a.LastName);
            return (admins.Skip(pageNumber * pageCapacity).Take(pageCapacity).ToList(), admins.Count());
        }

        public bool IsExist(string login)
        {
            return GetByLogin(login) != null;
        }
    }
}
