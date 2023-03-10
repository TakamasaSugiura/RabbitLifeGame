using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RabbitLifeGame.Pages;

public class LifeModel : PageModel
{
    private readonly ILogger<LifeModel> _logger;

    public string Bg { get; private set; } = string.Empty;
    public string Fg { get; private set; } = "white";
    public bool NoRabbit { get; private set; } = false;

    public int[] BirthCondition { get; private set; } = new int[] { 3 };
    public int[] LiveCondition { get; private set; } = new int[] { 2, 3 };
    public int CountX { get; private set; } = 32;
    public int CountY { get; private set; } = 32;


    public LifeModel(ILogger<LifeModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(GetRequest request)
    {
        Bg = request.Bg;
        Fg = request.Fg;
        NoRabbit = request.NoRabbit;
        if (!string.IsNullOrEmpty(request.Rule))
        {
            var splited = request.Rule.Split("_");
            try
            {
                if (splited.Length == 2)
                {
                    var birthCondition = splited[0].Select(x => int.Parse(x.ToString())).ToArray();
                    var liveCondition = splited[1].Select(x => int.Parse(x.ToString())).ToArray();
                    BirthCondition = birthCondition;
                    LiveCondition = liveCondition;
                }
            }
            catch { }
        }
        if (16 <= request.CntX && request.CntX <= 400)
        {
            CountX = request.CntX;
        }
        if (16 <= request.CntY && request.CntY <= 400)
        {
            CountY = request.CntY;
        }
    }

    [BindProperties]
    public class GetRequest
    {
        public string Rule { get; set; } = string.Empty;
        public string Bg { get; set; } = string.Empty;
        public string Fg { get; set; } = "white";
        public bool NoRabbit { get; set; } = false;
        public int CntX { get; set; } = 32;
        public int CntY { get; set; } = 32;
    }
}
