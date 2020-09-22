using RentACar;
using RentACarWPF.Helpers;

namespace RentACarWPF.Models
{
    public class AppKlijent : ValidationBase
    {
        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }


        public AppKlijent(Klijent k)
        {
            Jmbg = k.Jmbg;
            Ime = k.Ime;
            Prezime = k.Prezime;
            KorisnickoIme = k.KorisnickoIme;
            Lozinka = k.Lozinka;
        }

        public AppKlijent()
        {
            Jmbg = "";
            Ime = "";
            Prezime = "";
            KorisnickoIme = "";
            Lozinka = "";
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(Jmbg))
            {
                ValidationErrors["Jmbg"] = "Jmbg ne moze biti prazan.";
            }

            if (string.IsNullOrWhiteSpace(Ime))
            {
                ValidationErrors["Ime"] = "Ime ne moze biti prazno";
            }

            if (string.IsNullOrWhiteSpace(Prezime))
            {
                ValidationErrors["Prezime"] = "Prezime ne moze biti prazno.";
            }
            if (string.IsNullOrWhiteSpace(KorisnickoIme))
            {
                ValidationErrors["KorisnickoIme"] = "KorisnickoIme ne moze biti prazno.";
            }
           
            
            if (Jmbg.Length != 13)
            {

                ValidationErrors["Jmbg"] = "Jmbg mora biti duzine tacno 13 cifara";
            }

            if (Ime.Length < 2 && Ime.Length > 0)
            {

                ValidationErrors["Ime"] = "Ime mora biti duzine min 2 cifre";
            }

            if (Prezime.Length < 3 && Prezime.Length > 0)
            {

                ValidationErrors["Prezime"] = "Prezime mora biti duzine min 3 cifre";
            }

            if (KorisnickoIme.Length < 3 && KorisnickoIme.Length > 0)
            {

                ValidationErrors["KorisnickoIme"] = "KorisnickoIme mora biti duzine min 3 cifre";
            }

            if (Lozinka.Length < 3 && Lozinka.Length > 0)
            {

                ValidationErrors["Lozinka"] = "Lozinka mora biti duzine min 3 cifre";
            }          

            if (Ime.Length > 20)
            {

                ValidationErrors["Ime"] = "Ime mora biti duzine max 20 cifara";
            }

            if (Prezime.Length > 20)
            {

                ValidationErrors["Prezime"] = "Prezime mora biti duzine max 20 cifara";
            }

        }
    }
}
