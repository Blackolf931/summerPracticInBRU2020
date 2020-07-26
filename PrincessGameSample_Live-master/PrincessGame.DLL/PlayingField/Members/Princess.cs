using PrincessGame.DLL.PlayingField.Interfaces;

namespace PrincessGame.DLL.PlayingField.Members
{
    public class Princess : IPlaceble
    {
        public int ViewPriority => 5;

        public bool Place(GameField gameField, Position position)
        {
            gameField[position].Entities.Add(this);

            return true;
        }
    }
}
