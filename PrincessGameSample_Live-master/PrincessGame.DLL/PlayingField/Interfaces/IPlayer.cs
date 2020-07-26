namespace PrincessGame.DLL.PlayingField.Interfaces
{
    public interface IPlayer : IPlaceble
    {
        int HealthPoints { get; set; }

        Position Position { get; set; }
    }
}
