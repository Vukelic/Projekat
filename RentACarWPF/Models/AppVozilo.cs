using RentACar;
using RentACarWPF.Helpers;

namespace RentACarWPF.Models
{
    public class AppVozilo : ValidationBase
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Marka { get; set; }

        public AppVozilo(Vozilo v)
        {
            Id = v.Id;
            Model = v.Model;
            Marka = v.Marka;
        }

        public AppVozilo()
        {
            Id = 0;
            Model = "";
            Marka = "";
        }

        protected override void ValidateSelf()
        {
            if (Id < 0)
            {
                ValidationErrors["Id"] = "Id ne moze biti manji od 0";
            }

            if (string.IsNullOrWhiteSpace(Model))
            {
                ValidationErrors["Model"] = "Model ne moze biti prazan.";
            }

            if (string.IsNullOrWhiteSpace(Marka))
            {
                ValidationErrors["Marka"] = "Marka ne moze biti prazna.";
            }

            if (Model.Length < 3 && Model.Length > 0)
            {

                ValidationErrors["Model"] = "Mora biti duzine min 3 cifre";
            }

            if (Marka.Length < 3 && Marka.Length > 0)
            {

                ValidationErrors["Marka"] = "Mora biti duzine min 3 cifre";
            }

            if (Marka.Length > 20)
            {

                ValidationErrors["Marka"] = "Mora biti duzine max 20 cifara";
            }

            if (Model.Length > 20)
            {

                ValidationErrors["Model"] = "Mora biti duzine max 20 cifara";
            }



        }
    }
}
