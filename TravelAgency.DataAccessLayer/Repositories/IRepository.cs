using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataAccessLayer.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        void Save(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        IList<TEntity> GetAll();
    }

}
