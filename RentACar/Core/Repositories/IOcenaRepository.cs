using RentACar.DAO;
using System.Collections.Generic;

namespace RentACar.Core.Repositories
{
    public interface IOcenaRepository : IRepository<Ocena>
    {
        List<Ocena> OceneOdKlijenta(string jmbg);
        List<Ocena> OceneZaVozilo(int id);
    }
}
