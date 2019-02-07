using System.Collections.Generic;
using System.Linq;
using Ensurance.Models;
using Ensurance.Repository;


namespace Ensurance.DataManager
{
    public class PolicyManager : IDataRepository<Policy>
    {
        readonly EnsuranceContext _ensuranceContext;

        public PolicyManager(EnsuranceContext context)
        {
            _ensuranceContext = context;
        }

        public IEnumerable<Policy> GetAll()
        {
            return _ensuranceContext.Policies.ToList();
        }

        public Policy Get(long id)
        {
            return _ensuranceContext.Policies
                  .FirstOrDefault(e => e.PolicyNumber == id);
        }

        public void Add(Policy entity)
        {
            _ensuranceContext.Policies.Add(entity);
            _ensuranceContext.SaveChanges();
        }

        public void Update(Policy policy, Policy entity)
        {
            policy.CoveragePeriod = entity.CoveragePeriod;
            policy.Description = entity.Description;
            policy.Name = entity.Name;
            policy.PolicyNumber = entity.PolicyNumber;
            policy.Price = entity.Price;
            policy.RiskType = entity.RiskType;
            policy.StartingDate = entity.StartingDate;

            _ensuranceContext.SaveChanges();
        }

        public void Delete(Policy policy)
        {
            _ensuranceContext.Policies.Remove(policy);
            _ensuranceContext.SaveChanges();
        }
    }
}