using RentACar.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Repositories
{
    public interface ICenovnikRepository : IRepository<Cenovnik>
    {
        bool ProveraRezervacije(DateTime pocetak, DateTime kraj, int voziloId);
        bool ProveraBrisanja(int id);
        bool ProveraIzmene(DateTime pocetak, DateTime kraj, int VoziloId, int id);
        int IzracunajCenu(DateTime DatumKraja, DateTime DatumPocetka, int CenaPoDanu);
    }
}
