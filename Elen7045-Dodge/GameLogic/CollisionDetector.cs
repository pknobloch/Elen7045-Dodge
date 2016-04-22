namespace Elen7045_Dodge.GameLogic
{
    public class CollisionDetector
    {
        private readonly GameGrid _gameGrid;

        public CollisionDetector(GameGrid gameGrid)
        {
            _gameGrid = gameGrid;
        }
        public CollisionEvent CheckForCollision(MoveCommand moveCommand)
        {
            var targetLocation = moveCommand.GetTargetLocation(_gameGrid.GameSize);
            return CheckForCollision(moveCommand.GameObject, targetLocation);
        }
        public CollisionEvent CheckForCollision(GameObject gameObject)
        {
            return CheckForCollision(gameObject, gameObject.Location);
        }
        public CollisionEvent CheckForCollision(GameObject source, Vector targetLocation)
        {
            var destination = _gameGrid.Get(targetLocation);
            return destination != null ?
                new CollisionEvent { Source = source, Destination = destination }
                : null;
        }
    }
}
