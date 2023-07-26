﻿using MedSino.DataAccess.Utils;
using MedSino.Service.Dtos.Doctors;
using MedSino.Service.Dtos.Users;
using MedSino.Service.Interfaces.Users;
using MedSino.Service.Validators.Dtos.Doctors;
using MedSino.Service.Validators.Dtos.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedSino.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly int maxPageSize = 30;


        public UserController(IUserService userService)
        {
            this._userService=userService;
    }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateAsync(long userId, [FromForm] UserUpdateDto dto)
        {
            var updateValidator = new UserUpdateValidator();
            var validationResult = updateValidator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _userService.UpdateAsync(userId, dto));
            else return BadRequest(validationResult.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _userService.GetAllAsync(new PaginationParams(page,maxPageSize)));

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdAsync(long userId)
            => Ok( await _userService.GetByIdAsync(userId));

    }
}
