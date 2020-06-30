using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class DodajIzmeniServisViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        AppServis s = new AppServis();
        public AppServis S
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

        Vozilo selektovanoVozilo;
        public Vozilo SelektovanoVozilo
        {
            get { return selektovanoVozilo; }
            set
            {
                selektovanoVozilo = value;
                OnPropertyChanged("SelektovanoVozilo");

                serviseriLista = unitOfWork.Serviseri.GetAll();
                Serviseri = new BindingList<Serviser>();

                foreach(var serviser in serviseriLista)
                {
                    Serviseri.Add(serviser);
                }

                foreach(var serviser in Serviseri.ToList())
                {
                    if(serviser.FilijalaId != value.FilijalaId)
                    {
                        Serviseri.Remove(serviser);
                    }
                }
            }
        }


        Serviser selektovaniServiser;
        public Serviser SelektovaniServiser
        {
            get { return selektovaniServiser; }
            set
            {
                selektovaniServiser = value;
                OnPropertyChanged("SelektovaniServiser");
            }
        }

        string serviserError;
        public string ServiserError
        {
            get { return serviserError; }
            set
            {
                serviserError = value;
                OnPropertyChanged("ServiserError");
            }
        }

        string voziloError;
        public string VoziloError
        {
            get { return voziloError; }
            set
            {
                voziloError = value;
                OnPropertyChanged("VoziloError");
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

        List<Vozilo> vozilaLista = new List<Vozilo>();

        BindingList<Vozilo> vozila = new BindingList<Vozilo>();

        public BindingList<Vozilo> Vozila
        {
            get { return vozila; }
            set
            {
                vozila = value;
                OnPropertyChanged("Vozila");
            }
        }


        List<Serviser> serviseriLista = new List<Serviser>();

        BindingList<Serviser> serviseri = new BindingList<Serviser>();

        public BindingList<Serviser> Serviseri
        {
            get { return serviseri; }
            set
            {
                serviseri = value;
                OnPropertyChanged("Serviseri");
            }
        }

        public MyICommand DodajIzmeniServisCommand { get; set; }

        public DodajIzmeniServisViewModel(Servis servis = null)
        {
            vozilaLista = unitOfWork.Vozila.GetAll();
            Vozila = new BindingList<Vozilo>();

            foreach (var vozilo in vozilaLista)
            {
                Vozila.Add(vozilo);
            }

            serviseriLista = unitOfWork.Serviseri.GetAll();
            Serviseri = new BindingList<Serviser>();

            foreach (var serviser in serviseriLista)
            {
                Serviseri.Add(serviser);
            }

            if (servis == null)
            {
                TextBoxEnabled = true;
                TitleContent = "Dodaj servis";
                ButtonContent = "Dodaj";
                DodajIzmeniServisCommand = new MyICommand(onDodajServis);
            }

            else
            {
                TextBoxEnabled = false;
                s = new AppServis(servis);
                TitleContent = "Izmeni servis";
                ButtonContent = "Izmeni";
                SelektovaniServiser = unitOfWork.Serviseri.GetServiserByJmbg(servis.ServiserJmbg);
                SelektovanoVozilo = unitOfWork.Vozila.Get(servis.VoziloId);
                DodajIzmeniServisCommand = new MyICommand(onIzmeniServis);
            }
        }

        public void onDodajServis(object parameter)
        {
            bool error = false;

            S.Validate();

            if (SelektovaniServiser == null)
            {
                ServiserError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                ServiserError = "";
            }

            if (SelektovanoVozilo == null)
            {
                VoziloError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                VoziloError = "";
            }

            Servis servisIzBaze = unitOfWork.Servisi.Get(S.Id);

            if(servisIzBaze == null)
            {
                IdPostoji = "";
                if (!error && S.IsValid)
                {
                    Servis servis = new Servis();
                    servis.Id = S.Id;
                    servis.Cena = S.Cena;
                    servis.Komentar = S.Komentar;
                    servis.ServiserJmbg = SelektovaniServiser.Jmbg;
                    servis.VoziloId = SelektovanoVozilo.Id;
                    servis.Datum = DateTime.Now;

                    unitOfWork.Servisi.Add(servis);

                    if (unitOfWork.Complete() > 0)
                    {
                        Uspesno = "Uspesno ste dodali servis u bazu!";
                        S = new AppServis();
                    }
                }
            }
            else
            {
                IdPostoji = "Id je zauzet!";
                Uspesno = "";
            }
        }

        public void onIzmeniServis(object parameter)
        {
            bool error = false;

            S.Validate();

            if (SelektovaniServiser == null)
            {
                ServiserError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                ServiserError = "";
            }

            if (SelektovanoVozilo == null)
            {
                VoziloError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                VoziloError = "";
            }

            if (!error && S.IsValid)
            {
                Servis servis = unitOfWork.Servisi.Get(S.Id);
                servis.Cena = S.Cena;
                servis.Komentar = S.Komentar;
                servis.Serviser = SelektovaniServiser;
                servis.VoziloId = SelektovanoVozilo.Id;
                servis.Datum = DateTime.Now;

                unitOfWork.Servisi.Update(servis);

                if (unitOfWork.Complete() > 0)
                {
                    Uspesno = "Uspesno ste izmenili servis!";
                    IdPostoji = "";
                }
            }
        }
    }
}
