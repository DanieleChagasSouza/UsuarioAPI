using System.ComponentModel.DataAnnotations;

namespace UsuarioAPI.Data.Dtos;

public class LoginUsuarioDto
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string password { get; set; }
}
