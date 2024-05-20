using Microsoft.AspNetCore.Authorization;

namespace UsuarioAPI.Authorization;

public class IdadeMinima : IAuthorizationRequirement
{
    public IdadeMinima(int idade)
    {
        Idade = Idade;
    }
    public int Idade { get; set; }
}
