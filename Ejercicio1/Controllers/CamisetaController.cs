using TodoApi.Models;
using TodoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/Camiseta")]
public class CamisetaController : ControllerBase
{
    public CamisetaController()
    {
    }

    [HttpGet]
    public ActionResult<List<Camiseta>> GetAll()
    {
        List<Camiseta> camisetas = CamisetaService.GetAll();

        if (camisetas.Count == 0)
        {
            return NoContent(); 
        }

        return camisetas;
    }

    [HttpGet("{id}")]
    public ActionResult<Camiseta> Get(int id)
    {
        var camiseta = CamisetaService.Get(id);

        if (camiseta == null)
            return NotFound();

        return camiseta;
    }

    [HttpPost]
    public IActionResult Create(Camiseta camiseta)
    {
        CamisetaService.Add(camiseta);
        return CreatedAtAction(nameof(Get), new { id = camiseta.Id }, camiseta);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Camiseta camiseta)
    {
        if (id != camiseta.Id)
            return Conflict();

        var camisetaexistente = CamisetaService.Get(id);
        if (camisetaexistente is null)
            return NotFound();

        CamisetaService.Update(camiseta);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var camiseta = CamisetaService.Get(id);

        if (camiseta is null)
            return NotFound();

        CamisetaService.Delete(id);

        return NoContent();
    }

}
