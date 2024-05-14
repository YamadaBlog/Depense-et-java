using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dev.Business.Interfaces;
using Dev.Common.Models;
using Dev.Common.Resources;

namespace Dev.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepensesController : ControllerBase
{
    private readonly IDepenseService _depenseService;
    private readonly IMapper _mapper;

    public DepensesController(IDepenseService depenseService, IMapper mapper)
    {
        _depenseService = depenseService;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]

    public IActionResult CreateDepense([FromBody] DepenseResource depenseCreate)
    {
        if (depenseCreate == null)
            return BadRequest(ModelState);

        // Vérifie si depense existe à partir du nom
        var depenses = _depenseService.DepenseExists(depenseCreate);

        if (depenses)
        {
            ModelState.AddModelError("", "Client doesn't exists or Depense already exists");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var depenseMap = _mapper.Map<Depense>(depenseCreate);

        if (!_depenseService.CreateDepense(depenseMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok(depenseMap);
    }

    [HttpGet("{depenseId}")]
    [ProducesResponseType(200, Type = typeof(Depense))]
    [ProducesResponseType(400)]
    public IActionResult GetDepenseById(int depenseId)
    {
        if (!_depenseService.DepenseExistsById(depenseId))
            return NotFound();

        var depense = _depenseService.GetDepenseById(depenseId);

        var mapValid = _mapper.Map<DepenseResource>(depense);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(mapValid);
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Depense>))]
    public IActionResult GetDepenses()
    {
        var depenses = _depenseService.GetDepenses();

        var mapValid = _mapper.Map<List<DepenseResource>>(depenses);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(mapValid);
    }

    [HttpPut("{depenseId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateDepense(int depenseId, [FromBody] DepenseResource updatedDepense)
    {
        if (updatedDepense == null)
            return BadRequest(ModelState);

        if (depenseId != updatedDepense.Id)
            return BadRequest(ModelState);

        if (!_depenseService.DepenseExistsById(depenseId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var depenseMap = _mapper.Map<Depense>(updatedDepense);

        if (!_depenseService.UpdateDepense(depenseMap))
        {
            ModelState.AddModelError("", "Something went wrong updating owner");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully Updated");
    }


    [HttpDelete("{depenseId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteDepense(int depenseId)
    {
        if (!_depenseService.DepenseExistsById(depenseId))
        {
            return NotFound();
        }

        var depenseToDelete = _depenseService.GetDepenseById(depenseId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_depenseService.DeleteDepense(depenseToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting depense");
        }

        return Ok("Successfully deleted");
    }
}