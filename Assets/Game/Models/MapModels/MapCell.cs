using Assets.Game.Models.MapModels.PawnModels;

namespace Assets.Game.Models.MapModels
{
    public class MapCell
    {
        public MapCell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public Pawn Pawn { get; set; }

    }
}
