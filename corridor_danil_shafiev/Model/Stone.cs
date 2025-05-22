using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace corridor_danil_shafiev.Model
{
    class Stone
    {
        double x;
        double y;
        string color;

        internal double X { get => x; set => value = x; }    
        internal double Y { get => y; set => value = y; }    
        internal Stone(double x = 0, double y = 0, string color = "black")
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
    }
}
