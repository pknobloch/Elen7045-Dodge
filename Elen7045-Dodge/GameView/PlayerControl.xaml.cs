using System.ComponentModel;
using System.Runtime.CompilerServices;
using Elen7045_Dodge.GameLogic;
using Elen7045_Dodge.Properties;
using Vector = Elen7045_Dodge.GameLogic.Vector;

namespace Elen7045_Dodge.GameView
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : GameUserControl
    {
        private readonly int _gameWidth;
        //0,0 is top left, therefore you start facing right as being forward
        public bool FacingRight { get; private set; } = true;
        private Vector _lastLocation;

        public PlayerControl()
        {
            InitializeComponent();
        }
        public PlayerControl(Player player, int gameWidth)
            :base(player)
        {
            _gameWidth = gameWidth;
            InitializeComponent();
            player.Location.PropertyChanged += Location_PropertyChanged;
            _lastLocation = player.Location.Clone();
        }
        private void Location_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var newLocation = (Vector)sender;
            var direction = (newLocation - _lastLocation).X;
            if (OnOppositeSides(newLocation, _lastLocation))
            {
                FacingRight = direction <= 0;
            }
            else
            {
                FacingRight = direction >= 0;
            }
            GridWitchScaleX.ScaleX = FacingRight ? 1 : -1;
            _lastLocation = newLocation.Clone();
        }

        private bool OnOppositeSides(Vector vector1, Vector vector2)
        {
            return (vector1.X == 0 && vector2.X == _gameWidth - 1) ||
                   (vector2.X == 0 && vector1.X == _gameWidth - 1);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
