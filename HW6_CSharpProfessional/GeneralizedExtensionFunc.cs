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
        public static T GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter) where T : class
        {
            var eMax = e.OrderByDescending(i => i).First();
            return eMax;
        }
    }
}
