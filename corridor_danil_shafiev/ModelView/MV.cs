using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using corridor_danil_shafiev.Model;
using static corridor_danil_shafiev.MainWindow;

namespace corridor_danil_shafiev.ModelView
{
    public class MV: INotifyCollectionChanged, INotifyPropertyChanged
    {

        int turn = 1;
        bool isMove = false;


        Stone first = new Stone(0, 0, "blue");
        Stone second = new Stone(7, 7, "red");

        ObservableCollection<Stone> stones = new ObservableCollection<Stone>();

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Stone> Stones
        {
            get
            {
                return stones;
            }
            set { 
                stones = value;
                OnPropertyChanged();
            }
        }


        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        DBHelper db;
        public MV()
        {
            Stones = new ObservableCollection<Stone>();

            /*Stones.Add(first);
            Stones.Add(second);*/
            /*Stones = new ObservableCollection<Stone>()
            {
                new Stone(){Margin = "50,50,0,0"},
                new Stone(){Margin = "50,50,0,0"}
            };*/
            db = new DBHelper();
            var myStones = db.LoadData();
            foreach(var stone in myStones)
            {
                Stones.Add(stone);
            }
        }

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
                if(isLegalMove(first, x, y))
                {
                    first.X = (int)(x / 100);
                    first.Y = (int)(y / 100);
                }
            }
            else
            {
                if (isLegalMove(second, x, y))
                {
                    second.X = (int)(x / 100);
                    second.Y = (int)(y / 100);
                }
            }
            turn *= -1;
        }
        bool isLegalMove(Stone current, double nextX, double nextY)
        {
            double newX = (int)(nextX / 100);
            double newY = (int)(nextY / 100);
            if(Stone.dist_manhattan(current, new Stone(newX, newY)) == 1){
                return true;
            }
            return false;
        }

    }
}
