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
    public class DodajIzmeniRezervacijuViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        AppRezervacija r = new AppRezervacija();
        public AppRezervacija R
        {
            get { return r; }
            set
            {
                r = value;
                OnPropertyChanged("R");
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

        string osiguranjeError;
        public string OsiguranjeError
        {
            get { return osiguranjeError; }
            set
            {
                osiguranjeError = value;
                OnPropertyChanged("OsiguranjeError");
            }
        }

        string agentError;
        public string AgentError
        {
            get { return agentError; }
            set
            {
                agentError = value;
                OnPropertyChanged("AgentError");
            }
        }

        string klijentError;
        public string KlijentError
        {
            get { return klijentError; }
            set
            {
                klijentError = value;
                OnPropertyChanged("KlijentError");
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

        Osiguranje selektovanoOsiguranje;
        public Osiguranje SelektovanoOsiguranje
        {
            get { return selektovanoOsiguranje; }
            set
            {
                selektovanoOsiguranje = value;
                OnPropertyChanged("SelektovanoOsiguranje");
            }
        }

        Agent selektovanAgent;
        public Agent SelektovanAgent
        {
            get { return selektovanAgent; }
            set
            {
                selektovanAgent = value;
                OnPropertyChanged("SelektovanAgent");
            }
        }

        Klijent selektovanKlijent;
        public Klijent SelektovanKlijent
        {
            get { return selektovanKlijent; }
            set
            {
                selektovanKlijent = value;
                OnPropertyChanged("SelektovanKlijent");
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
                agentiLista = unitOfWork.Agenti.GetAll();
                Agenti = new BindingList<Agent>();

                foreach (var agent in agentiLista)
                {
                    Agenti.Add(agent);
                }

                foreach (var agent in Agenti.ToList())
                {
                    if(agent.FilijalaId != value.FilijalaId)
                    {
                        Agenti.Remove(agent);
                    }
                }
            }
        }


        List<Osiguranje> osiguranjaLista = new List<Osiguranje>();

        BindingList<Osiguranje> osiguranja = new BindingList<Osiguranje>();
        public BindingList<Osiguranje> Osiguranja
        {
            get { return osiguranja; }
            set
            {
                osiguranja = value;
                OnPropertyChanged("Osiguranja");
            }
        }


        List<Agent> agentiLista = new List<Agent>();

        BindingList<Agent> agenti = new BindingList<Agent>();
        public BindingList<Agent> Agenti
        {
            get { return agenti; }
            set
            {
                agenti = value;
                OnPropertyChanged("Agenti");
            }
        }


        List<Klijent> klijentiLista = new List<Klijent>();

        BindingList<Klijent> klijenti = new BindingList<Klijent>();
        public BindingList<Klijent> Klijenti
        {
            get { return klijenti; }
            set
            {
                klijenti = value;
                OnPropertyChanged("Klijenti");
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

        public MyICommand DodajIzmeniRezervacijuCommand { get; set; }

        public DodajIzmeniRezervacijuViewModel(Rezervacija rezervacija = null)
        {
            osiguranjaLista = unitOfWork.Osiguranja.GetAll();
            agentiLista = unitOfWork.Agenti.GetAll();
            klijentiLista = unitOfWork.Klijenti.GetAll();
            vozilaLista = unitOfWork.Vozila.GetAll();

            Osiguranja = new BindingList<Osiguranje>();
            Agenti = new BindingList<Agent>();
            Klijenti = new BindingList<Klijent>();
            Vozila = new BindingList<Vozilo>();

            foreach (var osiguranje in osiguranjaLista)
            {
                Osiguranja.Add(osiguranje);
            }

            foreach (var agent in agentiLista)
            {
                Agenti.Add(agent);
            }

            foreach (var klijent in klijentiLista)
            {
                Klijenti.Add(klijent);
            }

            foreach (var vozilo in vozilaLista)
            {
                Vozila.Add(vozilo);
            }

            if (rezervacija == null)
            {
                TextBoxEnabled = true;
                TitleContent = "Dodaj rezervaciju";
                ButtonContent = "Dodaj";
                DodajIzmeniRezervacijuCommand = new MyICommand(onDodajRezervaciju);
            }
            else
            {
                TextBoxEnabled = false;
                r = new AppRezervacija(rezervacija);   
                TitleContent = "Izmeni rezervaciju";
                ButtonContent = "Izmeni";
                SelektovanAgent = unitOfWork.Agenti.GetAgentByJmbg(rezervacija.AgentJmbg);
                SelektovanKlijent = unitOfWork.Klijenti.GetKlijentByJmbg(rezervacija.KlijentJmbg);
                SelektovanoOsiguranje = unitOfWork.Osiguranja.Get(rezervacija.OsiguranjeId);
                SelektovanoVozilo = unitOfWork.Vozila.Get(rezervacija.VoziloId);

                DodajIzmeniRezervacijuCommand = new MyICommand(onIzmeniRezervaciju);
            }
        }

        public void onDodajRezervaciju(object parameter)
        {
            bool error = false;

            R.Validate();

            if (SelektovanoVozilo == null)
            {
                VoziloError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                VoziloError = "";
            }

            if (SelektovanoOsiguranje == null)
            {
                OsiguranjeError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                OsiguranjeError = "";
            }


            if (SelektovanKlijent == null)
            {
                KlijentError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                KlijentError = "";
            }

            if (SelektovanAgent == null)
            {
                AgentError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                AgentError = "";
            }

            Rezervacija rezervacijaIzBaze = unitOfWork.Rezervacije.Get(R.Id);

            if(rezervacijaIzBaze == null)
            {
                IdPostoji = "";
                if (!error && R.IsValid)
                {
                    Rezervacija rezervacija = new Rezervacija();
                    rezervacija.Id = R.Id;
                    rezervacija.KlijentJmbg = SelektovanKlijent.Jmbg;
                    rezervacija.AgentJmbg = SelektovanAgent.Jmbg;
                    rezervacija.VoziloId = SelektovanoVozilo.Id;
                    rezervacija.OsiguranjeId = SelektovanoOsiguranje.Id;
                    rezervacija.Datum_vracanja = R.Datum_vracanja.Date;
                    rezervacija.Datum_preuzimanja = R.Datum_preuzimanja.Date;
                    rezervacija.Datum_rezervacije = DateTime.Now;

                    unitOfWork.Rezervacije.Add(rezervacija);

                    if (unitOfWork.Complete() > 0)
                    {
                        Uspesno = "Uspesno ste dodali rezervaciju u bazu!";
                        R = new AppRezervacija();
                    }
                }
            }
            else
            {
                IdPostoji = "Id je zauzet!";
                Uspesno = "";
            }
        }

        public void onIzmeniRezervaciju(object parameter)
        {
            bool error = false;

            R.Validate();

            if (SelektovanoVozilo == null)
            {
                VoziloError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                VoziloError = "";
            }

            if (SelektovanoOsiguranje == null)
            {
                OsiguranjeError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                OsiguranjeError = "";
            }


            if (SelektovanKlijent == null)
            {
                KlijentError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                KlijentError = "";
            }

            if (SelektovanAgent == null)
            {
                AgentError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                AgentError = "";
            }

            if (!error && R.IsValid)
            {
                Rezervacija rezervacija = unitOfWork.Rezervacije.Get(R.Id);
                rezervacija.KlijentJmbg = SelektovanKlijent.Jmbg;
                rezervacija.AgentJmbg = SelektovanAgent.Jmbg;
                rezervacija.VoziloId = SelektovanoVozilo.Id;
                rezervacija.OsiguranjeId = SelektovanoOsiguranje.Id;
                rezervacija.Datum_vracanja = R.Datum_vracanja.Date;
                rezervacija.Datum_preuzimanja = R.Datum_preuzimanja.Date;

                unitOfWork.Rezervacije.Update(rezervacija);

                if (unitOfWork.Complete() > 0)
                {
                    Uspesno = "Uspesno ste izmenili rezervaciju!";
                    IdPostoji = "";
                }
            }
        }
    }
}
