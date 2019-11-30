using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCruiser
{
    public class DokiOccupiedPlaceException : Exception
    {
        public DokiOccupiedPlaceException(int i) : base("На месте" + i + "уже стоит корабль")
        {

        }
    }
}
