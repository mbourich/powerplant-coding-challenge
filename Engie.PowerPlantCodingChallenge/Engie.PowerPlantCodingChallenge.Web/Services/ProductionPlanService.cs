using Engie.PowerPlantCodingChallenge.Models;
using Engie.PowerPlantCodingChallenge.Requests;

namespace Engie.PowerPlantCodingChallenge.Services;

public class ProductionPlanService : IProductionPlanService
{
    private const string WindTurbine = "windturbine";

    public List<PowerPlantProduction> Generate(GetProductionPlanRequest request)
    {
        var result = new List<PowerPlantProduction>();

        var generatedPower = 0.0M;

        var remainingPowerToGenerate = 0.0M;

        var powerPlants = request.Powerplants
            .OrderByDescending(powerPlant => powerPlant.Efficiency)
            .ThenByDescending(powerPlant => powerPlant.Pmax)
            .ToList();

        var fuels = request.Fuels;

        var load = request.Load;

        foreach (var powerPlant in powerPlants)
        {
            remainingPowerToGenerate = request.Load - generatedPower;

            var powerPlantProduction = new PowerPlantProduction()
            {
                Name = powerPlant.Name
            };

            if (remainingPowerToGenerate == 0)
            {
                powerPlantProduction.P = 0.0M;
            }
            else
            {
                if (powerPlant.Type == WindTurbine)
                {
                    powerPlantProduction.P = (fuels.Wind / 100) * powerPlant.Pmax;
                }
                else
                {
                    powerPlantProduction.P = powerPlant.Pmax > remainingPowerToGenerate
                        ? powerPlantProduction.P = remainingPowerToGenerate
                        : powerPlantProduction.P = powerPlant.Pmax;
                }
            }

            generatedPower += powerPlantProduction.P;

            result.Add(powerPlantProduction);
        }

        return result;
    }
}
