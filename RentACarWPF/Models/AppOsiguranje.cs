using RentACar;
using RentACarWPF.Helpers;

namespace RentACarWPF.Models
{
    public class AppOsiguranje : ValidationBase
    {
        public int Id { get; set; }
        public string Broj_polise { get; set; }

        public AppOsiguranje()
        {
            Id = 0;
            Broj_polise = "";
        }

        public AppOsiguranje(Osiguranje o)
        {
            Id = o.Id;
            Broj_polise = o.Broj_polise;
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(Broj_polise))
            {
                ValidationErrors["Broj_polise"] = "Broj_polise ne moze biti prazan.";
            }

            if(Id <= 0)
            {
                ValidationErrors["Id"] = "Id mora biti veci od 0";
            }

            if (Broj_polise.Length < 6 && Broj_polise.Length > 0)
            {

                ValidationErrors["Broj_polise"] = "Mora biti duzine min 6 cifara";
            }

            if (Broj_polise.Length > 20)
            {

                ValidationErrors["Broj_polise"] = "Mora biti duzine max 20 cifara";
            }
        }
    }
}
