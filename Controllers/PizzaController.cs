using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private readonly PizzaService _pizzaService;

    public PizzaController(PizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    // GET all action
    [HttpGet(
        "List",
        Name = "Pizza List"
    )]
    public async Task<List<Pizza>> Get() =>
        await _pizzaService.GetAsync();

    // GET by Id action
    [HttpGet(
        "{id:length(24)}",
        Name = "Pizza Details"
    )]
    public async Task<ActionResult<Pizza>> Get(string id)
    {
        var pizza = await _pizzaService.GetAsync(id);

        if (pizza is null)
        {
            return NotFound();
        }

        return pizza;
    }

    // POST action
    [HttpPost(
        "Create",
        Name = "Add New Pizza"
    )]
    public async Task<IActionResult> Post(Pizza newPizza)
    {
        await _pizzaService.CreateAsync(newPizza);
        return CreatedAtAction(nameof(Get), new { id = newPizza.Id }, newPizza);
    }

    // PUT action
    [HttpPut(
        "{id:length(24)}",
        Name = "Update Pizza"
    )]
    public async Task<IActionResult> Update(string id, Pizza updatedPizza)
    {
        var pizza = await _pizzaService.GetAsync(id);

        if (pizza is null)
        {
            return NotFound();
        }

        updatedPizza.Id = pizza.Id;
        await _pizzaService.UpdateAsync(id, updatedPizza);
        return NoContent();
    }

    // DELETE action
    [HttpDelete(
        "{id:length(24)}",
        Name = "Delete Pizza"
    )]
    public async Task<IActionResult> Delete(string id)
    {
        var pizza = await _pizzaService.GetAsync(id);

        if (pizza is null)
        {
            return NotFound();
        }

        await _pizzaService.RemoveAsync(id);
        return NoContent();
    }
}