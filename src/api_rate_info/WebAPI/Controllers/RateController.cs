using Application.Interest.RateQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [Route("api/taxa")]
    [ApiController]
    public class RateController : ApiController
    {
        private readonly IMediator _mediator;
        public RateController(IMediator mediator)
        {
            this._mediator = mediator;
        }
       

        [HttpGet("/taxaJuros")]
        [SwaggerResponse(200, type: typeof(decimal))]
        public async Task<ActionResult<decimal>> GetRateValue()
        {
            var response = await _mediator.Send(new RateQuery());
            return Ok(response.MonthlyRate);
        }
        [HttpGet()]
        [SwaggerResponse(200, type: typeof(decimal))]
        public async Task<ActionResult<RateQueryResponse>> GetRate()
        {
            return Ok(await _mediator.Send(new RateQuery()));
        }
    }
}
