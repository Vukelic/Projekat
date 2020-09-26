using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class DodajIzmeniVoziloViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        AppVozilo v = new AppVozilo();

        public AppVozilo V
        {
            get { return v; }
            set
            {
                v = value;
                OnPropertyChanged("V");
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

        List<Filijala> filijalaLista = new List<Filijala>();

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

        public MyICommand DodajIzmeniVoziloCommand { get; set; }

        public DodajIzmeniVoziloViewModel(Vozilo vozilo = null)
        {
            Tipovi.Add("Automobil");
            Tipovi.Add("Motor");
            Tipovi.Add("Autobus");

            filijalaLista = unitOfWork.Filijale.GetAll();
            Filijale = new BindingList<Filijala>();

            foreach (var filijala in filijalaLista)
            {
                Filijale.Add(filijala);
            }

            if (vozilo == null)
            {
                TextBoxEnabled = true;
                TitleContent = "Dodaj vozilo";
                ButtonContent = "Dodaj";
                DodajIzmeniVoziloCommand = new MyICommand(onDodajVozilo);
            }
            else
            {
                TextBoxEnabled = false;
                v = new AppVozilo(vozilo);
                TitleContent = "Izmeni vozilo";
                ButtonContent = "Izmeni";
                SelektovanaFilijala = unitOfWork.Filijale.Get(vozilo.FilijalaId);
                if (vozilo.Tip_vozila == TipVozila.Automobil)
                {
                    SelektovanTip = "Automobil";
                }
                else if (vozilo.Tip_vozila == TipVozila.Motor)
                {
                    SelektovanTip = "Motor";
                }
                else
                {
                    SelektovanTip = "Autobus";
                }
                
                DodajIzmeniVoziloCommand = new MyICommand(onIzmeniVozilo);
            }
        }

        public void onDodajVozilo(object parameter)
        {
            bool error = false;

            V.Validate();
            if (SelektovanTip == null)
            {
                TipError = "Morate izabrati tip!";
                error = true;
            }
            else
            {
                TipError = "";
            }

            if (SelektovanaFilijala == null)
            {
                FilijalaError = "Morate izabrati filijalu!";
                error = true;
            }
            else
            {
                FilijalaError = "";
            }

            Vozilo voziloIzBaze = unitOfWork.Vozila.Get(V.Id);

            if(voziloIzBaze == null)
            {
                IdPostoji = "";
                if (!error && V.IsValid)
                {
                    Vozilo vozilo = new Vozilo();
                    vozilo.Id = V.Id;
                    vozilo.Marka = V.Marka;
                    vozilo.Model = V.Model;
                    vozilo.FilijalaId = SelektovanaFilijala.Id;
                    vozilo.ProsecnaOcena = "0";

                    if(SelektovanTip.ToLower() == "automobil")
                    {
                        vozilo.Tip_vozila = TipVozila.Automobil;
                    }
                    else if (SelektovanTip.ToLower() == "motor")
                    {
                        vozilo.Tip_vozila = TipVozila.Motor;
                    }
                    else
                    {
                        vozilo.Tip_vozila = TipVozila.Autobus;
                    }

                    

                    unitOfWork.Vozila.Add(vozilo);

                    if (unitOfWork.Complete() > 0)
                    {
                        Uspesno = "Uspesno ste dodali vozilo u bazu!";
                        V = new AppVozilo();
                    }
                }

            }
            else
            {
                IdPostoji = "Id je zauzet!";
                Uspesno = "";
            }

        }

        public void onIzmeniVozilo(object parameter)
        {
            bool error = false;

            V.Validate();
            if (SelektovanTip == null)
            {
                TipError = "Morate izabrati tip!";
                error = true;
            }
            else
            {
                TipError = "";
            }

            if (SelektovanaFilijala == null)
            {
                FilijalaError = "Morate izabrati filijalu!";
                error = true;
            }
            else
            {
                FilijalaError = "";
            }

            if (!error && V.IsValid)
            {
                Vozilo vozilo = unitOfWork.Vozila.Get(V.Id);
                vozilo.Marka = V.Marka;
                vozilo.Model = V.Model;
                vozilo.FilijalaId = SelektovanaFilijala.Id;

                if (SelektovanTip.ToLower() == "automobil")
                {
                    vozilo.Tip_vozila = TipVozila.Automobil;
                }
                else if (SelektovanTip.ToLower() == "motor")
                {
                    vozilo.Tip_vozila = TipVozila.Motor;
                }
                else
                {
                    vozilo.Tip_vozila = TipVozila.Autobus;
                }

                unitOfWork.Vozila.Update(vozilo);

                if (unitOfWork.Complete() > 0)
                {
                    Uspesno = "Uspesno ste izmenili vozilo!";
                    IdPostoji = "";
                }
            }
        }
    }
}
