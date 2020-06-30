using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class DodajIzmeniAgentaViewModel : BindableBase
    {
        public Window Window { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());

        AppAgent a = new AppAgent();

        public AppAgent A
        {
            get { return a; }
            set
            {
                a = value;
                OnPropertyChanged("A");
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

        public MyICommand DodajIzmeniAgentaCommand { get; set; }
        public DodajIzmeniAgentaViewModel(Agent agent = null)
        {
            filijaleLista = unitOfWork.Filijale.GetAll();
            Filijale = new BindingList<Filijala>();

            foreach (var filijala in filijaleLista)
            {
                Filijale.Add(filijala);
            }

            if (agent == null)
            {
                TextBoxEnabled = true;
                TitleContent = "Dodaj agenta";
                ButtonContent = "Dodaj";
                DodajIzmeniAgentaCommand = new MyICommand(onDodajAgenta);
            }
            else
            {
                TextBoxEnabled = false;
                SelektovanaFilijala = unitOfWork.Filijale.Get(agent.FilijalaId);
                a = new AppAgent(agent);
                TitleContent = "Izmeni agenta";
                ButtonContent = "Izmeni";
                DodajIzmeniAgentaCommand = new MyICommand(onIzmeniAgenta);
            }
        }

        public void onDodajAgenta(object parameter)
        {
            bool error = false;

            A.Validate();

            if (SelektovanaFilijala == null)
            {
                FilijalaError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                FilijalaError = "";
            }

            Zaposleni zaposleniIzBaze = unitOfWork.Zaposleni.GetZaposleniByJmbg(A.Jmbg);

            if(zaposleniIzBaze == null)
            {
                IdPostoji = "";
                if (!error && A.IsValid)
                {
                    Agent agent = new Agent();
                    agent.Ime = A.Ime;
                    agent.Prezime = A.Prezime;
                    agent.Broj_ugovora = A.Broj_ugovora;
                    agent.Broj_sertifikata = A.Broj_sertifikata;
                    agent.FilijalaId = SelektovanaFilijala.Id;
                    agent.Jmbg = A.Jmbg;
            
                    unitOfWork.Agenti.Add(agent);


                    if (unitOfWork.Complete() > 0)
                    {
                        Uspesno = "Uspesno ste dodali agenta u bazu!";
                        A = new AppAgent();
                    }

                }
            }
            else
            {
                IdPostoji = "Id je zauzet!";
            }
        }

        public void onIzmeniAgenta(object parameter)
        {
            bool error = false;

            A.Validate();

            if (SelektovanaFilijala == null)
            {
                FilijalaError = "Polje ne moze biti prazno!";
                error = true;
            }
            else
            {
                FilijalaError = "";
            }

            if (!error && A.IsValid)
            {
                Agent agent = unitOfWork.Agenti.GetAgentByJmbg(A.Jmbg);
                agent.Ime = A.Ime;
                agent.Prezime = A.Prezime;
                agent.Broj_ugovora = A.Broj_ugovora;
                agent.Broj_sertifikata = A.Broj_sertifikata;
                agent.FilijalaId = SelektovanaFilijala.Id;

                unitOfWork.Agenti.Update(agent);
                
                if (unitOfWork.Complete() > 0)
                {
                    Uspesno = "Uspesno ste izmenili agenta!";
                }

            }

        }
    }
}
