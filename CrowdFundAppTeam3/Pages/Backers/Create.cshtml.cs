using CrowdFoundAppTeam3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrowdFoundAppTeam3.Domain;
using CrowdFoundAppTeam3.DTOs;
using CrowdFoundAppTeam3.Interface;
using Microsoft.EntityFrameworkCore;

namespace CrowdFoundAppTeam3.Pages.Backers
{
    public class CreateModel : PageModel
    {
        private readonly IBacker service;
        private CrowdFundDbContext Context { get; }
        [BindProperty] public Backer Backer { get; set; }

        public CreateModel(CrowdFundDbContext context)
        {
            Context = context;
        }

        public async Task<ActionResult> OnPost()
        {
            Context.Backers.Add(Backer);
            await Context.SaveChangesAsync();
            return RedirectToPage("/Backers/Create");
        }
    }
    }

