using System;
using System.Collections.Generic;
using System.Text;

namespace PrincessGame.DLL.PlayingField.Interfaces
{
   public interface IPlaceableBomb : IPlaceble
    {
        int Damage { get; set; }
        Position Position { get; set; }
        List<Bomb> Bombs { get; set; }
    }
}
