using CrowdFoundAppTeam3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;

namespace CrowdFoundAppTeam3.Pages.Backers
{
    public class CreateModel : PageModel
    {
        private CrowdFundDbContext Context { get; }
        public int ActorCount { get; set; }
        [BindProperty] public Backer Backer { get; set; }

        public CreateModel(CrowdFundDbContext context)
        {
            Context = context;
        }

        public async Task<ActionResult<List<BackerDto>>> OnGet()
        {
            List<Backer> backers = new List<BackerDto>();  
            
        }

        public async Task<ActionResult> OnPost()
        {
            Context.Backers.Add(Backer);
            await Context.SaveChangesAsync();
            return RedirectToPage("/Backers/Create");
        }
    }
    }

