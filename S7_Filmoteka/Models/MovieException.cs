using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S7_Filmoteka.Models
{
    public class MovieException : Exception
    {
        public MovieException(string message) : base(message)
        {
            
        }
    }
}
