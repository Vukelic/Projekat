using RentACar;
using RentACarWPF.Helpers;
using System;

namespace RentACarWPF.Models
{
    public class AppServis : ValidationBase
    {
        public int Id { get; set; }
        public int Cena { get; set; }
        public string Komentar { get; set; }

        public AppServis()
        {
            Id = 0;
            Cena = 0;
            Komentar = "";
        }

        public AppServis(Servis s)
        {
            Id = s.Id;
            Cena = s.Cena;
            Komentar = s.Komentar;
        }

        protected override void ValidateSelf()
        {
            if (Id < 0)
            {
                ValidationErrors["Id"] = "Id ne moze biti manji od 0";
            }

            if (Cena < 0)
            {
                ValidationErrors["Cena"] = "Cena ne moza biti manja od 0";
            }

            else if (Cena > 100000)
            {
                ValidationErrors["Cena"] = "Cena ne moza biti veca od 100000";
            }

            if (string.IsNullOrWhiteSpace(Komentar))
            {
                ValidationErrors["Komentar"] = "Komentar ne moze biti prazan.";
            }

            else if (Komentar.Length > 50)
            {
                ValidationErrors["Komentar"] = "Komentar ne moze duzi od 50 karaktera.";
            }
        }
    }
}
