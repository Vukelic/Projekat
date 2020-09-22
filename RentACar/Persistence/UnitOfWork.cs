
using RentACar.Core.Repositories;
using RentACar.Persistence.Repositories;

namespace RentACar.DAO
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ModelContainer _context;

        public UnitOfWork(ModelContainer context)
        {
            _context = context;
            Klijenti = new KlijentRepository (context);
            Gradovi = new GradRepository (context);
            Filijale = new FilijalaRepository (context);
            Zaposleni = new ZaposleniRepository (context);
            Vozila = new VoziloRepository (context);
            Ocene = new OcenaRepository (context);
            Rezervacije = new RezervacijaRepository (context);
            Agenti = new AgentiRepository (context);
            Serviseri = new ServiseriRepository (context);
            Servisi = new ServisRepository (context);
            Osiguranja = new OsiguranjeRepository(context);
            Cenovnici = new CenovnikRepository(context);
        }
        public IKlijentRepository Klijenti { get; set; }
        public IGradRepository Gradovi { get; set; }
        public IFilijalaRepository Filijale { get; set; }
        public IZaposleniRepository Zaposleni { get; set; }
        public IVoziloRepository Vozila { get; set; }
        public IOcenaRepository Ocene { get; set; }
        public IOsiguranjeRepository Osiguranja { get; set; }
        public IRezervacijaRepository Rezervacije { get; set; }
        public IAgentiRepository Agenti { get; set; }
        public IServiseriRepository Serviseri { get; set; }
        public IServisRepository Servisi { get; set; }
        
        public ICenovnikRepository Cenovnici { get; set; }
 

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
