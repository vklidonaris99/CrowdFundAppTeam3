using CrowdFoundAppTeam3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Interface;

namespace CrowdFoundAppTeam3.Pages.Projects
{
    public class CreateModel : PageModel
    {
        //private readonly IProjectService service;
        private CrowdFundDbContext Context { get; }
        
        [BindProperty] public Project Project { get; set; }

        public CreateModel(CrowdFundDbContext context)
        {
            Context = context;
        }



        public async Task<ActionResult> OnPost()
        {
            Context.Projects.Add(Project);
            await Context.SaveChangesAsync();
            return RedirectToPage("/Projects/Create");
        }
    }
}

