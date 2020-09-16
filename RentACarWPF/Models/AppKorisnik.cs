using RentACarWPF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarWPF.Models
{
    public class AppKorisnik : ValidationBase
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public AppKorisnik(AppKorisnik k)
        {
            Id = k.Id;
            KorisnickoIme = k.KorisnickoIme;
            Lozinka = k.Lozinka;
        }

        public AppKorisnik()
        {
            Id = 0;
            KorisnickoIme = "";
            Lozinka = "";
        }

        protected override void ValidateSelf()
        {
            if (Id < 0)
            {
                ValidationErrors["Id"] = "Id ne moze biti manji od 0";
            }

            if (string.IsNullOrWhiteSpace(KorisnickoIme))
            {
                ValidationErrors["KorisnickoIme"] = "KorisnickoIme ne moze biti prazno.";
            }

            if (string.IsNullOrWhiteSpace(Lozinka))
            {
                ValidationErrors["Lozinka"] = "Lozinka ne moze biti prazna.";
            }

            if (Lozinka.Length > 5)
            {

                ValidationErrors["Lozinka"] = "Mora biti duzine min 5 cifara";
            }
        }
    }
}
