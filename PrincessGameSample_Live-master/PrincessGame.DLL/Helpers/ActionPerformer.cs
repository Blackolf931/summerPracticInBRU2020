using PrincessGame.DLL.PlayingField;
using PrincessGame.DLL.PlayingField.Interfaces;

namespace PrincessGame.DLL.Helpers
{
    public class ActionPerformer
    {
        public void Perform(ActionType actionType, GameField gameField, IPlayer player, IPlaceableBomb bomb)
        {
            var stepPosition = GetPositionAfterAction(actionType, player.Position, player, bomb);

            if (player.Place(gameField, stepPosition))
            {
                player.Position = stepPosition;
            }
        }

        private Position GetPositionAfterAction(ActionType actionType, Position positionBeforeAction, IPlayer player, IPlaceableBomb bomb)
        {
            switch (actionType)
            {
                case ActionType.MoveUp:
                    positionBeforeAction.Y++;
                    GetDamage(player, bomb);
                    break;
                case ActionType.MoveRight:
                    positionBeforeAction.X++;
                    GetDamage(player, bomb);
                    break;
                case ActionType.MoveDown:
                    positionBeforeAction.Y--;
                    GetDamage(player, bomb);
                    break;
                case ActionType.MoveLeft:
                    positionBeforeAction.X--;
                    GetDamage(player, bomb);
                    break;
                default:
                    break;
            }

            return positionBeforeAction;
        }
        private void GetDamage(IPlayer player, IPlaceableBomb bomb)
        {  
            int i = 0;
            while (i < bomb.Bombs.Count)
            {
                if (bomb.Bombs[i].Position.X == player.Position.X & bomb.Bombs[i].Position.Y == player.Position.Y)
                {
                    player.HealthPoints -= bomb.Damage;
                }
                i++;
            }
        }
    }
}
