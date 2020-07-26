using System;
using System.Collections.Generic;
using PrincessGame.DLL.PlayingField.Members;

namespace PrincessGame.General.Resources
{
    public class ViewSettings
    {
        public static string EmptyCellView = "-";

        public static Dictionary<Type, string> EntitiesView = new Dictionary<Type, string>()
        {
            
            {typeof(Wall), "*"},
            {typeof(Player), "P"},
            {typeof(Princess), "R"},
          
        };
    }
}
