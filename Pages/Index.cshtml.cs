using Leap_Year.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Leap_Year.Interface;
using Leap_Year.ViewModels.LeapYear;

namespace Leap_Year.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILeapYearInterface _personService;
        
        public ListLeapYearForListVM Records { get; set; }
        [BindProperty]
        public LeapYear LeapYear { get; set; }
        //public IQueryable<LeapYear> Records { get; set; }
        public IndexModel(ApplicationDbContext context, ILeapYearInterface personService)
        {
            _dbContext = context;
            _personService = personService;
        }
        public void OnGet()
        {
            Records = _personService.GetActivePeopleForList();
        }
        [AllowAnonymous]
        public IActionResult OnPost()
        {
            LeapYear.Result = _personService.GetLeapYearInfo();
            LeapYear.EmailAddress = User.FindFirstValue(ClaimTypes.Email);
            LeapYear.IdAddress = User.FindFirstValue(ClaimTypes.NameIdentifier);
            LeapYear.SearchTime = DateTime.Now;
            _dbContext.LeapYear.Add(LeapYear);
            _dbContext.SaveChanges();
            Records = _personService.GetActivePeopleForList();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}