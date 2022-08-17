using AspProMongoDb.WebApp.Entities;
using AspProMongoDb.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspProMongoDb.WebApp.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;

        public EditModel(IUserService userService)
        {
            _userService = userService;
        }

        public User User { get; set; }  
        public IActionResult OnGet(Guid id)
        {
            User = _userService.GetById(id);
            if (User==null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _userService.Update(User);
            return RedirectToPage("./Index");
        }
    }
}
