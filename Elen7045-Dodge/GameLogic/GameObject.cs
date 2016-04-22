namespace Elen7045_Dodge.GameLogic
{
    public abstract class GameObject
    {
        public Vector Location { get; set; }

        protected GameObject(Vector location)
        {
            Location = location;
        }
        public void Move(Vector targetLocation)
        {
            //It is important to not overwrite the reference so that the display can be updated with the new location
            //i.e Do NOT have Location = targetLocation
            Location.Set(targetLocation);
        }
        /// <summary>
        /// Allow adjustment of the target location based on unique behavior
        /// </summary>
        /// <returns>Adjusted target location based on unique behavior</returns>
        public abstract Vector GetTargetLocation(Vector targetLocation, Vector gameSize);
    }
}
