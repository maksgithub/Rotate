using System.Windows;
using Prism;
using Prism.Common;
using Prism.Mvvm;

namespace WpfApp2
{
    public class ObservablePoint : BindableBase
    {
        private double _x = 0;
        private double _y = 0;

        public double X
        {
            get { return _x; }
            set
            {
                if(_x == value) return;
                _x = value;
                OnPropertyChanged();
            }
        }



        public double Y
        {
            get { return _y; }
            set
            {
                if (_y == value) return;
                _y = value;
                OnPropertyChanged();
            }
        }

        public ObservablePoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public ObservablePoint()
        {
            
        }
    }
}