using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymFlex.Presentation.Controllers
{
    [ApiController]
    [Route("api")] // Prefixo base para todas as rotas
    [Authorize] // Exige autenticação
    public class UserController(UserManager<IdentityUser> userManager) : ControllerBase
    {
        // GET: api/me
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            // Obtém o ID do usuário a partir do token JWT
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Usuário não autenticado.");

            // Busca o usuário no banco de dados
            var user = await userManager.FindByIdAsync(userId);
        
            if (user == null)
                return NotFound("Usuário não encontrado.");

            // Retorna apenas dados seguros (nunca senha/tokens)
            return Ok(new
            {
                user.Id,
                user.Email,
                user.UserName,
                Claims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }
    }
}