using RentACar.DAO;
using System.Collections.Generic;

namespace RentACar.Core.Repositories
{
    public interface IServisRepository : IRepository<Servis>
    {
        List<Servis> GetServisiOdServisera(string jmbg);
        List<Servis> GetServisiZaVozilo(int id);
    }
}
