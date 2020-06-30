using RentACar.Core.Repositories;
using RentACar.DAO;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Persistence.Repositories
{
    public class RezervacijaRepository : Repository<Rezervacija>, IRezervacijaRepository
    {
        public RezervacijaRepository(ModelContainer context) : base(context) { }

        public List<Rezervacija> RezervacijeOdKlijenta(string jmbg)
        {
            return ModelContainer.Rezervacije.Where(x => x.KlijentJmbg == jmbg).ToList();
        }

        public List<Rezervacija> RezervacijaSaOsiguranjem(int id)
        {
            return ModelContainer.Rezervacije.Where(x => x.OsiguranjeId == id).ToList();
        }

        public List<Rezervacija> RezervacijeOdAgenta(string jmbg)
        {
            return ModelContainer.Rezervacije.Where(x => x.AgentJmbg == jmbg).ToList();
        }

        public List<Rezervacija> RezervacijeZaVozilo(int id)
        {
            return ModelContainer.Rezervacije.Where(x => x.VoziloId == id).ToList();
        }

        public ModelContainer ModelContainer
        {
            get { return _context as ModelContainer; }
        }
    }
}
