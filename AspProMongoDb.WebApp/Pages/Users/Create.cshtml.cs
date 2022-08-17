using AspProMongoDb.WebApp.Entities;
using AspProMongoDb.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspProMongoDb.WebApp.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;

        public CreateModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _userService.Insert(User);

            return RedirectToPage("./Index");
        }

    }
}
