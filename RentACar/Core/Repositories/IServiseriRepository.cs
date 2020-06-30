namespace RentACar.DAO
{
    public interface IServiseriRepository : IRepository<Serviser>
    {
        Serviser GetServiserByJmbg(string jmbg);
        void RemoveByJmbg(string jmbg);
    }
}
