using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class DodajIzmeniServiseraViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        AppServiser s = new AppServiser();
        public AppServiser S
        {
            get { return s; }
            set
            {
                s = value;
                OnPropertyChanged("S");
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

        string filijalaError;
        public string FilijalaError
        {
            get { return filijalaError; }
            set
            {
                filijalaError = value;
                OnPropertyChanged("FilijalaError");
            }
        }

        string tipError;
        public string TipError
        {
            get { return tipError; }
            set
            {
                tipError = value;
                OnPropertyChanged("TipError");
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
        Filijala selektovanaFilijala;
        public Filijala SelektovanaFilijala
        {
            get { return selektovanaFilijala; }
            set
            {
                selektovanaFilijala = value;
                OnPropertyChanged("SelektovanaFilijala");
            }
        }

        List<Filijala> filijaleLista = new List<Filijala>();
        BindingList<Filijala> filijale = new BindingList<Filijala>();

        public BindingList<Filijala> Filijale
        {
            get { return filijale; }
            set
            {
                filijale = value;
                OnPropertyChanged("Filijale");
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

        public MyICommand DodajIzmeniServiseraCommand { get; set; }

        public DodajIzmeniServiseraViewModel(Serviser serviser = null)
        {
            filijaleLista = unitOfWork.Filijale.GetAll();
            Filijale = new BindingList<Filijala>();

            Tipovi.Add("Elektronika");
            Tipovi.Add("Mehanika");
            Tipovi.Add("Limarija");

            foreach (var filijala in filijaleLista)
            {
                Filijale.Add(filijala);
            }

            if (serviser == null)
            {
                TextBoxEnabled = true;
                TitleContent = "Dodaj servisera";
                ButtonContent = "Dodaj";
                DodajIzmeniServiseraCommand = new MyICommand(onDodajServisera);
            }
            else
            {
                TextBoxEnabled = false;
                s = new AppServiser(serviser);
                TitleContent = "Izmeni servisera";
                ButtonContent = "Izmeni";
                SelektovanaFilijala = unitOfWork.Filijale.Get(serviser.FilijalaId);
                if(serviser.Tip_Struke == TipStruke.Elektronika)
                {
                    SelektovanTip = "Elektronika";
                }
                else if(serviser.Tip_Struke == TipStruke.Limarija)
                {
                    SelektovanTip = "Limarija";
                }
                else
                {
                    SelektovanTip = "Mehanika";
                }

                DodajIzmeniServiseraCommand = new MyICommand(onIzmeniServisera);
            }
        }

        public void onDodajServisera(object parameter)
        {
            bool error = false;

            S.Validate();

            if (SelektovanaFilijala == null)
            {
                FilijalaError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                FilijalaError = "";
            }

            if (SelektovanTip == null)
            {
                TipError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                TipError = "";
            }

            Zaposleni zaposleniIzBaze = unitOfWork.Zaposleni.GetZaposleniByJmbg(S.Jmbg);

            if (zaposleniIzBaze == null)
            {
                IdPostoji = "";
                if (!error && S.IsValid)
                {
                    Serviser serviser = new Serviser();
                    serviser.Ime = S.Ime;
                    serviser.Prezime = S.Prezime;
                    serviser.Broj_ugovora = S.Broj_ugovora;
                    serviser.Broj_licence = S.Broj_licence;
                    serviser.FilijalaId = SelektovanaFilijala.Id;
                    serviser.Jmbg = S.Jmbg;
                    if (SelektovanTip.ToLower() == "elektronika")
                    {
                        serviser.Tip_Struke = TipStruke.Elektronika;
                    }
                    else if (SelektovanTip.ToLower() == "mehanika")
                    {
                        serviser.Tip_Struke = TipStruke.Mehanika;
                    }
                    else
                    {
                        serviser.Tip_Struke = TipStruke.Limarija;
                    }

                    unitOfWork.Serviseri.Add(serviser);

                    if (unitOfWork.Complete() > 0)
                    {
                        Uspesno = "Uspesno ste dodali servisera u bazu!";
                        S = new AppServiser();
                    }
                }
            }
            else
            {
                IdPostoji = "Id je zauzet!";
            }
        }

        public void onIzmeniServisera(object parameter)
        {
            bool error = false;

            S.Validate();

            if (SelektovanaFilijala == null)
            {
                FilijalaError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                FilijalaError = "";
            }

            if (SelektovanTip == null)
            {
                TipError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                TipError = "";
            }

            if (!error && S.IsValid)
            {
                Serviser serviser = unitOfWork.Serviseri.GetServiserByJmbg(S.Jmbg);
                serviser.Ime = S.Ime;
                serviser.Prezime = S.Prezime;
                serviser.Broj_ugovora = S.Broj_ugovora;
                serviser.Broj_licence = S.Broj_licence;
                serviser.FilijalaId = SelektovanaFilijala.Id;
                if (SelektovanTip.ToLower() == "elektronika")
                {
                    serviser.Tip_Struke = TipStruke.Elektronika;
                }
                else if (SelektovanTip.ToLower() == "mehanika")
                {
                    serviser.Tip_Struke = TipStruke.Mehanika;
                }
                else
                {
                    serviser.Tip_Struke = TipStruke.Limarija;
                }

                unitOfWork.Serviseri.Update(serviser);

                if (unitOfWork.Complete() > 0)
                {
                    Uspesno = "Uspesno ste izmenili servisera!";
                }

            }
        }
    }
}
