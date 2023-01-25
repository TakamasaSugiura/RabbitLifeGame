using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RabbitLifeGame.Pages;

public class LifeModel : PageModel
{
    private readonly ILogger<LifeModel> _logger;

    public string Bg { get; private set; } = string.Empty;

    public LifeModel(ILogger<LifeModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(GetRequest getRequest)
    {
        Bg = getRequest.Bg;
    }

    [BindProperties]
    public class GetRequest
    {
        public string Rule { get; set; } = string.Empty;
        public string Bg { get; set; } = string.Empty;
    }
}
