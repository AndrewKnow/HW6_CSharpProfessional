using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CSharpProfessional
{
    public class TraversingFileDir
    {
        public event EventHandler<FileArgs>? FileFound;
        public event Action? Сancellation;

    }
}
