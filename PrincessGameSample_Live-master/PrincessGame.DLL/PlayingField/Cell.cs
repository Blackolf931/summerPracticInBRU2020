using System;
using System.Collections.Generic;
using System.Linq;
using PrincessGame.DLL.PlayingField.Interfaces;

namespace PrincessGame.DLL.PlayingField
{
    public class Cell
    {
        public Position Position { get; set; }

        public List<IPlaceble> Entities { get; set; }

        public List<IPlaceableBomb> BombsEntities { get; set; }

        public Cell(int x, int y)
        {
            Entities = new List<IPlaceble>();
            BombsEntities = new List<IPlaceableBomb>();
            Position = (x, y);
        }

        public IPlaceble TakePriorityEntity()
        {
            if (!Entities.Any())
            {
                return default;
            }

            int maxPriority = Entities.Max(entity => entity.ViewPriority);

            return Entities.FirstOrDefault(entity => entity.ViewPriority == maxPriority);
        }

        public bool Has(Type type) => Entities.Any(entity => entity.GetType() == type);
    }
}
