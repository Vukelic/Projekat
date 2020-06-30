using System.Data.Entity;
using System.Linq;

namespace RentACar.DAO
{
    public class KlijentRepository : Repository<Klijent>, IKlijentRepository
    {
        public KlijentRepository(ModelContainer context) : base(context) { }

        public Klijent GetKlijentByJmbg(string jmbg)
        {
            return ModelContainer.Klijenti.Where(x => x.Jmbg == jmbg).FirstOrDefault();
        }

        public void RemoveByJmbg(string jmbg)
        {
            Klijent entityToDelete = _context.Set<Klijent>().Find(jmbg);
            _context.Entry(entityToDelete).State = EntityState.Deleted;
        }

        public ModelContainer ModelContainer
        {
            get { return _context as ModelContainer; }
        }
    }
}
