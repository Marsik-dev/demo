using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace demo
{
    /// <summary>
    /// Логика взаимодействия для AddGroup.xaml
    /// </summary>
    public partial class AddGroup : Window
    {
        
        public AddGroup(AdminWindow window)
        {
            InitializeComponent();

            create.Click += (s, e) =>
            {

                int groupRes, yearRes;

                if (int.TryParse(group.Text, out groupRes) && int.TryParse(year.Text, out yearRes) && new Regex("[0-9]{4}").IsMatch(year.Text) && new Regex("[0-9]{4}").IsMatch(group.Text))
                {

                    var context = new Context();

                    context.Groups.Add(new Groups()
                    {

                        name = groupRes,
                        year = yearRes

                    });

                    context.SaveChanges();

                    window.groupUpdate();

                    Close();

                }
                else MessageBox.Show("Некорректные данные");

            };

        }
    }

}
