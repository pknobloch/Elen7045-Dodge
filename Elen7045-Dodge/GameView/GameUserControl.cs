using System.Windows.Controls;
using Elen7045_Dodge.GameLogic;

namespace Elen7045_Dodge.GameView
{
    public class GameUserControl : UserControl
    {
        public GameObject GameObject { get; }

        public GameUserControl(){}
        public GameUserControl(GameObject gameObject):this()
        {
            GameObject = gameObject;
            SetGridLocation();
            gameObject.Location.PropertyChanged += Location_PropertyChanged;
        }
        private void Location_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SetGridLocation();
        }
        protected void SetGridLocation()
        {
            Grid.SetColumn(this, GameObject.Location.X);
            Grid.SetRow(this, GameObject.Location.Y);
        }
    }
}
