namespace Elen7045_Dodge.GameLogic
{
    public class Player : GameObject
    {
        //Default constructor needed for binding to view
        public Player() :base(new Vector(0,0)) {}
        public Player(Vector location) : base(location)
        {
        }

        public override Vector GetTargetLocation(Vector targetLocation, Vector gameSize)
        {
            if (targetLocation.X < 0)
            {
                //Right of grid
                return new Vector(gameSize.X - 1, targetLocation.Y);
            }
            if (targetLocation.X == gameSize.X)
            {
                //Left of grid
                return new Vector(0, targetLocation.Y);
            }
            return targetLocation;
        }
    }
}
