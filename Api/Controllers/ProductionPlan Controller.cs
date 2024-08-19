using Api.DTO;
using Domain.DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionPlan_Controller : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] RequestDTO model)
        {
            if (model == null)
            {
                return BadRequest("Invalid data.");
            }

            var domainService = new PowerPlantService(model.ToLoad(), model.ToFuels, model.ToPowerPlant());

            return Ok(domainService.GetMeritOrder().Select(x => new { name = x.Key, p = x.Value }));
        }
    }
}
