using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrincessGame.DLL.PlayingField;
using PrincessGame.General.Resources;

namespace PrincessGame.General.Helpers
{
    public static class GameFieldHelper
    {
        public static HtmlString RenderField(this IHtmlHelper html, GameField gameField)
        {
            var builder = new StringBuilder();

            for (int y = gameField.Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < gameField.Width; x++)
                {
                    var priorityEntity = gameField[x, y].TakePriorityEntity();
                    
                    builder.Append(priorityEntity != null
                        ? ViewSettings.EntitiesView[priorityEntity.GetType()]
                        : ViewSettings.EmptyCellView);
                }

                builder.Append("<br/>");
            }

            return new HtmlString(builder.ToString());
        }
    }
}
