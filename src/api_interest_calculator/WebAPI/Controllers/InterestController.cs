using Application.InterestQueries.CalculatorQuery;
using CQRSHelper._Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [Route("api/juros")]
    [Produces("application/json")]
    [ApiController]
    public class InterestController : ApiController
    {
        private readonly IMediator _mediator;
        public InterestController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        [HttpGet("calculajuros")]
        [SwaggerResponse(200, type: typeof(decimal))]
        public async Task<ActionResult<decimal>> CalculateInterest([FromQuery] CalculatorQuery query)
        {
            var response = await _mediator.Send(query);          
            if(response.Status)
                return Ok(response.TotalText);
            return BadRequest(response);
        }
        [HttpGet("/showmethecode")]
        public string ShowMeTheCode([FromServices] IConfiguration configuration)
        {
            return configuration["github"]; 
        }
        [HttpGet("calculajuros/detalhes")]
        [SwaggerResponse(200, type: typeof(decimal))]
        public async Task<ActionResult<decimal>> CalculateInterestInfo([FromQuery] CalculatorQuery query)
        {
            return Result(await _mediator.Send(query));
        }
        private ActionResult Result(Response response)
        {
            if (response.Status)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
