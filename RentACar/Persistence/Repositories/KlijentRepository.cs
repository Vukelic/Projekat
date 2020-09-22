using System.Data.Entity;
using System.Linq;

namespace RentACar.DAO
{
    public class KlijentRepository : Repository<Klijent>, IKlijentRepository
    {
        public KlijentRepository(ModelContainer context) : base(context) { }

        public Klijent GetKlijentByJmbg(string jmbg)
        {
            return ModelContainer.Klijenti.Where(x => x.Jmbg == jmbg).FirstOrDefault();
        }

        public bool ProveraJmbg(string jmbg)
        {
            using (var db = new ModelContainer())
            {
                Klijent k = db.Klijenti.Where(kor => kor.Jmbg == jmbg).FirstOrDefault();

                if (k != null)
                {
                    return true;
                }

                if (jmbg == null)
                {
                    return true;
                }

                return false;
            }
        }

        public void RemoveByJmbg(string jmbg)
        {
            Klijent entityToDelete = _context.Set<Klijent>().Find(jmbg);
            _context.Entry(entityToDelete).State = EntityState.Deleted;
        }

        public bool Login(string korisnickoIme, string sifra)
        {
            using (var db = new ModelContainer())
            {
                Klijent k = db.Klijenti.Where(kor => kor.KorisnickoIme == korisnickoIme).FirstOrDefault();

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

        public bool ProveraKorisnickogImena(string korisnickoIme)
        {
            using (var db = new ModelContainer())
            {
                Klijent k = db.Klijenti.Where(kor => kor.KorisnickoIme == korisnickoIme).FirstOrDefault();

                if (k != null)
                {
                    return true;
                }

                if (korisnickoIme == null)
                {
                    return true;
                }

                return false;
            }
        }

        public Klijent ProveraPoImenu(string korisnickoIme)
        {
            using (var db = new ModelContainer())
            {
                Klijent k = db.Klijenti.Where(kor => kor.KorisnickoIme == korisnickoIme).FirstOrDefault();

                if (k == null)
                {
                    return null;
                }

                return k;
            }
        }

        public ModelContainer ModelContainer
        {
            get { return _context as ModelContainer; }
        }
    }
}
