using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elen7045_Dodge.GameLogic;
using NUnit.Framework;

namespace Elen7045_Dodge.Tests
{
    public abstract class Test5X5Base
    {
        protected GameController Game;
        protected const int GameWidth = 5;
        protected const int GameHeight = 5;

        [SetUp]
        public void Setup()
        {
            Game = new GameController(GameWidth, GameHeight);
        }
        protected IEnumerable<GameObject> GetGameObjectsAsList()
        {
            return Game.GameGrid.GameObjects.Cast<GameObject>();
        }
    }
}
