using RentACar;
using RentACarWPF.Helpers;

namespace RentACarWPF.Models
{
    public class AppGrad : ValidationBase
    {
        public int PostanskiBroj { get; set; }
        public string Drzava { get; set; }
        public string Naziv { get; set; }

        public AppGrad()
        {
            PostanskiBroj = 0;
            Drzava = "";
            Naziv = "";
        }

        public AppGrad(Grad g)
        {
            PostanskiBroj = g.PostanskiBroj;
            Drzava = g.Drzava;
            Naziv = g.Naziv;
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.Drzava))
            {
                ValidationErrors["Drzava"] = "Drzava ne moze biti prazna.";
            }

            if (string.IsNullOrWhiteSpace(this.Naziv))
            {
                ValidationErrors["Naziv"] = "Naziv ne moze biti prazan.";
            }

            if(PostanskiBroj == 0)
            {
                ValidationErrors["PostanskiBroj"] = "PostanskiBroj ne moze biti prazan";
            }


            if (Drzava.Length < 4 && Drzava.Length > 0)
            {

                ValidationErrors["Drzava"] = " Drzava mora biti duzine min 4 cifara";
            }

            if (Naziv.Length < 3 && Naziv.Length > 0)
            {

                ValidationErrors["Naziv"] = "Naziv mora biti duzine min 3 cifre";
            }


            if (Drzava.Length > 30)
            {

                ValidationErrors["Drzava"] = "Mora biti duzine max 30 cifara";
            }

            if (Naziv.Length > 20)
            {

                ValidationErrors["Naziv"] = "Mora biti duzine max 20 cifara";
            }
            if (PostanskiBroj > 100000)
            {
                ValidationErrors["PostanskiBroj"] = "PostanskiBroj nije validan";
            }

        }
    }
}
