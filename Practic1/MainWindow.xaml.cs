using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.IO;
using Lib_2;
using LibMas;
using Microsoft.Win32;

namespace Practic1
{
    /// <summary>
    /// ИСП-31. Назаров Д. Вариант 2.
    /// Вычислить сумму целых случайных чисел, распределенных в диапазоне от 2 до 10, 
    /// пока эта сумма не превышает некоторого числа K.Вывести на экран
    /// сгенерированные числа, значение суммы, и количество сгенерированных чисел.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int[] _numberArray;
        
        private void startProgramm_Click(object sender, RoutedEventArgs e)
        {
            bool isNotError = Int32.TryParse(amountOfNumbers.Text, out int arrayLenght);

    

            if (isNotError && arrayLenght > 0)
            {
                _numberArray = new int[arrayLenght];
                
                Practice.multuplicationOfNumbers(arrayLenght, out int result, out _numberArray) ;
                string allNumbers = string.Empty;
                if (result != 0)
                {
                    multiplicationOfNumbers.Text = result.ToString();
                    for(int i = 0; i < _numberArray.Length; i++)
                    {
                    allNumbers += _numberArray[i] + " ";

                    }
                }
                else
                {
                    for (int i = 0; i < _numberArray.Length; i++)
                    {
                        allNumbers += _numberArray[i] + " ";

                    }
                    MessageBox.Show("Число слишком большое. Попробуйте ввести меньшее количесвто элементов", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    amountOfNumbers.Clear();
                }
                allRandomNumbers.Text = allNumbers;
            }
            else
            {
                MessageBox.Show("Число введено неверно. \nВведите другое значение.", "Ошибка");
                amountOfNumbers.Clear();
            }

        }
        private void help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ИСП-31. Назаров Д. Вариант 2. \nВвести n целых чисел(>0 или <0). Найти произведение чисел. Результат вывести на экран." , "Данные о программе");
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        private void amountOfNumbers_TextChanged(object sender, TextChangedEventArgs e)
        {
            allRandomNumbers.Clear();
            multiplicationOfNumbers.Clear();
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            allRandomNumbers.Clear();
            multiplicationOfNumbers.Clear();
            amountOfNumbers.Clear();
        }

        private void saveArray_Click(object sender, RoutedEventArgs e)
        {
            if (_numberArray == null)
            {
                MessageBox.Show("Таблица пуста", "Ошибка");
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                ArrayOperation.SaveArray(_numberArray, save.FileName);
            }
        }

        private void openArray_Click(object sender, RoutedEventArgs e)
        {
            allRandomNumbers.Clear();
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
           
            if (open.ShowDialog() == true)
            {
                if (open.FileName != string.Empty)
                {
                    ArrayOperation.OpenArray(ref _numberArray, open.FileName) ;
                    open.FileName = File.ReadAllText(open.FileName);
                    
                    int multiplication = 1;
                    amountOfNumbers.Text = _numberArray.Length.ToString();
                    for (int i = 0; i < _numberArray.Length; i++)
                    {
                       
                       
                        allRandomNumbers.Text += _numberArray[i] + " ";
                        multiplication *= _numberArray[i];
                        
                        
                        multiplicationOfNumbers.Text = multiplication.ToString();
                    }


                }
            }
        }
    }
}
