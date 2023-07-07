using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW6_CSharpProfessional
{
    /// <summary>
    /// Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
    /// Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения.
    /// </summary>
    public static class GeneralizedExtensionFunccs
    {
        /// <summary>
        /// Метод преобразующий входной тип в число для возможности поиска максимального значения
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <param name="getParameter"></param>
        /// <returns></returns>
        public static T? GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter) where T : class
        {
            // определяем max значение
            var eMax = getParameter(e.OrderByDescending(i => i).First());

            T? desiredValue = null;

            foreach (T val in e)
            {
                var num = getParameter(val);
                if (eMax == num)
                {
                    // возвращаемый объект
                    desiredValue = val;
                }    
            }

            return desiredValue;
        }
    }
}
