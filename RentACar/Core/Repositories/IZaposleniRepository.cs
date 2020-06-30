using System.Collections.Generic;

namespace RentACar.DAO
{
    public interface IZaposleniRepository : IRepository<Zaposleni>
    {
        Zaposleni GetZaposleniByJmbg(string jmbg);
        void RemoveByJmbg(string jmbg);

        List<Zaposleni> GetZaposleniUFilijali(int filijalaId);
    }
}
