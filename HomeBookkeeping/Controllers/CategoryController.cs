using Application.UseCases.Bookkepings.Queries;
using Application.UseCases.Categories.Commands;
using Application.UseCases.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeBookkeeping.Controllers;
[Authorize]
public class CategoryController : Controller
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _mediator.Send(new GetAllCategoriesQuery());
        return View(data);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var detail = await _mediator.Send(new GetByIdCategoryQuery { CategoryId = id });
        if (detail is null) return View("NotFound");
        return View(detail);
    }

    public async Task<IActionResult> Create()
    {
        return await Task.FromResult(View());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] CreateCategoryCommand createCategory)
    {
        if (!ModelState.IsValid)
        {
            return View(createCategory);
        }
        await _mediator.Send(createCategory);
        return View(nameof(Index));
    }

    public async Task<IActionResult> Update(Guid id)
    {
        var foundCategoryDto = await _mediator.Send(new GetByIdCategoryQuery()
        {
            CategoryId = id
        });

        return await Task.FromResult(View(foundCategoryDto));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateCategoryCommand updateCategory)
    {
        if (!ModelState.IsValid)
        {
            return View(updateCategory);
        }
        await _mediator.Send(updateCategory);
        return View(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteCategoryCommand() { CategoryId = id });
        return RedirectToAction(nameof(Index));
    }
}
