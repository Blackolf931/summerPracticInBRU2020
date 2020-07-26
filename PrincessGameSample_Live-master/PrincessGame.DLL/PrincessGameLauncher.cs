using PrincessGame.DLL.Helpers;
using PrincessGame.DLL.PlayingField;
using PrincessGame.DLL.PlayingField.Interfaces;
using PrincessGame.DLL.PlayingField.Members;
using System;
using System.Collections.Generic;

namespace PrincessGame.DLL
{
    public class PrincessGameLauncher
    {
        private readonly ActionPerformer _actionPerformer;
        public readonly FieldFiller _fieldFiller;
        int countBombs = 10;

        public PrincessGameLauncher()
        {
            _actionPerformer = new ActionPerformer();
            _fieldFiller = new FieldFiller();
        }

        public GameData GetStartData(
            Position startPlayerPosition,
            Position princessPosition,
            
            int maxPlayerHp,
            int gameFieldHeight,
            int gameFiledWidth)
        {
            var player = new Player()
            {
                Position = startPlayerPosition,
                HealthPoints = maxPlayerHp
            };
            var bomb1 = new List<Bomb>();
           
            var gameField = new GameField(gameFieldHeight, gameFiledWidth);

            _fieldFiller.SpawnWalls(gameField);
            _fieldFiller.SpawnPlayer(gameField, player);
            _fieldFiller.SpawnPrincess(gameField, new Princess(), princessPosition);
            _fieldFiller.SpawnBombs(gameField);
            IPlaceableBomb placeableBomb = new Bomb();
            for (int i = 0; i < countBombs; i++)
            {
                placeableBomb.Bombs.Add(GetBomb());
            }
            return new GameData()
            {
                Player = player,
                GameField = gameField,
                Bomb = placeableBomb
            };
        }
        private Bomb GetBomb()
        {
            return new Bomb();
        }

        public void PerformGameAction(ActionType actionType, GameField gameField, IPlayer player, IPlaceableBomb bomb)
        {
            _actionPerformer.Perform(actionType, gameField, player, bomb);
        }
    }
}
