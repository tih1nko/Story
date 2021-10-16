using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Story.NewUser;

namespace Story.Pages
{
    [Authorize(Roles = "EDITOR")]
    public class StoryCreatorModel : PageModel
    {
        [BindProperty]
        public DBModels.Story Story { get; set; }

        private readonly Story.DBModels.StoryDataBaseContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public StoryCreatorModel(Story.DBModels.StoryDataBaseContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["Stype"] = new SelectList(_context.StoryType, "Id", "Stype");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Story.IdentityUser = _userManager.GetUserId(User);

            _context.Story.Add(Story);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
