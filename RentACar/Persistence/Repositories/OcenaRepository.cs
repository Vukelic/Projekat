using RentACar.Core.Repositories;
using RentACar.DAO;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Persistence.Repositories
{
    public class OcenaRepository : Repository<Ocena>, IOcenaRepository
    {
        public OcenaRepository(ModelContainer context) : base (context) { }

        public List<Ocena> OceneOdKlijenta(string jmbg)
        {
            return ModelContainer.Ocene.Where(x => x.KlijentJmbg == jmbg).ToList();
        }

        public List<Ocena> OceneZaVozilo(int id)
        {
            return ModelContainer.Ocene.Where(x => x.VoziloId == id).ToList();
        }

        public ModelContainer ModelContainer
        {
            get { return _context as ModelContainer; }
        }
    }
}
