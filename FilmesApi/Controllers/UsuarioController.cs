using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesApi.Business.Services.Interfaces;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly ILoginService _loginService;

    public UsuarioController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    // POST: auth/login
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (String.IsNullOrEmpty(loginDto.Email))
        {
            return BadRequest(new { message = "Email address needs to entered" });
        }
        else if (String.IsNullOrEmpty(loginDto.Senha))
        {
            return BadRequest(new { message = "Password needs to entered" });
        }

        ReadUsuarioDto usuario = await _loginService.Login(loginDto);

        if (usuario != null)
        {
            return Ok(usuario);
        }

        return BadRequest(new { message = "User login unsuccessful" });
    }

    // POST: auth/register
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] CreateUsuarioDto createUsuarioDto)
    {
        if (String.IsNullOrEmpty(createUsuarioDto.Email))
        {
            return BadRequest(new { message = "Email address is required" });
        }
        else if (String.IsNullOrEmpty(createUsuarioDto.Senha))
        {
            return BadRequest(new { message = "Password is required" });
        }
        else if (String.IsNullOrEmpty(createUsuarioDto.Nome))
        {
            return BadRequest(new { message = "Name is required" });
        }
        else if (String.IsNullOrEmpty(createUsuarioDto.Cpf))
        {
            return BadRequest(new { message = "CPF is required" });
        }

        await _loginService.Register(createUsuarioDto);

        return Ok(new { message = "User registered successfully" });
    }

    // GET: auth/test
    [Authorize(Roles = "Everyone")]
    [HttpGet]
    public IActionResult Test()
    {
        string token = Request.Headers["Authorization"];

        if (token.StartsWith("Bearer"))
        {
            token = token.Substring("Bearer ".Length).Trim();
        }
        var handler = new JwtSecurityTokenHandler();

        JwtSecurityToken jwt = handler.ReadJwtToken(token);

        var claims = new Dictionary<string, string>();

        foreach (var claim in jwt.Claims)
        {
            claims.Add(claim.Type, claim.Value);
        }

        return Ok(claims);
    }
}