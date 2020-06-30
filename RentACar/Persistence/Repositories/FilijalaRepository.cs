using System.Collections.Generic;
using System.Linq;

namespace RentACar.DAO
{
    public class FilijalaRepository : Repository<Filijala>, IFilijalaRepository
    {
        public FilijalaRepository(ModelContainer context) : base(context) { }

        public ModelContainer ModelContainer
        {
            get { return _context as ModelContainer; }
        }

        public List<Filijala> GetFilijaleZaGrad(int postanskiBroj)
        {
            return ModelContainer.Filijale.Where(x => x.GradPostanskiBroj == postanskiBroj).ToList();
        }
    }
}
