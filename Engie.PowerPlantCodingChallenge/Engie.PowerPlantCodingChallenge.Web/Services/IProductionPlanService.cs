using Engie.PowerPlantCodingChallenge.Models;
using Engie.PowerPlantCodingChallenge.Requests;

namespace Engie.PowerPlantCodingChallenge.Services;

public interface IProductionPlanService
{
    List<PowerPlantProduction> Generate(GetProductionPlanRequest request);
}
