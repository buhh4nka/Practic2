using System;
using System.IO;
using Microsoft.Win32;

namespace Lib_2
{
    /// <summary>
    /// ИСП-31. Назаров Д. Вариант 2.
    /// Вычислить разницу целых случайных чисел, распределенных в диапазоне от 2 до 10,
    /// пока эта разница не станет меньше некоторого числа K(K<0). Вывести на экран
    /// сгенерированные числа, значение суммы, и количество сгенерированных чисел
    /// </summary>
    public class Practice
    {
        public static void multuplicationOfNumbers(int counter,  out int multOfNumbers, out int[] allNumbersArray)
        {
            Random randomNumber = new Random();
            multOfNumbers = 1;
            
            allNumbersArray = new int[counter];
            int i = 0;
            do
            {
                int number = randomNumber.Next(-10, 10);
                if (number == 0)
                {
                    do
                    {
                        number = randomNumber.Next(-10, 10);
                    } while (number == 0);
                }
                else
                {
                    allNumbersArray[i] = number;
                    i++;

                    
                    multOfNumbers *= number;
                    counter--;
                }
            } while (counter > 0) ;
            
        }


    }
}
