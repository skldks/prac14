using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.IO;
using Microsoft.Win32;

namespace LibMas
{
    public class Mas
    {
        public static int[] Zapol(int m, int n, int count)
        {
            int[] mas = new int[count];
            Random rnd = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(m, n);
            }
            return mas;
        }
            public static int[] Clear(int[] mas)
            {
                mas = null;
                return mas;
            }
            public static int[,] Clear(int[,] mas)
            {
                mas = null;
                return mas;
            }
            public static void SaveMassiv(int[] mas)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = ".txt";
                save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
                save.FilterIndex = 2;
                save.Title = "Сохранение таблицы";

                if (save.ShowDialog() == true)
                {
                    StreamWriter file = new StreamWriter(save.FileName);
                    file.WriteLine(mas.Length);
                    for (int i = 0; i < mas.Length; i++)
                    {
                        file.WriteLine(mas[i]);
                    }
                    file.Close();
                }
            }
            public static void OpenMassiv(ref int[] mas)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.DefaultExt = ".txt";
                open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
                open.FilterIndex = 2;
                open.Title = "Открытие таблицы";
                if (open.ShowDialog() == true)
                {
                    StreamReader file = new StreamReader(open.FileName);
                    int len = Convert.ToInt32(file.ReadLine());
                    mas = new int[len];
                    for (int i = 0; i < mas.Length; i++)
                    {
                        mas[i] = Convert.ToInt32(file.ReadLine());
                    }
                    file.Close();
                }
            }
            public static int[,] DVZapol(int i, int j, int max)
            {
                int[,] mas = new int[i, j];
                Random rnd = new Random();
                for (i = 0; i < mas.GetLength(0); i++)
                    for (j = 0; j < mas.GetLength(1); j++)
                        mas[i, j] = rnd.Next(-max, max);
                return mas;
            }
            public static void DvDoubleZapol(int max, ref double[,] matr)
            {
                Random rnd = new Random();
                for (int i = 0; i < matr.GetLength(0); i++)
                    for (int j = 0; j < matr.GetLength(1); j++)
                        matr[i, j] = rnd.Next(-max, max);
            }

            public static void clearmatrica(ref double[,] matr)
            {
                matr = null;
            }
            public static void DVSaveMassiv(int[,] mas)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = ".txt";
                save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
                save.FilterIndex = 2;
                save.Title = "Сохранение таблицы";

                if (save.ShowDialog() == true)
                {
                    StreamWriter file = new StreamWriter(save.FileName);
                    file.WriteLine(mas.GetLength(0));
                    file.WriteLine(mas.GetLength(1));
                    for (int i = 0; i < mas.GetLength(0); i++)
                    {
                        for (int j = 0; j < mas.GetLength(1); j++)
                        {
                            file.WriteLine(mas[i, j]);
                        }
                    }
                    file.Close();
                }
            }
            public static void DVDoubleSaveMassiv(double[,] mas)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = ".txt";
                save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
                save.FilterIndex = 2;
                save.Title = "Сохранение таблицы";

                if (save.ShowDialog() == true)
                {
                    StreamWriter file = new StreamWriter(save.FileName);
                    file.WriteLine(mas.GetLength(0));
                    file.WriteLine(mas.GetLength(1));
                    for (int i = 0; i < mas.GetLength(0); i++)
                    {
                        for (int j = 0; j < mas.GetLength(1); j++)
                        {
                            file.WriteLine(mas[i, j]);
                        }
                    }
                    file.Close();
                }
            }

            public static void DVDoubleOpenMassiv(ref double[,] mas)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.DefaultExt = ".txt";
                open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
                open.FilterIndex = 2;
                open.Title = "Открытие таблицы";
                if (open.ShowDialog() == true)
                {
                    StreamReader file = new StreamReader(open.FileName);
                    int rows = Convert.ToInt32(file.ReadLine());
                    int columns = Convert.ToInt32(file.ReadLine());
                    mas = new double[rows, columns];
                    for (int i = 0; i < mas.GetLength(0); i++)
                    {
                        for (int j = 0; j < mas.GetLength(1); j++)
                        {
                            mas[i, j] = Convert.ToDouble(file.ReadLine());
                        }
                    }
                    file.Close();
                }
            }
            public static void DVOpenMassiv(ref int[,] mas)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.DefaultExt = ".txt";
                open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
                open.FilterIndex = 2;
                open.Title = "Открытие таблицы";
                if (open.ShowDialog() == true)
                {
                    StreamReader file = new StreamReader(open.FileName);
                    int rows = Convert.ToInt32(file.ReadLine());
                    int columns = Convert.ToInt32(file.ReadLine());
                    mas = new int[rows, columns];
                    for (int i = 0; i < mas.GetLength(0); i++)
                    {
                        for (int j = 0; j < mas.GetLength(1); j++)
                        {
                            mas[i, j] = Convert.ToInt32(file.ReadLine());
                        }
                    }
                    file.Close();
                }
            }
        }  
    }