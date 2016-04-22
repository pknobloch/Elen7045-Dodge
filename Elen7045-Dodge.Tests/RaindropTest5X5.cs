using System;
using System.Collections.Generic;
using System.Linq;
using Elen7045_Dodge.GameLogic;
using NUnit;
using NUnit.Framework;

namespace Elen7045_Dodge.Tests
{
    [TestFixture]
    public class RaindropTest5X5 : Test5X5Base
    {
        [Test]
        public void TheGameHasARaindrop()
        {
            Game.TryAdd(new Raindrop(new Vector(0, 0)));
            var found = GetGameObjectsAsList().Any(GameObjectIsOfTypeRaindrop);
            Assert.IsTrue(found);
        }
        private static bool GameObjectIsOfTypeRaindrop(GameObject gameObject)
        {
            return gameObject != null && gameObject.GetType() == typeof(Raindrop);
        }
        /*Raindrops which appear in random positions in the top quarter of the screen and fall
        vertically downwards.The number of raindrops on the screen at any one time remains
        constant — whenever a raindrop disappears off the bottom of the screen, a new one
        appears at the top of the screen.
        */
        [Test]
        public void TheRaindropMovingPastTheBoundaryWrapsAround()
        {
            var randomNotReally = new NonRandomNumberGenerator();
            var startLocationX = RandomNumberGenerator.Instance.Next(0, GameWidth); //Anywhere along the horizontal
            int startLocationY = GameHeight - 1; //Bottom of the screen
            var raindrop = new Raindrop(randomNotReally, new Vector(startLocationX, startLocationY));
            Game.TryAdd(raindrop);
            Game.Move(new MoveCommand(raindrop, new Vector(0, 1))); //Move down
            Assert.AreEqual(randomNotReally.Result, raindrop.Location.Y);
            Assert.AreEqual(randomNotReally.Result, raindrop.Location.X);
        }
        public class NonRandomNumberGenerator : IRandomNumberGenerator
        {
            public int Result = 4; //https://xkcd.com/221/
            public int Next(int minValue, int maxValue)
            {
                return Result; 
            }
        }
    }
}
