﻿using System;
using System.Collections.Generic;
using System.Data;
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

namespace FinalWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in GroupButton.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }
        private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            string textButton = ((Button)e.OriginalSource).Content.ToString();
            if (textButton == "C")
            {
                text.Clear();
            }
            else if (textButton == "◄")
            {
                text.Text = text.Text.Substring(0, text.Text.Length - 1);
            }
            else if (textButton == "√")
            {
                double f = Convert.ToDouble(text.Text);
                double d = Math.Sqrt(f);
                text.Text = Convert.ToString(d);
            }
            else if (textButton == "x²")
            {
                double f = Convert.ToDouble(text.Text);
                double d = f * f;
                text.Text = Convert.ToString(d);
            }

            else if (textButton == "=")
            {
                text.Text = new DataTable().Compute(text.Text, null).ToString();
            }
            else text.Text += textButton;
        }
    }
}
