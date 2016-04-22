namespace Elen7045_Dodge.GameLogic
{
    public class MoveCommand
    {
        public GameObject GameObject { get; }
        public Vector Distance { get; set; }
        public MoveCommand(GameObject gameObject, Vector distance)
        {
            GameObject = gameObject;
            Distance = distance;
        }
        public Vector GetTargetLocation(Vector gameSize)
        {
            var targetLocation = GameObject.Location + Distance;
            return GameObject.GetTargetLocation(targetLocation, gameSize);
        }
        public Vector Execute(Vector gameSize)
        {
            GameObject.Move(GetTargetLocation(gameSize));
            return GameObject.Location;
        }
    }
}
