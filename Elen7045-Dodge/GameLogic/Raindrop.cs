namespace Elen7045_Dodge.GameLogic
{
    public class Raindrop : GameObject
    {
        private IRandomNumberGenerator _randomNumberGenerator;

        public Raindrop(IRandomNumberGenerator rng, Vector location) : base(location)
        {
            _randomNumberGenerator = rng;
        }
        public Raindrop(Vector location) : base(location)
        {
        }
        public override Vector GetTargetLocation(Vector targetLocation, Vector gameSize)
        {
            //If the drop  is on the bottom of the screen
            if (targetLocation.Y == gameSize.Y)
            {
                return GetValidStartLocation(gameSize, GetRandomNumberGenerator());
            }
            return targetLocation;
        }
        public static Vector GetValidStartLocation(Vector gameSize, IRandomNumberGenerator randomNumberGenerator)
        {
            //Raindrops appear in random positions in the top quarter of the screen
            var x = randomNumberGenerator.Next(0, gameSize.X);
            var y = randomNumberGenerator.Next(0, gameSize.Y/4);
            return new Vector(x, y);
        }
        private IRandomNumberGenerator GetRandomNumberGenerator()
        {
            return _randomNumberGenerator ?? RandomNumberGenerator.Instance;
        }
    }
}
