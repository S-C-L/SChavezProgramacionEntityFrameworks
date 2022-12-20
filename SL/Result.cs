using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SL
{
    public class Result
    {
        public bool Correct { get; set; }
        public string ErrorMesagge { get; set; }
        public Exception Ex { get; set; }
        public object Object { get; set; }
        public List<Object> Objects { get; set; }
    }
}