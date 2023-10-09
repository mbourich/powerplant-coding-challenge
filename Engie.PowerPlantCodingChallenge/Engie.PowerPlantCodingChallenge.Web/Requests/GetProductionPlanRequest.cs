using Engie.PowerPlantCodingChallenge.Models;

namespace Engie.PowerPlantCodingChallenge.Requests;

public class GetProductionPlanRequest
{
    public int Load { get; set; }

    public Fuels Fuels { get; set; }

    public IEnumerable<PowerPlant> Powerplants { get; set; }
}
