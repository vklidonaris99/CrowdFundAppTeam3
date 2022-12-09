using CrowdFoundAppTeam3.Data;
using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrowdFoundAppTeam3.Pages.Backers
{
    public class IndexModel : PageModel
    {
        public CrowdFundDbContext Context { get; }
        //List<Backer> Backers { get; }

        public IndexModel(CrowdFundDbContext context, List<Backer> backers )
        {
            Context = context;
            //Backers = backers;
        }


        //public async Task<List<ActionResult>?> OnGet()
        //{
        //    backers = await Context.Backers.ToListAsync();
        //    return backers;
        //}
        public async Task<List<BackerDto>> OnGet()
        {
            return await Context.Backers
                .Include(backer => backer.BackerId)
                .Select(backer => backer.ConvertBacker())
                .ToListAsync();
        }
    }
}
