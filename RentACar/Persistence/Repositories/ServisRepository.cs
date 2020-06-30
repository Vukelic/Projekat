using RentACar.Core.Repositories;
using RentACar.DAO;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Persistence.Repositories
{
    public class ServisRepository : Repository<Servis>, IServisRepository
    {
        public ServisRepository(ModelContainer context) : base(context) { }
        public ModelContainer ModelContainer
        {
            get { return _context as ModelContainer; }
        }

        public List<Servis> GetServisiOdServisera(string jmbg)
        {
            return ModelContainer.Servisi.Where(x => x.ServiserJmbg == jmbg).ToList();
        }

        public List<Servis> GetServisiZaVozilo(int id)
        {
            return ModelContainer.Servisi.Where(x => x.VoziloId == id).ToList();
        }
    }
}
