using RentACar;
using RentACarWPF.Helpers;
using System;

namespace RentACarWPF.Models
{
    public class AppFilijala : ValidationBase
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }

        public AppFilijala()
        {
            Id = 0;
            Naziv = "";
            BrojTelefona = "";
            Adresa = "";
        }

        public AppFilijala(Filijala f)
        {
            Id = f.Id;
            Naziv = f.Naziv;
            BrojTelefona = f.BrojTelefona;
            Adresa = f.Adresa;
        }

        protected override void ValidateSelf()
        {
            if (Id < 0)
            {
                ValidationErrors["Id"] = "Id ne moze biti manji od 0";
            }

            if (string.IsNullOrWhiteSpace(Naziv))
            {
                ValidationErrors["Naziv"] = "Naziv ne moze biti prazan.";
            }

            if (string.IsNullOrWhiteSpace(BrojTelefona))
            {
                ValidationErrors["BrojTelefona"] = "BrojTelefona ne moze biti prazan.";
            }

            if (string.IsNullOrWhiteSpace(Adresa))
            {
                ValidationErrors["Adresa"] = "Adresa ne moze biti prazna.";
            }


            if (Naziv.Length < 3 && Naziv.Length > 0)
            {

                ValidationErrors["Naziv"] = "Mora biti duzine min 3 cifre";
            }

            if (Adresa.Length < 10 && Adresa.Length > 0)
            {

                ValidationErrors["Adresa"] = "Mora biti duzine min 10 cifara";
            }

            if (BrojTelefona.Length < 5 && BrojTelefona.Length > 0)
            {

                ValidationErrors["BrojTelefona"] = "Mora biti duzine min 6 cifara";
            }


            if (Adresa.Length > 30)
            {

                ValidationErrors["Adresa"] = "Mora biti duzine max 30 cifara";
            }

            if (Naziv.Length > 20)
            {

                ValidationErrors["Naziv"] = "Mora biti duzine max 20 cifara";
            }

            if (BrojTelefona.Length > 12)
            {

                ValidationErrors["BrojTelefona"] = "Mora biti duzine max 12 cifara";
            }
        }
    }
}
