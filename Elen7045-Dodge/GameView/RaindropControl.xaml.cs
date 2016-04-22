using Elen7045_Dodge.GameLogic;

namespace Elen7045_Dodge.GameView
{
    /// <summary>
    /// Interaction logic for Raindrop.xaml
    /// </summary>
    public partial class RaindropControl : GameUserControl
    {
        public RaindropControl()
        {
            InitializeComponent();
        }
        public RaindropControl(Raindrop raindrop)
            :base(raindrop)
        {
            InitializeComponent();
        }
    }
}
