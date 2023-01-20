using System.Timers;
using Timer = System.Timers.Timer;

namespace RabbitLifeGame;

public class GameCore : IDisposable
{
    const int _countX = 1024;
    const int _countY = 1024;
    private readonly Timer _timer;
    private readonly byte[,] _data = new byte[_countY, _countX];
    private bool _disposedValue;

    public GameCore()
    {
        _timer = new Timer(1000);
        _timer.Elapsed += TimerElapsed;
    }

    private void TimerElapsed(object? sender, ElapsedEventArgs e)
    {
    }

    public void Start()
    {
        _timer.Start();
    }

    public void Stop()
    {
        _timer.Stop();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                Stop();
                _timer.Dispose();
            }

            // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
            // TODO: 大きなフィールドを null に設定します
            _disposedValue = true;
        }
    }

    // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
    // ~GameCore()
    // {
    //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public void Init()
    {
        for(var y = 0; y < _countY; y++)
        {
            for(var x = 0; x < _countX; x++)
            {
                _data[y, x] = (byte)(Random.Shared.Next(0, 5) == 1 ? 1 : 0);
            }
        }
    }

    public void Next()
    {
        var buffer = new byte[_countX, _countY];
        for (var y = 0; y < _countY; y++)
        {
            for (var x = 0; x < _countX; x++)
            {
                var count = 0;
                count += x > 0 && y > 0 ? _data[y - 1, x - 1] : 0;
                count += x < _countX - 1 && y > 0 ? _data[y - 1, x + 1] : 0;
                count += x > 0 && y < _countY - 1 ? _data[y + 1, x - 1] : 0;
                count += x < _countX - 1 && y < _countY - 1 ? _data[y + 1, x + 1] : 0;
                count += x > 0 ? _data[y, x - 1] : 0;
                count += x < _countX - 1 ? _data[y, x + 1] : 0;
                count += y > 0 ? _data[y - 1, x] : 0;
                count += y < _countY - 1 ? _data[y + 1, x] : 0;
                var nextValue = (byte)(count == 3 || (_data[y, x] == 1 && count == 2) ? 1 : 0);
                buffer[y, x] = nextValue;
            }
        }
        Buffer.BlockCopy(buffer, 0, _data, 0, buffer.Length);  
    }
    
    public byte[,] GetData(int x, int y, int width, int height)
    {
        var data = new byte[height, width];
        for (var cntY = 0; cntY < height; cntY++)
        {
            for (var cntX = 0; cntX < width; cntX++)
            {
                data[cntY, cntX] = _data[x + cntX, y + cntY];
            }
        }
        return data;
    }
}
