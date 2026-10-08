using MathEducation.ModelsBD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MathEducation
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        MathContext _db = new MathContext();

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text.Length > 0 && pbPass.Password.Length > 0)
            {
                _db.Users.Load();
                var user = _db.Users.Where(u => u.Login == tbLogin.Text && u.Password == pbPass.Password);
                if (user.Count() == 1)
                {
                    Data.login = true;
                    Data.user = user.First();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
    }
}
