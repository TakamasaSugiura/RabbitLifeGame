using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RabbitLifeGame.Pages;

public class RandModel : PageModel
{
    public bool Hex { get; private set; }
    public int Max { get; private set; }
    public int Min { get; private set; } = 0;
    public int Cols { get; private set; } = 10;
    public int Rows { get; private set; } = 10;
    public bool Zpad { get; private set; } = true;
    public int Pad { get; private set; } = 2;

    public void OnGet(GetRequest request)
    {
        Max = request.Hex ? 0xFF : 99;
        if (request.Max.HasValue)
        {
            Max = request.Max.Value;
        }
        if (request.Min.HasValue)
        {
            Min = request.Min.Value;
        }
        if(Max < Min)
        {
            var tmp = Max;
            Max = Min;
            Min = tmp;
        }
        if (request.Cols is >= 1 and <= 100)
        {
            Cols = request.Cols;
        }
        if (request.Rows is >= 1 and <= 100)
        {
            Rows = request.Rows;
        }
        Hex = request.Hex;
        Zpad = request.Zpad;
        Pad = request.Pad;
    }


    [BindProperties]
    public class GetRequest
    {
        public string Bg { get; set; } = "white";
        public string Fg { get; set; } = "black";
        public int? Max { get; set; } = null;
        public int? Min { get; set; } = null;
        public bool Hex { get; set; } = false;
        public int Cols { get; set; } = 10;
        public int Rows { get; set; } = 10;
        public bool Zpad { get; set; } = true;
        public int Pad { get; set; } = 2;
    }
}
