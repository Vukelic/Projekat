namespace RentACar.DAO
{
    public interface IGradRepository : IRepository<Grad>
    {
        Grad GetGradByPostanskiBroj(int postanskiBroj);
        void RemoveByPostanskiBroj(int postanskiBroj);
    }
}
