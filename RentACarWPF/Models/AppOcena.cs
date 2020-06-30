using RentACar;
using RentACarWPF.Helpers;

namespace RentACarWPF.Models
{
    public class AppOcena : ValidationBase
    {
        public int Id { get; set; }
        public int Vrednost { get; set; }

        public AppOcena()
        {
            Id = 0;
            Vrednost = 0;
        }

        public AppOcena(Ocena  o)
        {
            Id = o.Id;
            Vrednost = o.Vrednost;
        }

        protected override void ValidateSelf()
        {
            if(Vrednost < 1 || Vrednost > 10)
            {
                ValidationErrors["Vrednost"] = "Ocena mora biti izmedju 1 i 10!";
            }

            if (Id < 0)
            {
                ValidationErrors["Id"] = "Id ne moze biti manji od 0";
            }

        }
    }
}
