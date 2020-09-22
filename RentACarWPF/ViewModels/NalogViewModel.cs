using RentACar;
using RentACar.DAO;
using RentACarWPF.Helpers;
using RentACarWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentACarWPF.ViewModels
{
    public class NalogViewModel : BindableBase
    {
        private string KorisnickoIme;
        private string password;
        UnitOfWork unitOfWork = new UnitOfWork(new ModelContainer());
        public Window Window { get; set; }
        private SecureString _password;
        public string Password { get => password; set { password = value; OnPropertyChanged("Password"); } }
        public MyICommand PromenaLozinkeCommand { get; set; }
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

        private SecureString _password2;
        public SecureString PasswordSecureString2
        {
            get { return _password2; }
            set
            {
                if (value != null)
                {
                    _password2 = value;
                    OnPropertyChanged("PasswordSecureString2");
                }
            }
        }

        public NalogViewModel(Window window,string korisnickoIme)
        {
            KorisnickoIme = korisnickoIme;
            PromenaLozinkeCommand = new MyICommand(onPromena);
            this.Window = window;
        }

     

        public void onPromena(object parameter)
        {
            String pass = new System.Net.NetworkCredential(string.Empty, PasswordSecureString).Password;
            String pass2 = new System.Net.NetworkCredential(string.Empty, PasswordSecureString2).Password;
            bool error = false;

            K.Validate();

            K.Lozinka = pass;           
            K.KorisnickoIme = KorisnickoIme;
         
            
                if (unitOfWork.Klijenti.Login(KorisnickoIme, pass))
                {
                    Klijent k = unitOfWork.Klijenti.ProveraPoImenu(KorisnickoIme);
                    if (k!= null)
                    {
                    K.Jmbg = k.Jmbg;
                    }
                    else
                    {
                    MessageBox.Show("Ne postoji korisnicko ime!");
                    }
                   if (!error && K.IsValid)
                    {
                        k.Lozinka = pass2;
                        k.Ime = K.Ime;
                        k.Prezime = K.Prezime;
                        unitOfWork.Klijenti.Update(k);
                        unitOfWork.Klijenti.SaveChanges();
                        this.Window.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Lozinka pogresna!");
                }
            

        }
    }
}
