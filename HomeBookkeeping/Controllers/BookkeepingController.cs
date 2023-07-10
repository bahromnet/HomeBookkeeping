using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeBookkeeping.Controllers;
public class BookkeepingController : Controller
{
    [Authorize]
    public async Task<IActionResult> Index()
    {
        return await Task.FromResult(View());
    }
}
