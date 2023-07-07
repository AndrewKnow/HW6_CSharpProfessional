using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CSharpProfessional
{
    /// <summary>
    /// Информация о файле
    /// </summary>
    public class FileArgs: EventArgs
    {
        public string Name { get; set; }
        public FileArgs(string name)
        {
            Name = name;
        }
    }
}
