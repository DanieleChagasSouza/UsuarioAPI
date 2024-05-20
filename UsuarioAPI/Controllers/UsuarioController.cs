using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Data.Dtos;
using UsuarioAPI.Models;
using UsuarioAPI.Services;

namespace UsuarioAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastroDeUsuario(CreateUsuarioDto dtoUser)
    {
        await _usuarioService.Cadastro(dtoUser);

        return Ok("Usuário Cadastrado!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginUsuarioDto dtoLogin)
    {
        var token = await _usuarioService.Login(dtoLogin);

        return Ok(token);
    }
}
