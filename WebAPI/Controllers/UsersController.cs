﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult GetAll()
        {
            //Dependency chain-- bağımlılık zinciri

            var result = _userService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _userService.GetByUserId(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}