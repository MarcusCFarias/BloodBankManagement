using BloodBankManagement.Application.Features.Donations.Commands.DonateBloodCommand;
using BloodBankManagement.Application.Features.Donations.Queries.GetDonorHistory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BloodBankManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DonateBloodCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result.Error);
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetHistory()
        {
            var query = new GetDonationHistoryQuery();
            var result = await _mediator.Send(query);

            if (result.IsSuccess)
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Full Name,Blood Type,Rh Factor,Donation Date,Quantity ML");
                result.Data.ToList().ForEach(item => stringBuilder.AppendLine($"{item.FullName},{item.BloodType},{item.RhFactor},{item.DonationDate},{item.QuantityMl}"));
                return Content(stringBuilder.ToString(), "text/csv");
            }

            return NotFound(result.Error);
        }
    }
}
