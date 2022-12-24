﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace prac13
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private DispatcherTimer timer;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.IsEnabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            time.Text = now.ToString("HH:mm:ss");
            data.Text = now.ToString("dd.MM.yyyy");
            matrrazm.Text = $"{matrica.GetLength(0)}x{matrica.GetLength(1)}";
            if (nachl != null) indx.Text = $"{nachl.SelectedIndex + 1}";
            else indx.Text = "0";
        }
        double[,] matrica = new double[0, 0];
        double[,] rematr;
        private void Spavka(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кузнецов Алексей Алексеевич ИСП-31. Дана вещественная матрица А(M, N). Строку, содержащий максимальный элемент, поменять местами со строкой, содержащей минимальный элемент.");
        }
        private void Support(object sender, RoutedEventArgs e)
        {
            string target = "https://";
            System.Diagnostics.Process.Start(target);
        }
        private void Quit(object sender, RoutedEventArgs e)
        {
           Close();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            matrica = new double[0, 0]; rematr = null;
            rezu.ItemsSource = null; nachl.ItemsSource = null;
            Row.Clear(); Column.Clear(); Maxrand.Clear();
        }
        private void Massiv(object sender, RoutedEventArgs e)
        {
            if (Row.Text == "" || Column.Text == "" || Maxrand.Text == "")
            {
                MessageBox.Show("Введите правильные данные");
            }
            else
            {
                Int32.TryParse(Row.Text, out int row); Int32.TryParse(Column.Text, out int column); Int32.TryParse(Maxrand.Text, out int maxrand);
                matrica = new double[row, column];
                LibMas.Masssiv.DvDoubleZapol(maxrand, ref matrica);
                nachl.ItemsSource = VisualArray.ToDataTable(matrica).DefaultView;
                LibMas.Masssiv.clearmatrica(ref rematr);
                rezu.ItemsSource = null;
                Row.Clear(); Column.Clear(); Maxrand.Clear();
            }
        }
        private void CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexColumn = nachl.CurrentCell.Column.DisplayIndex;
            int indexRow = nachl.SelectedIndex;
            Double.TryParse(((TextBox)e.EditingElement).Text, out double value);
            matrica[indexRow, indexColumn] = value;
        }
        private void Rechange(object sender, RoutedEventArgs e)
        {
            rematr = Swap.MatrixSwap(matrica);
            rezu.ItemsSource = VisualArray.ToDataTable(rematr).DefaultView;
        }
        private void SaveMas(object sender, RoutedEventArgs e)
        {
            LibMas.Masssiv.DVDoubleSaveMassiv(matrica);
        }
        private void OpenMas(object sender, RoutedEventArgs e)
        {
            LibMas.Masssiv.DVDoubleOpenMassiv(ref matrica);
            nachl.ItemsSource = VisualArray.ToDataTable(matrica).DefaultView;
        }
    }
}
