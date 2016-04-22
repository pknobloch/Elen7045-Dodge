using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Elen7045_Dodge.GameLogic;
using Vector = Elen7045_Dodge.GameLogic.Vector;

namespace Elen7045_Dodge.GameView
{
    public class GameViewModel
    {
        private GameController _gameController;
        private Player _player;
        private List<Raindrop> _raindrops = new List<Raindrop>();
        public List<UserControl> GameObjects = new List<UserControl>();
        public int GameWidth { get; set; }
        public int GameHeight { get; set; }

        public GameViewModel()
        {
            SetupDesignModeValues();
        }
        private void SetupDesignModeValues()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                GameWidth = 10;
                GameHeight = 10;
            }
        }
        public GameViewModel(int gameWidth, int gameHeight)
        {
            GameWidth = gameWidth;
            GameHeight = gameHeight;
            _gameController = new GameController(GameWidth, GameHeight);
        }
        public void AddPlayer()
        {
            var x = 0;
            var y = GameHeight-1;
            _player = new Player(new Vector(x, y));
            _gameController.TryAdd(_player);
            GameObjects.Add(new PlayerControl(_player, GameWidth));
        }
        public void AddRaindrop()
        {
            var gameSize = new Vector(GameWidth, GameHeight);
            var startLocation = Raindrop.GetValidStartLocation(gameSize, RandomNumberGenerator.Instance);
            var raindrop = new Raindrop(startLocation);
            while (_gameController.TryAdd(raindrop) != null)
            {
                //A collision occured. Try add it somewhere new
                startLocation = Raindrop.GetValidStartLocation(gameSize, RandomNumberGenerator.Instance);
                raindrop = new Raindrop(startLocation);
            }
            _raindrops.Add(raindrop);
            GameObjects.Add(new RaindropControl(raindrop));
        }
        public CollisionEvent HandeInput(Vector direction)
        {
            foreach (var raindrop in _raindrops)
            {
                _gameController.Move(new MoveCommand(raindrop, Vector.Down));
            }
            var collisionEvent = _gameController.Move(new MoveCommand(_player, direction));
            return collisionEvent;
        }
    }
}
