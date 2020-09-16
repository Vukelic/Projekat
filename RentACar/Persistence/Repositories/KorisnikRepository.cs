using RentACar.Core.Repositories;
using RentACar.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories
{
    public class KorisnikRepository : Repository<Korisnik>, IKorisnikRepository
    {
        public KorisnikRepository(ModelContainer context) : base(context) { }

        public bool Login(string ime, string sifra)
        {
            using (var db = new ModelContainer())
            {
                Korisnik k = db.Korisniks.Where(kor => kor.KorisnickoIme == ime).FirstOrDefault();

                if (k == null)
                {
                    return false;
                }

                if (k.Lozinka != sifra)
                {
                    return false;
                }

                return true;
            }
        }

        public Korisnik ProveraPoImenu(string korisnickoIme)
        {
            using (var db = new ModelContainer())
            {
                Korisnik k = db.Korisniks.Where(kor => kor.KorisnickoIme == korisnickoIme).FirstOrDefault();

                if (k == null)
                {
                    return null;
                }

                return k;
            }
        }

        

        public bool ProveraKorisnickogImena(string korisnickoIme)
        {
            using (var db = new ModelContainer())
            {
                Korisnik k = db.Korisniks.Where(kor => kor.KorisnickoIme == korisnickoIme).FirstOrDefault();

                if (k != null)
                {
                    return true;
                }

                if(korisnickoIme == null)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
