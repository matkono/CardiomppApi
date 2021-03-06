﻿using HealthSup.Application.DataContracts.v1.Requests.DecisionEngine;
using HealthSup.Application.DataContracts.v1.Requests.Node;
using HealthSup.Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HealthSup.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class DecisionEngineController : ControllerBase
    {
        public DecisionEngineController
        (
            IDecisionEngineApplicationService decisionEngineService
        )
        {
            DecisionEngineService = decisionEngineService ?? throw new ArgumentNullException(nameof(decisionEngineService));
        }

        IDecisionEngineApplicationService DecisionEngineService { get; set; }

        [HttpPost]
        [Route("node/question/answer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AnswerQuestion
        (
            [FromBody]AnswerQuestionRequest argument
        )
        {
            var response = await DecisionEngineService.AnswerQuestion(argument);

            if (response.Errors != null && response.Errors.Any())
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        [Route("node/action/confirm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConfirmAction
        (
            [FromBody]ConfirmActionRequest argument
        )
        {
            var response = await DecisionEngineService.ConfirmAction(argument);

            if (response.Errors != null && response.Errors.Any())
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        [Route("node/previous")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPreviousNode
        (
            [FromBody]GetPreviousNodeRequest argument
        )
        {
            var response = await DecisionEngineService.GetPreviousNode(argument);

            if (response.Errors != null && response.Errors.Any())
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        [Route("node/decision/confirm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConfirmDecision
        (
            [FromBody]ConfirmDecisionRequest argument
        )
        {
            var response = await DecisionEngineService.ConfirmDecision(argument);

            if (response.Errors != null && response.Errors.Any())
                return BadRequest(response);

            return NoContent();
        }
    }
}