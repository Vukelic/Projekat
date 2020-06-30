using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
using RentACarWPF.Models.Enums;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class DodajIzmeniOsiguranjeViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        AppOsiguranje o = new AppOsiguranje();

        public AppOsiguranje O
        {
            get { return o; }
            set
            {
                o = value;
                OnPropertyChanged("O");
            }
        }

        bool textBoxEnabled;

        public bool TextBoxEnabled
        {
            get { return textBoxEnabled; }
            set
            {
                textBoxEnabled = value;
                OnPropertyChanged("TextBoxEnabled");

            }
        }

        string uspesno;
        public string Uspesno
        {
            get { return uspesno; }
            set
            {
                uspesno = value;
                OnPropertyChanged("Uspesno");
            }
        }

        string idPostoji;
        public string IdPostoji
        {
            get { return idPostoji; }
            set
            {
                idPostoji = value;
                OnPropertyChanged("IdPostoji");
            }
        }

        string titleContent;
        public string TitleContent
        {
            get { return titleContent; }
            set
            {
                titleContent = value;
                OnPropertyChanged("TitleContent");
            }
        }

        string buttonContent;
        public string ButtonContent
        {
            get { return buttonContent; }


            set
            {
                buttonContent = value;
                OnPropertyChanged("ButtonContent");
            }
        }

        string vrstaError;
        public string VrstaError
        {
            get { return vrstaError; }
            set
            {
                vrstaError = value;
                OnPropertyChanged("VrstaError");
            }
        }

        BindingList<string> tipovi = new BindingList<string>();

        public BindingList<string> Tipovi
        {
            get { return tipovi; }
            set
            {
                tipovi = value;
                OnPropertyChanged("Tipovi");
            }
        }

        string selektovanTip;
        public string SelektovanTip
        {
            get { return selektovanTip; }
            set
            {
                selektovanTip = value;
                OnPropertyChanged("SelektovanTip");
            }
        }

        public MyICommand DodajIzmeniOsiguranjeCommand { get; set; }

        public DodajIzmeniOsiguranjeViewModel(Osiguranje osiguranje = null)
        {
            Tipovi.Add("Economy");
            Tipovi.Add("Standard");
            Tipovi.Add("Premium");

            if (osiguranje == null)
            {
                TextBoxEnabled = true;
                TitleContent = "Dodaj osiguranje";
                ButtonContent = "Dodaj";
                DodajIzmeniOsiguranjeCommand = new MyICommand(onDodajOsiguranje);
            }
            else
            {
                TextBoxEnabled = false;
                o = new AppOsiguranje(osiguranje);
                TitleContent = "Izmeni osiguranje";
                
                if(osiguranje.Tip_osiguranja == RentACar.TipOsiguranja.premium)
                {
                    SelektovanTip = "Premium";
                }
                else if (osiguranje.Tip_osiguranja == RentACar.TipOsiguranja.standard)
                {
                    SelektovanTip = "Standard";
                }
                else
                {
                    SelektovanTip = "Economy";
                }

                ButtonContent = "Izmeni";
                DodajIzmeniOsiguranjeCommand = new MyICommand(onIzmeniOsiguranje);
            }
        }

        public void onDodajOsiguranje(object parameter)
        {
            O.Validate();
            bool error = false;

            if (SelektovanTip == null)
            {
                VrstaError = "Morate izabrati tip!";
                error = true;
            }
            else
            {
                VrstaError = "";
            }

            Osiguranje osiguranjeIzBaze = unitOfWork.Osiguranja.Get(O.Id);

            if(osiguranjeIzBaze == null)
            {
                IdPostoji = "";
                if (!error && O.IsValid)
                {
                    Osiguranje osiguranje = new Osiguranje();
                    osiguranje.Id = O.Id;
                    osiguranje.Broj_polise = O.Broj_polise;
                    if(SelektovanTip.ToLower() == "premium")
                    {
                        osiguranje.Tip_osiguranja = RentACar.TipOsiguranja.premium;
                    }
                    else if(SelektovanTip.ToLower() == "standard")
                    {
                        osiguranje.Tip_osiguranja = RentACar.TipOsiguranja.standard;
                    }
                    else
                    {
                        osiguranje.Tip_osiguranja = RentACar.TipOsiguranja.economy;
                    }
                    unitOfWork.Osiguranja.Add(osiguranje);

                    if (unitOfWork.Complete() > 0)
                    {
                        Uspesno = "Uspesno ste dodali osiguranje u bazu!";
                        O = new AppOsiguranje();
                    }
                }
            }
            else
            {
                IdPostoji = "Id zauzet!";
                Uspesno = "";
            }
        }

        public void onIzmeniOsiguranje(object parameter)
        {
            bool error = false;

            O.Validate();

            if (SelektovanTip == null)
            {
                VrstaError = "Morate izabrati tip!";
                error = true;
            }
            else
            {
                VrstaError = "";
            }


            if (!error && O.IsValid)
            {
                Osiguranje osiguranje = unitOfWork.Osiguranja.Get(O.Id);
                osiguranje.Broj_polise = O.Broj_polise;

                if (SelektovanTip == "premium")
                {
                    osiguranje.Tip_osiguranja = RentACar.TipOsiguranja.premium;
                }
                else if (SelektovanTip == "standard")
                {
                    osiguranje.Tip_osiguranja = RentACar.TipOsiguranja.standard;
                }
                else
                {
                    osiguranje.Tip_osiguranja = RentACar.TipOsiguranja.economy;
                }

                unitOfWork.Osiguranja.Update(osiguranje);

                if (unitOfWork.Complete() > 0)
                {
                    Uspesno = "Uspesno ste izmenili osiguranje";
                    IdPostoji = "";
                }
            }
        }
    }
}
