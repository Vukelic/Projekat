using RentACar.Core.Repositories;
using RentACar.DAO;

namespace RentACar.Persistence.Repositories
{
    public class OsiguranjeRepository : Repository<Osiguranje>, IOsiguranjeRepository
    {
        public OsiguranjeRepository(ModelContainer context) : base(context) { }
    }
}
