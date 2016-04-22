namespace Elen7045_Dodge.GameLogic
{
    public static class GameObjectArray
    {
        public static GameObject Get(this GameObject[,] gameObjects, Vector location)
        {
            return gameObjects[location.X, location.Y];
        }
        public static void Set(this GameObject[,] gameObjects, Vector location, GameObject gameObject)
        {
            gameObjects[location.X, location.Y] = gameObject;
        }
        public static GameObject[,] New(Vector size)
        {
            return new GameObject[size.X, size.Y];
        }
    }
}