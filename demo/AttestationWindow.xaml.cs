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
    /// Логика взаимодействия для AttestationWindow.xaml
    /// </summary>
    public partial class AttestationWindow : Window
    {
        public AttestationWindow(Subject subject, Groups group)
        {
            InitializeComponent();

            this.subject = subject;
            this.group = group;

            Update();

        }

        Subject subject; 
        Groups group;

        void Update()
        {

            var context = new Context();

            var attestations = context.Attestation.ToArray();

            int i = 0;

            foreach (var attestation in attestations)
            {

                if (!attestation.Subject.name.Equals(subject.name) || !attestation.Student.Groups.name.Equals(group.name)) continue;

                MarksList.RowDefinitions.Clear();
                MarksList.Children.Clear();

                MarksList.Children.Add(App.getTextBlock(attestation.Student.full_name, i, 0));

                var first = App.getTextBox(i, 1, attestation.first);
                var second = App.getTextBox(i, 2, attestation.second);
                var final = App.getTextBox(i, 3, attestation.final);

                MarksList.Children.Add(first);
                MarksList.Children.Add(second);
                MarksList.Children.Add(final);
                MarksList.Children.Add(App.getTextBlock((int)attestation.sum, i, 4));

                var mark = App.getTextBlock(attestation.MarksType.name, i, 5);

                if (attestation.mark == 6 || attestation.mark == 4) mark.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                else mark.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));

                MarksList.Children.Add(mark);

                var editButton = new Button();

                editButton.Click += (s, e) =>
                {

                    int firstRes, secondRes, finalRes;

                    if(int.TryParse(first.Text, out firstRes) &&
                        int.TryParse(second.Text, out secondRes) &&
                        int.TryParse(final.Text, out finalRes))
                    {

                        attestation.first = firstRes;
                        attestation.second = secondRes;
                        attestation.final = finalRes;

                        var sum = firstRes + secondRes + finalRes;

                        if(attestation.Subject.AttestationType.id == 2){

                            if (sum < 70) attestation.mark = 4;
                            else attestation.mark = 5;

                        }
                        else
                        {

                            if (sum < 70) attestation.mark = 6;
                            else if (sum < 80) attestation.mark = 1;
                            else if (sum < 90) attestation.mark = 2;
                            else attestation.mark = 3;

                        }

                        context.SaveChanges();
                        Update();

                    }

                };
                Grid.SetRow(editButton, i);
                Grid.SetColumn(editButton, 6);

                MarksList.Children.Add(editButton);

            }

        }

    }
}
