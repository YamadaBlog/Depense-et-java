using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dev.Business.Interfaces;
using Dev.Common.Models;
using Dev.Common.Resources;

namespace Dev.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuiviDepensesController : ControllerBase
{
    private readonly ISuiviDepenseService _suiviDepenseService;
    private readonly IMapper _mapper;

    public SuiviDepensesController(ISuiviDepenseService suiviDepenseService, IMapper mapper)
    {
        _suiviDepenseService = suiviDepenseService;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]

    public IActionResult CreateSuiviDepense([FromBody] SuiviDepenseResource suiviDepenseCreate)
    {
        if (suiviDepenseCreate == null)
            return BadRequest(ModelState);

        // Vérifie si suiviDepense existe
        var suiviDepenses = _suiviDepenseService.SuiviDepenseExists(suiviDepenseCreate);

        if (suiviDepenses)
        {
            ModelState.AddModelError("", "SuiviDepense doesn't exists or SuiviDepense already exists");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var suiviDepenseMap = _mapper.Map<SuiviDepense>(suiviDepenseCreate);

        if (!_suiviDepenseService.CreateSuiviDepense(suiviDepenseMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created");
    }

    [HttpGet("{suiviDepenseId}/depenses")]
    public IActionResult GetDepensesBySuiviDepense(int suiviDepenseId)
    {
        if (!_suiviDepenseService.SuiviDepenseExistsById(suiviDepenseId))
            return NotFound();

        var depenses = _mapper.Map<List<DepenseResource>>(
            _suiviDepenseService.GetDepensesBySuiviDepense(suiviDepenseId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(depenses);
    }

    [HttpGet("{suiviDepenseId}")]
    [ProducesResponseType(200, Type = typeof(SuiviDepense))]
    [ProducesResponseType(400)]
    public IActionResult GetSuiviDepenseById(int suiviDepenseId)
    {
        if (!_suiviDepenseService.SuiviDepenseExistsById(suiviDepenseId))
            return NotFound();

        var suiviDepense = _mapper.Map<SuiviDepenseResource>(_suiviDepenseService.GetSuiviDepenseById(suiviDepenseId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(suiviDepense);
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<SuiviDepense>))]
    public IActionResult GetSuiviDepenses()
    {
        var suiviDepenses = _mapper.Map<List<SuiviDepenseResource>>(_suiviDepenseService.GetSuiviDepenses());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(suiviDepenses);
    }

    [HttpPut("{suiviDepenseId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateSuiviDepense(int suiviDepenseId, [FromBody] SuiviDepenseResource updatedSuiviDepense)
    {
        if (updatedSuiviDepense == null)
            return BadRequest(ModelState);

        if (suiviDepenseId != updatedSuiviDepense.Id)
            return BadRequest(ModelState);

        if (!_suiviDepenseService.SuiviDepenseExistsById(suiviDepenseId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var suiviDepenseMap = _mapper.Map<SuiviDepense>(updatedSuiviDepense);

        if (!_suiviDepenseService.UpdateSuiviDepense(suiviDepenseMap))
        {
            ModelState.AddModelError("", "Something went wrong updating owner");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully Updated");
    }


    [HttpDelete("{suiviDepenseId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteSuiviDepense(int suiviDepenseId)
    {
        if (!_suiviDepenseService.SuiviDepenseExistsById(suiviDepenseId))
        {
            return NotFound();
        }

        var suiviDepenseToDelete = _suiviDepenseService.GetSuiviDepenseById(suiviDepenseId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_suiviDepenseService.DeleteSuiviDepense(suiviDepenseToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting suiviDepense");
        }

        return Ok("Successfully deleted");
    }
}