using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itroEntity
{
    class Chaton
    {
        public string Nom { get; set; }
        public string Origine { get; set; }

        public override string ToString()
        {
            return $"{Nom} {Origine}";
        }
    }
}
