using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using corridor_danil_shafiev.Model;

namespace corridor_danil_shafiev.ModelView
{
    internal class MV
    {
        int turn = 1;
        bool isMove = false;

        Stone first = new Stone(0,0,"blue");
        Stone second = new Stone(7,7,"red");

        internal void myClick(double x, double y)
        {
            if (isMove) { move(x, y); }
            else
            {
                select(x, y);
            }
        }
        void select(double x, double y) {
            if(turn == 1)
            {
                if (first.X == x && first.Y == y)
                    isMove = true;
                return;
            }
            else
            {
                if (second.X == x && second.Y == y)
                    isMove = true;
                return;
            }
        }

        void move(double x, double y)
        {
            if (turn == 1)
            {
                isLegalMove()
            }
            else
            {

            }
            turn *= -1;
        }
        bool isLegalMove()
        {

        }

    }
}
