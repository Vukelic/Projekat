namespace RentACar.DAO
{
    public interface IKlijentRepository : IRepository<Klijent>
    {
        Klijent GetKlijentByJmbg(string jmbg);
        void RemoveByJmbg(string jmbg);

        bool Login(string korisnickoIme, string sifra);

        bool ProveraKorisnickogImena(string korisnickoIme);
        bool ProveraJmbg(string jmbg);
        Klijent ProveraPoImenu(string korisnickoIme);
    }
}
