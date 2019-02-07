using Ensurance.Models;
using Ensurance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ensurance.DataManager
{
    public class CoveringManager : IDataRepository<Covering>
    {

        readonly EnsuranceContext _ensuranceContext;

        public CoveringManager(EnsuranceContext context)
        {
            _ensuranceContext = context;
        }


        public void Add(Covering entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Covering policy)
        {
            throw new NotImplementedException();
        }

        public Covering Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Covering> GetAll()
        {
            return _ensuranceContext.Coverings.ToList();
        }

        public void Update(Covering policy, Covering entity)
        {
            throw new NotImplementedException();
        }
    }
}
