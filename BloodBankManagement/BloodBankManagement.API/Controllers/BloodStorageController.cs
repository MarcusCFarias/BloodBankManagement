using BloodBankManagement.Application.Features.BloodStorage.Command.UpdateStorage;
using BloodBankManagement.Application.Features.BloodStorage.Queries.GetStorageReport;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BloodBankManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodStorageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BloodStorageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStorageTest([FromBody] UpdateStorageCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result.Error);
            //return Ok();
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetStorageReport()
        {
            var query = new GetStorageReportQuery();
            var result = await _mediator.Send(query);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Blood Type,Rh Factor,Quantity ML");
            result.Data.ToList().ForEach(item => stringBuilder.AppendLine($"{item.BloodType},{item.RhFactor},{item.QuantityMl}"));
            return Content(stringBuilder.ToString(), "text/csv");
        }       
    }
}
