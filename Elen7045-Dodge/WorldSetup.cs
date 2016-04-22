using Elen7045_Dodge.GameView;

namespace Elen7045_Dodge
{
    public class WorldSetup
    {
        public static void Setup(GameViewModel gameViewModel)
        {
            gameViewModel.AddPlayer();
            var maxDrops = 8; //TODO Make this a formula or something. This is currently the amount from the brief example
            for (int i = 0; i < maxDrops; i++)
            {
                gameViewModel.AddRaindrop();
            }
        }
    }
}
