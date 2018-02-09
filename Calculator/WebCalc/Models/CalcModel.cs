using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class CalcModel
    {
        public IEnumerable<string> Operations { get; set; }

        public double? Result { get; set; }
    }
}