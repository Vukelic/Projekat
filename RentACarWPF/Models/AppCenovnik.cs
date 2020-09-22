using RentACar;
using RentACarWPF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarWPF.Models
{
    public class AppCenovnik : ValidationBase
    {
        public int Id { get; set; }
        public System.DateTime DatumPocetka { get; set; }
        public System.DateTime DatumKraja { get; set; }
        public int CenaPoDanu { get; set; }
        public int VoziloId { get; set; }
        public int UkupnaCena { get; set; }
        public bool Rezervisano { get; set; }

        public AppCenovnik(Cenovnik c)
        {
            Id = c.Id;
            DatumPocetka = c.DatumPocetka;
            DatumKraja = c.DatumKraja;
            CenaPoDanu = c.CenaPoDanu;
            UkupnaCena = c.UkupnaCena;
            VoziloId = c.Id;

        }

        public AppCenovnik()
        {
            Id = 0;
            DatumPocetka = DateTime.Now;
            DatumKraja = DateTime.Now;
            CenaPoDanu = 0;
            UkupnaCena = 0;
            VoziloId = 0;
        }
        protected override void ValidateSelf()
        {
            if (Id < 0)
            {
                ValidationErrors["Id"] = "Id ne moze biti manji od 0";
            }

            if (DatumPocetka < DateTime.Now)
            {
                ValidationErrors["DatumPocetka"] = "Datum preuzimanja ne moze biti u proslosti";
            }

            if (DatumKraja < DateTime.Now)
            {
                ValidationErrors["DatumKraja"] = "Datum vracanja ne moze biti u proslosti";
            }

            if (DatumKraja < DatumPocetka)
            {
                ValidationErrors["DatumVracanja"] = "Datum vracanja ne moze manji od datuma preuzimanja!";
            }
            if (CenaPoDanu < 0)
            {
                ValidationErrors["CenaPoDanu"] = "CenaPoDanu ne moze biti manja od 0";
            }
        }

       
    }
}
