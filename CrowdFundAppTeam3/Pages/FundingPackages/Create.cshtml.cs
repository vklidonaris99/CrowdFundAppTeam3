using CrowdFoundAppTeam3.Data;
using CrowdFoundAppTeam3.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrowdFoundAppTeam3.Pages.FundingPackages
{
    public class CreateModel : PageModel
    {
        private CrowdFundDbContext Context { get; }
        
        [BindProperty] public FundingPackage FundingPackages { get; set; }

        public CreateModel(CrowdFundDbContext context)
        {
            Context = context;
        }

        public async Task<ActionResult> OnPost()
        {
            Context.FundingPackages.Add(FundingPackages);
            await Context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
