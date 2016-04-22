namespace Elen7045_Dodge.GameLogic
{
    public class GameController
    {
        public GameGrid GameGrid { get; }
        public Vector GameSize => GameGrid.GameSize;

        public GameController(int gameWidth, int gameHeight)
        {
            GameGrid = new GameGrid(new Vector(gameWidth, gameHeight));
        }
        public CollisionEvent TryAdd(GameObject gameObject)
        {
            return GameGrid.TryAdd(gameObject);
        }
        public CollisionEvent Move(MoveCommand moveCommand)
        {
            return GameGrid.Move(moveCommand);
        }
    }
}
