using RentACar;
using RentACarWPF.Helpers;
using System;

namespace RentACarWPF.Models
{
    public class AppRezervacija : ValidationBase
    {
        public int Id { get; set; }
        public DateTime Datum_preuzimanja { get; set; }
        public DateTime Datum_vracanja { get; set; }

        public AppRezervacija()
        {
            Id = 0;
            Datum_preuzimanja = DateTime.Now;
            Datum_vracanja = DateTime.Now;
        }

        public AppRezervacija(Rezervacija r)
        {
            Id = r.Id;
            Datum_preuzimanja = r.Datum_preuzimanja;
            Datum_vracanja = r.Datum_vracanja;
        }

        protected override void ValidateSelf()
        {
            if (Id < 0)
            {
                ValidationErrors["Id"] = "Id ne moze biti manji od 0";
            }

            if (Datum_preuzimanja.Date < DateTime.Now.Date)
            {
                ValidationErrors["DatumPreuzimanja"] = "Datum preuzimanja ne moze biti u proslosti";
            }

            if (Datum_vracanja.Date < DateTime.Now.Date)
            {
                ValidationErrors["DatumVracanja"] = "Datum vracanja ne moze biti u proslosti";
            }

            if (Datum_vracanja.Date < Datum_preuzimanja.Date)
            {
                ValidationErrors["DatumVracanja"] = "Datum vracanja ne moze manji od datuma preuzimanja!";
            }
        }
    }
}
