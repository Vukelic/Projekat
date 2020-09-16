using RentACar.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Repositories
{
    public interface IKorisnikRepository : IRepository<Korisnik>
    {
        bool Login(string korisnickoIme, string sifra);

        bool ProveraKorisnickogImena(string korisnickoIme);
        Korisnik ProveraPoImenu(string korisnickoIme);
    }
}
