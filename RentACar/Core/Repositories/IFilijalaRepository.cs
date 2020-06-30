using System.Collections.Generic;

namespace RentACar.DAO
{
   public interface IFilijalaRepository : IRepository<Filijala>
   {
        List<Filijala> GetFilijaleZaGrad(int postanskiBroj);
   }
}
