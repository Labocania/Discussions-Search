using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ForumSearch.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public CategoryDeserializer Categories { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, CategoryDeserializer deserealizer)
        {
            _logger = logger;
            Categories = deserealizer;
        }

        public void OnGet()
        {

        }
    }
}
