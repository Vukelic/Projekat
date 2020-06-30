using RentACar;

namespace RentACarWPF.Models
{
    public class AppZaposleni
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Broj_ugovora { get; set; }
        public string Jmbg { get; set; }
        public string Uloga { get; set; }

        public AppZaposleni(Agent a)
        {
            Ime = a.Ime;
            Prezime = a.Prezime;
            Broj_ugovora = a.Broj_ugovora;
            Jmbg = a.Jmbg;
        }

        public AppZaposleni(Serviser a)
        {
            Ime = a.Ime;
            Prezime = a.Prezime;
            Broj_ugovora = a.Broj_ugovora;
            Jmbg = a.Jmbg;

        }
    }
}
