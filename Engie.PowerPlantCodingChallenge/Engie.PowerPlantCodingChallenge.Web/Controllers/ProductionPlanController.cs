using Engie.PowerPlantCodingChallenge.Requests;
using Engie.PowerPlantCodingChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Engie.PowerPlantCodingChallenge.Controllers;

[ApiController]
public class ProductionPlanController : ControllerBase
{
    private readonly IProductionPlanService _productionPlanService;

    public ProductionPlanController(IProductionPlanService productionPlanService)
    {
        _productionPlanService = productionPlanService;
    }

    [HttpPost("productionplan")]
    public IActionResult GetProductionPlan([FromBody] GetProductionPlanRequest request)
        => Ok(_productionPlanService.Generate(request));
}
