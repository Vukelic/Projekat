namespace RentACar.DAO
{
    public interface IKlijentRepository : IRepository<Klijent>
    {
        Klijent GetKlijentByJmbg(string jmbg);
        void RemoveByJmbg(string jmbg);
    }
}
