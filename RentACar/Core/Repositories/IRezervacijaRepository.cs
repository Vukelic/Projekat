using RentACar.DAO;
using System;
using System.Collections.Generic;

namespace RentACar.Core.Repositories
{
    public interface IRezervacijaRepository : IRepository<Rezervacija>
    {
        List<Rezervacija> RezervacijeOdKlijenta(string jmbg);
        List<Rezervacija> RezervacijaSaOsiguranjem(int id);
        List<Rezervacija> RezervacijeOdAgenta(string jmbg);
        List<Rezervacija> RezervacijeZaVozilo(int id);
        Rezervacija ProveraCenovnika(DateTime pocetak, DateTime kraj, int VoziloId);
        int IzracunajCenu(DateTime DatumKraja, DateTime DatumPocetka, int CenaPoDanu);
        bool Rezervisi(DateTime pocetak, DateTime kraj, int VoziloId);

    }
}
