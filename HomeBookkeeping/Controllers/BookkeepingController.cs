using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeBookkeeping.Controllers;
[Authorize]
public class BookkeepingController : Controller
{
    
    public async Task<IActionResult> Index()
    {
        return await Task.FromResult(View());
    }

    [HttpPost]
    public async Task<IActionResult> Update()
    {

    }

}
