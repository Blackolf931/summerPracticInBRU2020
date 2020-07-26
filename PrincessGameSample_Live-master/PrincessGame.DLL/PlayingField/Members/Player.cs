using Microsoft.AspNetCore.Mvc.ModelBinding;
using PrincessGame.DLL.PlayingField.Interfaces;

namespace PrincessGame.DLL.PlayingField.Members
{
    public class Player : IPlayer
    {
        public int HealthPoints { get; set; }

        public Position Position { get; set; }

        public int ViewPriority => 2;

        public bool Place(GameField gameField, Position position)
        {
            var targetCell = gameField[position];

            if (targetCell == null || targetCell.Has(typeof(Wall)))
            {
                return false;
            }

            gameField[this.Position].Entities.Remove(this);

            gameField[position].Entities.Add(this);
            this.Position = position;

            return true;
        }

    }
}
