using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class RegistracijaViewModel : BindableBase
    {
        public Window Window { get; set; }
        private string korisnickoIme;
        private SecureString _password;
        public SecureString PasswordSecureString
        {
            get { return _password; }
            set
            {
                if (value != null)
                {
                    _password = value;
                    OnPropertyChanged("PasswordSecureString");
                }
            }
        }

        public string KorisnickoIme { get => korisnickoIme; set { korisnickoIme = value; OnPropertyChanged("KorisnickoIme"); } }
        public MyICommand RegistracijaCommand { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());
        public RegistracijaViewModel(RegistracijaView window)
        {
            this.Window = window;
            RegistracijaCommand = new MyICommand(onRegistracija);
        }
        string proveraK;
        public string ProveraK
        {
            get { return proveraK; }
            set
            {
                proveraK = value;
                OnPropertyChanged("ProveraK");
            }
        }

        string proveraL;
        public string ProveraL
        {
            get { return proveraL; }
            set
            {
                proveraL = value;
                OnPropertyChanged("ProveraL");
            }
        }
        public void onRegistracija(object parameter)
        {
            Korisnik k = new Korisnik();
            k.KorisnickoIme = KorisnickoIme;
            k.Lozinka = new System.Net.NetworkCredential(string.Empty, PasswordSecureString).Password;

            ProveraK = "";
            ProveraL = "";
            if (string.IsNullOrEmpty(KorisnickoIme))
            {
                ProveraK = "Morate uneti korisnicko ime!";
            }
            if (PasswordSecureString == null)
            {
                ProveraL = "Morate uneti lozinku!";
            }
            if (unitOfWork.Korisnici.ProveraKorisnickogImena(KorisnickoIme))
            {
                MessageBox.Show("Pogresno korisnicko ime!");
            }
            else
            {
                unitOfWork.Korisnici.Add(k);
                unitOfWork.Korisnici.SaveChanges();
               
                this.Window.Close();
            }

      
        }
    }
}
