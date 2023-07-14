using Application.Common.Models;
using Application.UseCases.Bookkepings.Command;
using Application.UseCases.Bookkepings.Queries;
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
        if (ModelState.IsValid)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
        return View(command);
    }

    public async Task<IActionResult> Update(Guid id)
    {
        var foundBookkeepingDto = await _mediator.Send(new GetByIdBookkeepingQueries()
        {
            BookkeepingId = id
        });

        return await Task.FromResult(View(foundBookkeepingDto));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteBookkeepingCommand() { Id = id });
        return RedirectToAction("Index");
    }


    [HttpPost]
    public async Task<IActionResult> Update(BookkeepingGetDto bookkeepingGetDto)
    {
        if (ModelState.IsValid)
        {
            var updateCommand = new UpdateBookkeepingCommand()
            {
                BookkeepingId = bookkeepingGetDto.BookkeepingId,
                Amount = bookkeepingGetDto.Amount,
                CategoryId = bookkeepingGetDto.Category.CategoryId,
                Comment = bookkeepingGetDto.Comment
            };
            await _mediator.Send(updateCommand);
            return RedirectToAction("Index");

        }
        return View(bookkeepingGetDto);
    }


    public async Task<IActionResult> ViewDetails(Guid id)
    {
        var foundBookkeeping = await _mediator.Send(new GetByIdBookkeepingQueries() { BookkeepingId = id });
        return View(foundBookkeeping);
    }

}
