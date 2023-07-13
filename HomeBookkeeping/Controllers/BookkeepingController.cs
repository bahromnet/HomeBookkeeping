using Application.UseCases.Bookkepings.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeBookkeeping.Controllers;
[Authorize]
public class BookkeepingController : Controller
{
    private IMediator _mediator;

    public BookkeepingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        return await Task.FromResult(View());
    }

    public async Task<IActionResult> Create()
    {
        return await Task.FromResult(View());
    }
    
    [HttpPost]    
    public async Task<IActionResult> Create(CreateBookkeepingCommand command)
    {
        if(ModelState.IsValid)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
        return View(command);
    }
    //[HttpPost]
    //public async Task<IActionResult> Update()
    //{

    //}

}
