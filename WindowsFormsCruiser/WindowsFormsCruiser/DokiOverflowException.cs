﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCruiser
{
    public class DokiOverflowException : Exception
    {
        public DokiOverflowException() : base("Свободных мест нет")
        {

        }
    }
}
