﻿using Cardiompp.Application.DataContracts.v1.Requests.Doctor;
using Cardiompp.Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cardiompp.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class DoctorController : ControllerBase
    {
        IDoctorService DoctorService { get; set; }

        public DoctorController(IDoctorService doctorService)
        {
            DoctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
        }

        /// <summary>
        /// Get merchant by crm
        /// </summary>
        /// <param name="crm">Doctor identifier</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{crm}")]
        public async Task<IActionResult> GetByCrm(string crm)
        {
            var response = await DoctorService.GetByCrm(crm);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        /// <summary>
        /// Get merchant by email and password.
        /// </summary>
        /// <param name="loginRequest">Login request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] GetDoctorByEmailAndPasswordRequest loginRequest)
        {
            var response = await DoctorService.GetByEmailAndPassword(loginRequest);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }
    }
}