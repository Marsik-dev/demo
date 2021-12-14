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
using System.Windows.Shapes;

namespace demo
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();

            exit.Click += (s, e) => { new AuthWindow().Show(); this.Close(); };

            var context = new Context();

            foreach (var teacher in context.Teacher)
            {

                var subjects = teacher.Subject.ToArray();

                foreach (var subject in subjects)
                {

                    foreach (var group in subject.Attestation1.ToArray())
                    {

                        var text = subject.name + " - " + group.Student.Groups.name + " - " + teacher.full_name;

                        var item = new ListBoxItem();
                        item.Content = text;

                        bool isOk = true;

                        foreach (ListBoxItem i in Subjects.Items) if (i.Content.Equals(text)) isOk = false;

                        if (isOk) Subjects.Items.Add(item);

                    }

                }

            }

            groupUpdate();
            studentUpdate();
            teachersUpdate();

            addGroup.Click += (s, e) =>
            {

                new AddGroup(this).Show();

            };

        }

        public void groupUpdate()
        {

            var context = new Context();

            var groups = context.Groups.ToArray();

            for (int i = 0; i < groups.Length; i ++)
            {

                GroupsList.RowDefinitions.Add(new RowDefinition());

                GroupsList.Children.Add(App.getTextBlock(groups[i].name, i, 0));
                GroupsList.Children.Add(App.getTextBlock(groups[i].year, i, 1));

            }

        }

        void studentUpdate()
        {

            var context = new Context();

            var students = context.Student.ToArray();

            for (int i = 0; i < students.Length; i++)
            {

                StudentsList.RowDefinitions.Add(new RowDefinition());

                StudentsList.Children.Add(App.getTextBlock(students[i].full_name, i, 0));
                StudentsList.Children.Add(App.getTextBlock(students[i].Groups.name, i, 1));

            }

        }

        void teachersUpdate()
        {

            var context = new Context();

            var teachers = context.Teacher.ToArray();

            for (int i = 0; i < teachers.Length; i++)
            {

                TeachersList.RowDefinitions.Add(new RowDefinition());

                TeachersList.Children.Add(App.getTextBlock(teachers[i].full_name, i, 0));
                TeachersList.Children.Add(App.getTextBlock(teachers[i].Subject.First().name, i, 1));

            }

        }

    }
}
