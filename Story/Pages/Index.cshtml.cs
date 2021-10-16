using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Story.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Story.Pages
{
    public class IndexModel : PageModel
    {
        private readonly StoryDataBaseContext Database;
        public IEnumerable<DBModels.Story> Storys;

        [BindProperty]
        public string searchString { get; set; }

        public IndexModel(StoryDataBaseContext context)
        {
            Database = context;
        }

        public void OnGet()
        {
            Storys = Database.Story;
        }

        public async Task<IActionResult> OnPost()
        {
            Storys = Database.Story.Where( x => EF.Functions.Like(x.Header, $"%{searchString}%") );
            return Page();
        }
    }
}
