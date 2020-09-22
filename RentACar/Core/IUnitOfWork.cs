using RentACar.Core.Repositories;
using System;

namespace RentACar.DAO
{
    public interface IUnitOfWork : IDisposable
    {
        IKlijentRepository Klijenti { get; }
        IGradRepository Gradovi { get; }
        IFilijalaRepository Filijale { get; }
        IZaposleniRepository Zaposleni { get; }
        IVoziloRepository Vozila { get; }
        IOcenaRepository Ocene { get; }
        IServisRepository Servisi { get; }
        IOsiguranjeRepository Osiguranja { get; }
        IRezervacijaRepository Rezervacije { get; }
        IServiseriRepository Serviseri { get; }
        IAgentiRepository Agenti { get; }
        ICenovnikRepository Cenovnici { get; }

        int Complete();
    }
}
