using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuarioAPI.Data.Dtos;
using UsuarioAPI.Models;

namespace UsuarioAPI.Services;

public class UsuarioService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;
    private SignInManager<Usuario> _signInManager;
    private TokenService _tokenService;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task Cadastro(CreateUsuarioDto dtoUser)
    {
        Usuario usuario = _mapper.Map<Usuario>(dtoUser);

        IdentityResult resultado = await _userManager.CreateAsync(usuario, dtoUser.Password);

        if (!resultado.Succeeded)
        {
             throw new ApplicationException("Falha ao cadastra Usuário!");
        }
    }

    public async Task<string> Login(LoginUsuarioDto dtoLogin)
    {
        var resultado = await  _signInManager.PasswordSignInAsync
            (dtoLogin.UserName, dtoLogin.password, false, false);
        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Usuário não autenticado!");
        }

        var usuario = _signInManager.UserManager.Users.FirstOrDefault
            (user => user.NormalizedUserName == dtoLogin.UserName.ToUpper());

        var token = _tokenService.GenerateToken(usuario);

        return token;

    }
}
