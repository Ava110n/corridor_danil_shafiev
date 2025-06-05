using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace corridor_danil_shafiev.Model
{
    public class Stone: INotifyPropertyChanged
    {
        double x;
        double y;
        string color;
        string margin = "0,0,0,0";

        public event PropertyChangedEventHandler? PropertyChanged;

        internal double X { get => x; set => x = value; }    
        internal double Y { get => y; set => y = value; }    

        public string Margin { get => margin; set => margin = value; }
        public Stone(double x = 0, double y = 0, string color = "black")
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        internal static double dist_manhattan(Stone A, Stone B)
        {
            return Math.Abs(A.x - B.x) + Math.Abs(A.y - B.y);
        }
    }
}
