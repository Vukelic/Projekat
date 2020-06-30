using System.Data.Entity;
using System.Linq;

namespace RentACar.DAO
{
    public class ServiseriRepository : Repository<Serviser>, IServiseriRepository
    {
        public ServiseriRepository(ModelContainer context) : base(context) { }

        public Serviser GetServiserByJmbg(string jmbg)
        {
            return (Serviser)ModelContainer.Zaposleni.Where(x => x.Jmbg == jmbg).FirstOrDefault();
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
