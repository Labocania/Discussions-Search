using ForumSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ForumSearch.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public List<Category> Categories { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, CategoryDeserializer deserealizer)
        {
            _logger = logger;
            Categories = deserealizer.Categories;
        }

        public void OnGet()
        {

        }
    }
}
