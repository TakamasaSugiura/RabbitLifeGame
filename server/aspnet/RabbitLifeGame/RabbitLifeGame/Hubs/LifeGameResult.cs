namespace RabbitLifeGame.Hubs;

public record LifeGameResult(int X, int Y, int Width, int Height, byte[] Data)
{
    public DateTime DateTime { get; } = DateTime.Now;
}
