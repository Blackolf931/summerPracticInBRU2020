using PrincessGame.DLL.PlayingField.Interfaces;
using PrincessGame.DLL.PlayingField.Members;
using System;
using System.Collections.Generic;

namespace PrincessGame.DLL.PlayingField
{
   public class Bomb : IPlaceableBomb
    {
        public int Damage { get; set; }

        public Position Position { get; set; }

        public int ViewPriority => 2;

        public List<Bomb> Bombs { get ; set ; }
        
        public Bomb()
        {
            Bombs = new List<Bomb>();
            Damage = GetDamage();
            Position = (GetPosition(), GetPosition());
        }
        private int GetPosition()
        {
            return new Random().Next(1, 10);
        }

        public bool Place(GameField gameField, Position position)
        {
            var targetCell = gameField[position];

            if (targetCell == null || targetCell.Has(typeof(Bomb)))
            {
                return false;
            }

            gameField[this.Position].BombsEntities.Remove(this);

            gameField[position].BombsEntities.Add(this);
            this.Position = position;
            return true;
        }

        private int GetDamage()
        {
            return new Random().Next(1, 10);
        }
    }
}
