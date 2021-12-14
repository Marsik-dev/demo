using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace demo
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static TextBlock getTextBlock(string text, int row, int column)
        {

            var textBlock = new TextBlock();

            textBlock.Text = text;

            Grid.SetColumn(textBlock, column);
            Grid.SetRow(textBlock, row);

            return textBlock;

        }

        public static TextBlock getTextBlock(int text, int row, int column)
        {

            return getTextBlock(text.ToString(), row, column);

        }

        public static TextBox getTextBox(int row, int column, string text = "")
        {

            var textBox = new TextBox();

            textBox.Text = text;

            Grid.SetColumn(textBox, column);
            Grid.SetRow(textBox, row);

            return textBox;

        }

        public static TextBox getTextBox(int row, int column, int text = 0)
        {

            return getTextBox(row, column, text.ToString());

        }

    }
}
