using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Elen7045_Dodge.GameView;
using Vector = Elen7045_Dodge.GameLogic.Vector;

namespace Elen7045_Dodge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameViewModel _gameViewModel;
        private int _gameWidth = 10;
        private int _gameHeight = 10;

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < _gameHeight; i++)
            {
                GridMain.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < _gameWidth; i++)
            {
                GridMain.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
        }
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                    HandeInput(new Vector(1, 0));
                    break;
                case Key.Left:
                    HandeInput(new Vector(-1, 0));
                    break;
            }
        }
        private void HandeInput(Vector direction)
        {
            var collisionEvent = _gameViewModel.HandeInput(direction);
            if (collisionEvent != null)
            {
                GameOver();
            }
        }
        private void GameOver()
        {
            KeyUp -= MainWindow_KeyUp; //Detach Keypress event
            GridMain.Children.Clear();
            GameOverLabel.Visibility = StartPanel.Visibility = Visibility.Visible;
        }
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            _gameViewModel = new GameViewModel(_gameWidth, _gameHeight);
            WorldSetup.Setup(_gameViewModel);
            foreach (var userControl in _gameViewModel.GameObjects)
            {
                GridMain.Children.Add(userControl);
            }
            StartPanel.Visibility = Visibility.Collapsed;
            KeyUp += MainWindow_KeyUp; //Attach Keypress event
        }
    }
}
