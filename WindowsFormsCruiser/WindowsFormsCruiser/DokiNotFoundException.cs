using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCruiser
{
    public class DokiNotFoundException : Exception
    {
        public DokiNotFoundException(int i) : base("Корабль по месту " + i + " не найден")
        {

        }
    }
}
