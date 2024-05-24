using BloodBankManagement.Application.Features.Donors.Commands.CreateDonorCommand;
using BloodBankManagement.Application.Features.Donors.Queries.GetAllDonor;
using BloodBankManagement.Application.Features.Donors.Queries.GetDonorByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, int pageSize = 10)
        {
            var query = new GetAllDonorsQuery(page, pageSize);
            var result = await _mediator.Send(query);

            if (result.IsSuccess)
                return Ok(result.Data);

            return NotFound(result.Error);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetDonorByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result.IsSuccess)
                return Ok(result.Data);

            return NotFound(result.Error);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDonorCommand command)
        {
            var donorId = await _mediator.Send(command);

            return Ok(donorId);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(/*[FromBody] UpdateDonorCommand command*/)
        {
            //var donorId = await _mediator.Send(command);

            return Ok();
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(/*[FromBody] DeleteDonorCommand command*/)
        {
            //var donorId = await _mediator.Send(command);

            return Ok();
        }
    }
}
