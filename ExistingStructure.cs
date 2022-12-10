using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norrona
{
    public class NorronaColors
    {
        /*
        * Representation of the available Norrona colors
        * e.g. "Red", "Blue", "Khaki" and their respective color codes
        * 
        */
        public NorronaColors() { }
        public List<NorronaColor> colors{get; set;}


    }
    public class NorronaColor
    {
        /*
         * Representation of a Norrona color
         * e.g. "Red", "Blue", "Khaki" and their respective color codes
         * 
         */
        public NorronaColor() { }
        public string Name { get; set; }
        public string ColorCode { get; set; }
    }
    public class NorronaConcepts
    {
        /*
        class that stores all the Norrona concepts, 
        e.g. lofoten, tamok etc
        */
        public NorronaConcepts() { }
        public List<NorronaConcept> concepts { get; set; } 
    }
    public class NorronaConcept
    {
        /*
         * Representation of a Norrona concept
         * e.g. lofoten, oslo, lyngen etc
         * 
         */
        public NorronaConcept() { }
        public string Name { get; set; }
    }
    public class NorronaSizes
    {
        public NorronaSizes() { }
        public List<NorronaSize> sizes { get; set; }

    }
    public class NorronaSize
    {
        public NorronaSize() { }
        public string Name { get; set; }
        public int Sort { get; set; }
    }
}
