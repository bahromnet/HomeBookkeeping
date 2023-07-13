using Application.UseCases.Categories.Commands;
using Application.UseCases.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeBookkeeping.Controllers;
public class CategoryController : Controller
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: CategoryController
    public async Task<IActionResult> Index()
    {
        var data = await _mediator.Send(new GetAllCategoriesQuery());
        return View(data);
    }

    // GET: CategoryController/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        var detail = await _mediator.Send(new GetByIdCategoryQuery { CategoryId = id });
        if (detail is null) return View("NotFound");
        return View(detail);
    }

    // GET: CategoryController/Create
    public ActionResult Create() => View();

    // POST: CategoryController/Create
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

    // GET: CategoryController/Edit/5
    public async Task<IActionResult> Edit(Guid id)
    {
        var categoryDetails = await _mediator.Send(new GetByIdCategoryQuery { CategoryId = id});
        if (categoryDetails is null) return View("NotFound");
        return View(categoryDetails);
    }

    // POST: CategoryController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromForm] UpdateCategoryCommand updateCategory)
    {
        if (!ModelState.IsValid)
        {
            return View(updateCategory);
        }
        await _mediator.Send(updateCategory);
        return View(nameof(Index));
    }

    // GET: CategoryController/Delete/5
    public async Task<IActionResult> Delete(Guid id)
    {
        var categoryDetails = await _mediator.Send(new GetByIdCategoryQuery { CategoryId = id });
        if (categoryDetails is null) return View("NotFound");
        return View(categoryDetails);
    }

    // POST: CategoryController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteCategoryCommand deleteCategory)
    {
        var categoryDetails = await _mediator.Send(new GetByIdCategoryQuery { CategoryId = deleteCategory.CategoryId });
        if (categoryDetails is null) return View("NotFound");
        await _mediator.Send(deleteCategory);
        return RedirectToAction(nameof(Index));
    }
}
