﻿using System;
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
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Windows.Diagnostics;
using LibMas;

namespace prac13
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }
        private void Отмена(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Сохранить(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(Row.Text, out int row); Int32.TryParse(Column.Text, out int column);
            if (row >= 0 || column >= 0)
            {
                Masssiv.ConfigDoubleSaveMassiv(row, column);
                MessageBoxResult res = MessageBox.Show("Настройки сохранены", "Настройки", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Введите корректные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
