using CrowdFoundAppTeam3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrowdFoundAppTeam3.Domain;
using Microsoft.EntityFrameworkCore;
using CrowdFoundAppTeam3.DTOs;

namespace CrowdFoundAppTeam3.Pages.Backers
{
    public class DetailsModel : PageModel
    {
        private CrowdFundDbContext Context { get; }
        public Backer? Backer { get; set; }
       

        public DetailsModel(CrowdFundDbContext context)
        {
            Context = context;
        }

        //public async Task<ActionResult<List<BackerDto>>> OnGet()
        //{
        //    return await Context.Backers
        //   .Include(backer => backer.BackerId)
        //   .Select(backer => backer.ConvertBacker())
        //   .ToListAsync();

        //}
        public async Task<ActionResult> OnGet()
        {
            var Backer = await Context.Backers.ToListAsync();
            if (Backer is null) return BadRequest();
            //ActorMovies = await Context.Movies.Where(m => m.Actors.Contains(Actor)).ToListAsync();
            return Page();
        }
    }

}


