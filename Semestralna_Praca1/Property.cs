using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca1
{    
    public interface Property
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public List<GPS> GPSCoords { get; set; }
    }
}
