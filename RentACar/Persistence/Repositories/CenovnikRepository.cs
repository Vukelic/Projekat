using RentACar.Core.Repositories;
using RentACar.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories
{
    public class CenovnikRepository : Repository<Cenovnik>, ICenovnikRepository
    {
        public CenovnikRepository(ModelContainer context) : base(context) { }

        public ModelContainer ModelContainer
        {
            get { return _context as ModelContainer; }
        }

        public bool ProveraRezervacije(DateTime pocetak, DateTime kraj, int VoziloId)
        {

            foreach (var item in ModelContainer.Cenovniks.Where(x=> x.VoziloId == VoziloId))
            {
                if ((item.DatumPocetka <= pocetak && item.DatumKraja >= kraj) || item.DatumPocetka >= pocetak && item.DatumKraja <= kraj)
                {
                    return false;
                }

            }
            return true;
        }

        public bool ProveraIzmene(DateTime pocetak, DateTime kraj, int VoziloId, int id)
        {
            Cenovnik c = ModelContainer.Cenovniks.Where(x => x.Id == id).FirstOrDefault();
            foreach (var item in ModelContainer.Cenovniks.Where(x => x.VoziloId == VoziloId))
            {
                if (item != c)
                {
                    if ((item.DatumPocetka <= pocetak && item.DatumKraja >= kraj) || item.DatumPocetka >= pocetak && item.DatumKraja <= kraj)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public bool ProveraBrisanja(int id)
        {
            Cenovnik c1 = ModelContainer.Cenovniks.Where(c => c.Id.Equals(id)).FirstOrDefault();

            if (c1.Rezervacijas.Count > 0)
                return false;

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
