using System.Collections.Generic;

namespace RentACar.DAO
{
    public interface IAgentiRepository : IRepository<Agent>
    {
        Agent GetAgentByJmbg(string jmbg);
        void RemoveByJmbg(string jmbg);
    }
}
