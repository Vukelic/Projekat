using RentACar.DAO;
using System.Collections.Generic;

namespace RentACar.Core.Repositories
{
    public interface IVoziloRepository : IRepository<Vozilo>
    {
        List<Vozilo> GetVozilaZaFilijalu(int filijalaId);
    }
}
