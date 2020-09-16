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

        public void onPromena(object parameter)
        {
            String pass = new System.Net.NetworkCredential(string.Empty, PasswordSecureString).Password;
            String pass2 = new System.Net.NetworkCredential(string.Empty, PasswordSecureString2).Password;
            ProveraK = "";
            ProveraL = "";
            if (PasswordSecureString == null)
            {
                ProveraK = "Morate uneti staru lozinku!";
            }
            if (PasswordSecureString2 == null)
            {
                ProveraL = "Morate uneti novu lozinku!";
            }
            if (unitOfWork.Korisnici.Login(KorisnickoIme, pass))
            {
                Korisnik k = unitOfWork.Korisnici.ProveraPoImenu(KorisnickoIme);
                if(k != null)
                {
                    k.Lozinka = pass2;
                    unitOfWork.Korisnici.Update(k);
                    unitOfWork.Korisnici.SaveChanges();
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
