using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Story.DBModels;

namespace Story.Pages.tempmodel
{
    public class CreateModel : PageModel
    {
        private readonly Story.DBModels.StoryDataBaseContext _context;

        public CreateModel(Story.DBModels.StoryDataBaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdentityUser"] = new SelectList(_context.AspNetUsers, "Id", "Id");
        ViewData["Stype"] = new SelectList(_context.StoryType, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public DBModels.Story Story { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Story.Add(Story);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
