using CrowdFoundAppTeam3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrowdFoundAppTeam3.Domain;

namespace CrowdFoundAppTeam3.Pages.ProjectCreators
{
    public class CreateModel : PageModel
    {
        private CrowdFundDbContext? _context { get; }

        [BindProperty] public ProjectCreator? ProjectCreator { get; set; }

        public CreateModel(CrowdFundDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPost()
        {
            _context.ProjectCreators.Add(ProjectCreator);
            await _context.SaveChangesAsync();
            return RedirectToPage("/ProjectCreators/Create");
        }
    }
}