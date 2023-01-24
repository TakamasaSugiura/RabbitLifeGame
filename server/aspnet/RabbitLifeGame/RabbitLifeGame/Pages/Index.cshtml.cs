using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RabbitLifeGame.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Bg { get; private set; } = string.Empty;

        public IndexModel(ILogger<IndexModel> logger)
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
}