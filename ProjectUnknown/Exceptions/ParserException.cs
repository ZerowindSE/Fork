﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.Exceptions
{
    class ParserException : ApplicationException
    {
        public ParserException(string line, int n) : base("Can't parse:" + line + " at line " + (n + 1) + ".") { }
    }
}
