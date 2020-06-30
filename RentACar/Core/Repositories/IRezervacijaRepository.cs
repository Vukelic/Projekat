using RentACar.DAO;
using System.Collections.Generic;

namespace RentACar.Core.Repositories
{
    public interface IRezervacijaRepository : IRepository<Rezervacija>
    {
        List<Rezervacija> RezervacijeOdKlijenta(string jmbg);
        List<Rezervacija> RezervacijaSaOsiguranjem(int id);
        List<Rezervacija> RezervacijeOdAgenta(string jmbg);
        List<Rezervacija> RezervacijeZaVozilo(int id);
    }
}
