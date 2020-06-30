using System.Data.Entity;
using System.Linq;

namespace RentACar.DAO
{
    public class GradRepository : Repository<Grad>, IGradRepository
    {

        public GradRepository (ModelContainer context) : base(context) { }

        public Grad GetGradByPostanskiBroj(int postanskiBroj)
        {
            return ModelContainer.Gradovi.Where(x => x.PostanskiBroj == postanskiBroj).FirstOrDefault();
        }

        public void RemoveByPostanskiBroj(int postanskiBroj)
        {
            Grad entityToDelete = _context.Set<Grad>().Find(postanskiBroj);
            _context.Entry(entityToDelete).State = EntityState.Deleted;
        }

        public ModelContainer ModelContainer
        {
            get { return _context as ModelContainer; }
        }
    }
}
