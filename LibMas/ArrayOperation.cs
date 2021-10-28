using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace LibMas
{
    public class ArrayOperation
    {
        public static void SaveArray(int[] array, string path)
        {
           using (StreamWriter save = new StreamWriter(path))
           {
                save.WriteLine(array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    save.WriteLine(array[i]);
                }
           }
        }
        public static void OpenArray(ref int[] array, string path )
        {
            using (StreamReader open = new StreamReader(path))
            {
                
                
                int arrayLenght = Convert.ToInt32(open.ReadLine());
                array = null;
                array = new int[arrayLenght];
                
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = Convert.ToInt32(open.ReadLine());

                }
                open.Close();
            }
        }
        public static void ClearArray(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }
        public static void FillArrayRandom(int[] array, int minValue, int maxValue)
        {
            Random randomNumber = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomNumber.Next(minValue, maxValue);
            }
        }
    }
}
