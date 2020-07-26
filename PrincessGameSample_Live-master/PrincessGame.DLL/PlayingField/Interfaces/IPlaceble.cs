namespace PrincessGame.DLL.PlayingField.Interfaces
{
    public interface IPlaceble
    {
        int ViewPriority { get; }

        bool Place(GameField gameField, Position position);
    }
}
