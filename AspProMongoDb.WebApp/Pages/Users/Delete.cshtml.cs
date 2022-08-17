using AspProMongoDb.WebApp.Entities;
using AspProMongoDb.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspProMongoDb.WebApp.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty] public User User { get; set; }
        public IActionResult OnGet(Guid id)
        {
            User = _userService.GetById(id);
            if (User==null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(Guid id)
        {
            _userService.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}
