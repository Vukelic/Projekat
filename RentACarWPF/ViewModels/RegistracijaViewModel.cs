using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
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

        AppKlijent k = new AppKlijent();

        public AppKlijent K
        {
            get { return k; }
            set
            {
                k = value;
                OnPropertyChanged("K");
            }
        }
        public MyICommand RegistracijaCommand { get; set; }
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());
        public RegistracijaViewModel(RegistracijaView window)
        {
            this.Window = window;
            RegistracijaCommand = new MyICommand(onRegistracija);
        }
           
        public void onRegistracija(object parameter)
        {
            K.Lozinka = new System.Net.NetworkCredential(string.Empty, PasswordSecureString).Password;
            K.Validate();
            bool error = false;         
        
            if (unitOfWork.Klijenti.ProveraKorisnickogImena(K.KorisnickoIme))
            {
                MessageBox.Show("Pogresno korisnicko ime!");
            }

            if (unitOfWork.Klijenti.ProveraJmbg(K.Jmbg))
            {
                MessageBox.Show("Pogresan jmbg!");
            }
            if (!error && K.IsValid)
            {
                Klijent k = new Klijent();
                k.Lozinka = new System.Net.NetworkCredential(string.Empty, PasswordSecureString).Password;
                k.KorisnickoIme = K.KorisnickoIme;
                k.Prezime = K.Prezime;
                k.Ime = K.Ime;
                k.Jmbg = K.Jmbg;
                k.Uloga = TipUloga.regular;
                unitOfWork.Klijenti.Add(k);
                unitOfWork.Klijenti.SaveChanges();
               
                this.Window.Close();
            }

      
        }
    }
}
