using RentACar.Core.Repositories;
using RentACar.DAO;
using System;
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

        public Rezervacija ProveraCenovnika(DateTime pocetak, DateTime kraj, int VoziloId)
        {
            Rezervacija r = new Rezervacija();
             foreach (var item in ModelContainer.Cenovniks.Where(x => x.VoziloId == VoziloId))
             {
                if ((item.DatumPocetka <= pocetak && item.DatumKraja >= kraj) || item.DatumPocetka >= pocetak && item.DatumKraja <= kraj)
                {
                   
                    r.Cenovnik = item;                    
                    return r;
                 }
             }         
            return null;
        }

        public bool Rezervisi(DateTime pocetak, DateTime kraj, int VoziloId)
        {
            foreach (var item in ModelContainer.Rezervacije.Where(x => x.VoziloId == VoziloId))
            {
                if ((item.Datum_preuzimanja <= pocetak && item.Datum_vracanja >= kraj) || item.Datum_preuzimanja >= pocetak && item.Datum_vracanja <= kraj)
                {
                    if(item.Rezervisano == true)
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }

        public int IzracunajCenu(DateTime DatumPocetka, DateTime DatumKraja, int CenaPoDanu)
        {
            double cena = 0;

            double dani = (DatumKraja - DatumPocetka).TotalDays + 1;
            cena = CenaPoDanu * dani;

            return Convert.ToInt32(cena);
        }
    }
}
