using System;
using System.Collections.Generic;
using System.Linq;
using Elen7045_Dodge.GameLogic;
using NUnit;
using NUnit.Framework;

namespace Elen7045_Dodge.Tests
{
    [TestFixture]
    public class PlayerTest5X5 : Test5X5Base
    {
        [Test]
        public void TheGameHasAPlayer()
        {
            Game.TryAdd(new Player(new Vector(0, GameHeight - 1)));
            var foundAPlayer = GetGameObjectsAsList().Any(GameObjectIsOfTypePlayer);
            Assert.IsTrue(foundAPlayer);
        }
        private static bool GameObjectIsOfTypePlayer(GameObject gameObject)
        {
            return gameObject != null && gameObject.GetType() == typeof(Player);
        }
        //A single player who can only move left and right and is controlled via the keyboard.
        [Test]
        [TestCase(0, -1, GameWidth - 1)]
        [TestCase(GameWidth - 1, 1, 0)]
        public void ThePlayerMovingPastTheBoundaryWrapsAround(int startLocationX, int moveDirection, int expectedResult)
        {
            var startLocationY = GameHeight - 1;
            var player = new Player(new Vector(startLocationX, startLocationY));
            Game.TryAdd(player);
            Game.Move(new MoveCommand(player, new Vector(moveDirection, 0))); //Move left or right depending on the direction
            Assert.AreEqual(expectedResult, player.Location.X);
            Assert.AreEqual(startLocationY, player.Location.Y);
            Assert.AreEqual(player, Game.GameGrid.Get(new Vector(expectedResult, startLocationY)));
        }
        [Test]
        public void ThePlayerCanCollideWithARaindrop()
        {
            var player = new Player(new Vector(0, 0));
            var raindrop = new Raindrop(new Vector(1, 0));
            Game.TryAdd(player);
            Game.TryAdd(raindrop);
            var collisionEvent = Game.Move(new MoveCommand(player, new Vector(1, 0)));
            Assert.NotNull(collisionEvent);
            Assert.AreEqual(player, collisionEvent.Source);
            Assert.AreEqual(raindrop, collisionEvent.Destination);
        }
    }
}
