﻿using CollegeAdmissionAutomation;
using BD;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Курсач_сайко_1125
{
    public partial class LogIn : Window, INotifyPropertyChanged
    {
        private string errorMessage;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Login { get; set; }
        void Signal([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public LogIn()
        {
            InitializeComponent();
            DataContext = this;
        }
        public string ErrorMesage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                Signal();
            }
        }

        private void CheckAuth(string login, string pass)
        {
            // Проверка на правильный ввод данных
            var user = DB.Instance.Logins.FirstOrDefault(s => s.FirstName == login && s.Password == pass);
            if (user != null)
            {
                // If the login is successful, open the new window
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else if (login == null || pass == null)
            {
                ErrorMesage = "Неправильно указан логин или пароль!";
            }
            else
            {
                ErrorMesage = "Неправильный логин или пароль!";
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            CheckAuth(Login, passwordBox.Password);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the Register window.
            Registred registred = new Registred();

            // Show the Register window.
            registred.Show();


        }   
    }
}