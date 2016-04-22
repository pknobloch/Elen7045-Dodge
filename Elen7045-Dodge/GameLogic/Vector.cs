using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Elen7045_Dodge.Properties;

namespace Elen7045_Dodge.GameLogic
{
    public class Vector : INotifyPropertyChanged, IEquatable<Vector>
    {
        public static Vector Right = new Vector(1,0);
        public static Vector Left = new Vector(-1,0);
        public static Vector Down = new Vector(0,1);

        private int _x;
        public int X
        {
            get { return _x; }
            set
            {
                if (_x != value)
                {
                    _x = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set
            {
                if (_y != value)
                {
                    _y = value;
                    OnPropertyChanged();
                }
            }
        }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Set(Vector targetLocation)
        {
            X = targetLocation.X;
            Y = targetLocation.Y;
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }
        public bool Equals(Vector other)
        {
            return X == other.X
                && Y == other.Y;
        }
        public Vector Clone()
        {
            return new Vector(X,Y);
        }

        #region INotifyPropertyChanged events
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
