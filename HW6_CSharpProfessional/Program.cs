﻿namespace HW6_CSharpProfessional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
            // Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения.

            List<string> list = new();
            
            for (int i = 0; i < 10; i++)
            {
                var randomValue = new Random();
                var val = randomValue.Next(1, 100);

                list.Add(val.ToString());
            }

            Console.WriteLine($"Рандомная коллекция: {string.Join(", ", list)}");

            var maxValue = list.GetMax(mV => int.Parse(mV));

            Console.WriteLine($"Максимальное значение: {maxValue}");




        }
    }
}