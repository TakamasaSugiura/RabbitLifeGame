using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RabbitLifeGame.Pages;

public class Game1Model : PageModel
{
    public int Size { get; private set; } = 3;

    public string Bg { get; private set; } = "white";

    public string C1 { get; private set; } = "black";
    public string C2 { get; private set; } = "whitesmoke";
    public string C3 { get; private set; } = "lavender";
    public string C4 { get; private set; } = "darkslateblue";
    public string Tc1 { get; private set; } = "orangered";
    public string Tc2 { get; private set; } = "midnightblue";


    public void OnGet(GetRequest request)
    {
        if (!int.TryParse(request.Size, out var size))
        {
            size = 3;
        }
        if (size is >= 3 and <= 10)
        {
            Size = size;
        }
        Bg = request.Bg;
        C1 = request.C1;
        C2 = request.C2;
        C3 = request.C3;
        C4 = request.C4;
        Tc1 = request.Tc1;
        Tc2 = request.Tc2;
    }

    [BindProperties]
    public class GetRequest
    {
        public string Bg { get; set; } = "white";
        public string Fg { get; set; } = "white";
        public string Size { get; set; } = "3";
        public string C1 { get; set; } = "black";
        public string C2 { get; set; } = "whitesmoke";
        public string C3 { get; set; } = "lavender";
        public string C4 { get; set; } = "darkslateblue";
        public string Tc1 { get; set; } = "orangered";
        public string Tc2 { get; set; } = "midnightblue";
    }
}
