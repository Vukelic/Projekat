using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RentACar.DAO
{
    public class ZaposleniRepository : Repository<Zaposleni>, IZaposleniRepository
    {
        public ZaposleniRepository(ModelContainer context) : base(context) { }

        public Zaposleni GetZaposleniByJmbg(string jmbg)
        {
            return ModelContainer.Zaposleni.Where(x => x.Jmbg == jmbg).FirstOrDefault();
        }

        public void RemoveByJmbg(string jmbg)
        {
            Zaposleni entityToDelete = _context.Set<Zaposleni>().Find(jmbg);
            _context.Entry(entityToDelete).State = EntityState.Deleted;
        }

        public List<Zaposleni> GetZaposleniUFilijali(int filijalaId)
        {
            return ModelContainer.Zaposleni.Where(x => x.FilijalaId == filijalaId).ToList();
        }

        public ModelContainer ModelContainer
        {
            get { return _context as ModelContainer; }
        }
    }
}

