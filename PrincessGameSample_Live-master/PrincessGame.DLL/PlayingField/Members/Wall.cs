
using PrincessGame.DLL.PlayingField.Interfaces;

namespace PrincessGame.DLL.PlayingField.Members
{
    public class Wall : IPlaceble
    {
        public int ViewPriority => 10;

        public bool Place(GameField gameField, Position position)
        {
            gameField[position].Entities.Add(this);

            return true;
        }
    }
}
