using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW6_CSharpProfessional
{
    public static class GeneralizedExtensionFunccs
    {
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
