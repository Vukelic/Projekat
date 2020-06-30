using RentACar.Core.Repositories;
using RentACar.DAO;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Persistence.Repositories
{
    public class VoziloRepository : Repository<Vozilo>, IVoziloRepository
    {
        public VoziloRepository(ModelContainer context) : base(context) { }

        public ModelContainer ModelContainer
        {
            get { return _context as ModelContainer; }
        }

        public List<Vozilo> GetVozilaZaFilijalu(int filijalaId)
        {
            return ModelContainer.Vozila.Where(x => x.FilijalaId == filijalaId).ToList();
        }
    }
}
