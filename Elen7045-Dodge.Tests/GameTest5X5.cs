using System;
using Elen7045_Dodge.GameLogic;
using NUnit;
using NUnit.Framework;

namespace Elen7045_Dodge.Tests
{
    [TestFixture]
    public class GameTest5X5 : Test5X5Base
    {
        [Test]
        public void TheGameHasGameObjects()
        {
            var gameObject = new Raindrop(new Vector(1,1));
            Game.TryAdd(gameObject);
            Assert.Contains(gameObject, Game.GameGrid.GameObjects);
        }
        [Test]
        public void GameObjectsHaveALocation()
        {
            var gameObject = new Raindrop(new Vector(2,3));
            Game.TryAdd(gameObject);
            Assert.AreEqual(2, gameObject.Location.X);
            Assert.AreEqual(3, gameObject.Location.Y);
            Assert.AreEqual(gameObject, Game.GameGrid.Get(new Vector(2, 3)));
        }
        [Test]
        public void GameObjectsCanBeMoved()
        {
            var gameObject = new Raindrop(new Vector(1,2));
            Game.Move(new MoveCommand(gameObject, new Vector(1, 1)));
            Assert.AreEqual(2, gameObject.Location.X);
            Assert.AreEqual(3, gameObject.Location.Y);
            Assert.AreEqual(gameObject, Game.GameGrid.Get(new Vector(2, 3)));
        }
        [Test]
        public void GameObjectsCanCollide()
        {
            var gameObject1 = new Raindrop(new Vector(1,2));
            var gameObject2 = new Raindrop(new Vector(2,3));
            Game.TryAdd(gameObject1);
            Game.TryAdd(gameObject2);
            var collisionEvent = Game.Move(new MoveCommand(gameObject1, new Vector(1, 1)));
            Assert.NotNull(collisionEvent);
            Assert.AreEqual(gameObject1, collisionEvent.Source);
            Assert.AreEqual(gameObject2, collisionEvent.Destination);
        }
        [Test(Description = "This avoids adding two items at the same location")]
        public void AddingGameObjectsCanCauseCollisions()
        {
            var gameObject1 = new Raindrop(new Vector(1,2));
            var gameObject2 = new Raindrop(new Vector(1,2));
            Game.TryAdd(gameObject1);
            var collision = Game.TryAdd(gameObject2);
            Assert.NotNull(collision);
            //Notice how they are switched. In this case, the second is trying to move into the place of the first.
            Assert.AreEqual(gameObject2, collision.Source);
            Assert.AreEqual(gameObject1, collision.Destination);
        }
    }
}
