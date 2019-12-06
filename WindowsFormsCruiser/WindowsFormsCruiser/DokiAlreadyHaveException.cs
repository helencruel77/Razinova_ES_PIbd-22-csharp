using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCruiser
{
    public class DokiAlreadyHaveException : Exception
    {
        public DokiAlreadyHaveException() : base("В доках уже есть такой корабль")
        { }
    }
}
