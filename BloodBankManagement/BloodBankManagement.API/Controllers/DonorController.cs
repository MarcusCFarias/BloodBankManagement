﻿using BloodBankManagement.Application.Features.Donors.Commands.CreateDonorCommand;
using BloodBankManagement.Application.Features.Donors.Queries.GetDonorByIdQuery;
using BloodBankManagement.Application.Features.Donors.Queries.GetDonorHistory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
                return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);

            return BadRequest(result.Error);
        }
        [HttpGet("history")]
        public async Task<IActionResult> GetDonorHistory([FromQuery] int donorId)
        {
            var query = new GetDonorHistoryQuery(donorId);
            var result = await _mediator.Send(query);

            if (result.IsSuccess)
                return Ok(result.Data);

            return NotFound(result.Error);
        }
    }
}
