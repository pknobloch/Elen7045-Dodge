namespace Elen7045_Dodge.GameLogic
{
    public class GameGrid
    {
        public Vector GameSize { get; }
        public GameObject[,] GameObjects { get; }
        private CollisionDetector CollisionDetector { get; }

        public GameGrid(Vector gameSize)
        {
            GameSize = gameSize;
            GameObjects = GameObjectArray.New(gameSize);
            CollisionDetector = new CollisionDetector(this);
        }
        public GameObject Get(Vector location)
        {
            return GameObjects.Get(location);
        }
        /// <summary>
        /// Try to add the gameObject
        /// </summary>
        /// <returns>A CollisionEvent or Null</returns>
        public CollisionEvent TryAdd(GameObject gameObject)
        {
            var collisionEvent = CollisionDetector.CheckForCollision(gameObject);
            if (collisionEvent == null)
            {
                Add(gameObject);
            }
            return collisionEvent;
        }
        private void Add(GameObject gameObject)
        {
            GameObjects.Set(gameObject.Location, gameObject);
        }
        /// <summary>
        /// Try to move the gameObject
        /// </summary>
        /// <returns>A CollisionEvent or Null</returns>
        public CollisionEvent Move(MoveCommand moveCommand)
        {
            var collisionEvent = CollisionDetector.CheckForCollision(moveCommand);
            ExecuteMove(moveCommand);
            return collisionEvent;
        }
        private void ExecuteMove(MoveCommand moveCommand)
        {
            var gameObject = moveCommand.GameObject;
            var location = gameObject.Location;
            GameObjects.Set(location, null);
            var newLocation = moveCommand.Execute(GameSize);
            GameObjects.Set(newLocation, gameObject);
        }
    }
}
