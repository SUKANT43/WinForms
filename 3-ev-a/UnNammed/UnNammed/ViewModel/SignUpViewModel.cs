using DatabaseLibrary;
using GoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UnNammed.Base;
using UnNammed.Service;

namespace UnNammed.ViewModel
{
    public class SignUpViewModel : Observable
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public string confirmPassword;
        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                confirmPassword = value;
                OnPropertyChanged();
            }
        }


        private MainViewModel mainViewModel;
        public ICommand SignUpCommand { get; }
        DBService dc;

        public SignUpViewModel(MainViewModel mvm)
        {
            dc = new DBService();
            mainViewModel = mvm;
            SignUpCommand = new RelayCommand(o => CreateUser());
        }

        private void CreateUser()
        {
            var tableCheck = dc.IsTableExist("users");

            if (!tableCheck)
            {
                dc.CreateTable("users", new ColumnDetails[] {
                new ColumnDetails("Id")
                {
                    DataType = BaseDatatypes.CHAR,
                    Length = 36,
                    TypeOfIndex = IndexType.PrimaryKey
                },
                new ColumnDetails("Name")
                {
                    DataType = BaseDatatypes.VARCHAR,
                    Length = 100
                },
                new ColumnDetails("Email")
                {
                    DataType = BaseDatatypes.VARCHAR,
                    Length = 100,
                    TypeOfIndex = IndexType.UniqueKey
                },
                new ColumnDetails("Password")
                {
                    DataType = BaseDatatypes.VARCHAR,
                    Length = 255
                }
                });
            }
        }
    }
}
