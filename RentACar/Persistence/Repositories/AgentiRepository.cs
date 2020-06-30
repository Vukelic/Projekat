using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RentACar.DAO
{
    public class AgentiRepository : Repository<Agent>, IAgentiRepository
    {
        public AgentiRepository(ModelContainer context) : base(context) { }
 
        public Agent GetAgentByJmbg(string jmbg)
        {
            return (Agent)ModelContainer.Zaposleni.Where(x => x.Jmbg == jmbg).FirstOrDefault();
        }

        public void RemoveByJmbg(string jmbg)
        {
            Zaposleni entityToDelete = _context.Set<Zaposleni>().Find(jmbg);
            _context.Entry(entityToDelete).State = EntityState.Deleted;
        }

        public ModelContainer ModelContainer
        {
            get { return _context as ModelContainer; }
        }

    }
}
