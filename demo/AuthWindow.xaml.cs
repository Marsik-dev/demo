using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace demo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();

            AuthButton.Click += (s, e) =>
            {

                var login = Login.Text;
                var pass = Pass.Password;

                if (login.Length == 0 || pass.Length == 0)
                {

                    MessageBox.Show("Введите данные");
                    return;

                }

                var users = new Context().Users;
                foreach(var user in users)
                    if (user.login.Equals(login) && user.pass.Equals(pass))
                    {

                        bd.Current = user;

                        if (user.Student != null)
                        {

                            new StudentWindow().Show();
                            this.Close();

                            return;

                        }
                        else if (user.Teacher != null)
                        {

                            new TeacherWindow().Show();
                            this.Close();

                            return;

                        }
                        else
                        {
                            
                            new AdminWindow().Show();
                            this.Close();

                            return;

                        }

                    }

                MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста, проверьте еще раз данные");

            };

        }
    }
}
