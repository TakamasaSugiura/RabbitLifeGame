using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RabbitLifeGame.Pages;

public class Game1Model : PageModel
{
    public int Size { get; private set; } = 3;

    public void OnGet(GetRequest request)
    {
        if (request.Size is >= 3 and <= 10)
        {
            Size = request.Size;
        }
    }

    [BindProperties]
    public class GetRequest
    {
        public string Bg { get; set; } = string.Empty;
        public string Fg { get; set; } = "white";
        public int Size { get; set; } = 3;
    }
}
