﻿using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSkillsQuery();

            var skills = await _mediator.Send(query);

            return Ok(skills);
        }
    }
}
