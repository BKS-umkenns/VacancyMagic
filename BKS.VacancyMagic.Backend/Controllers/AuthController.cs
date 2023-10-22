using AutoMapper;
using BKS.VacancyMagic.Backend.DAL;
using BKS.VacancyMagic.Backend.DAL.Models;
using BKS.VacancyMagic.Backend.Models.Auth;
using BKS.VacancyMagic.Backend.Models.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BKS.VacancyMagic.Backend.Controllers;

[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    public AuthController(AppDbContext dbContext, IMapper mapper, IHttpContextAccessor contextAccessor)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDTO req, CancellationToken ct)
    {
        if (ModelState.IsValid)
        {
            if (await _dbContext.Users.AnyAsync(user => user.Name == req.Login, ct))
            {
                return BadRequest("User already exist");
            }

            try
            {
                var user = _mapper.Map<User>(req);
                await _dbContext.Users.AddAsync(user, ct);
                await _dbContext.SaveChangesAsync(ct);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginSuccessDTO?>> Login([FromBody] LoginDTO req, CancellationToken ct)
    {
        if (ModelState.IsValid)
        {
            if (await _dbContext.Users.AnyAsync(user => user.Name != req.Login, ct))
            {
                return NotFound("User is not found");
            }
            try
            {
                var user = await _dbContext.Users.SingleAsync(user => user.Name == req.Login, ct);
                if (user.PasswordHash != req.Password) return BadRequest("Login or password incorrect");
                await Authenticate(user.Name);

                return Ok(new LoginSuccessDTO { Token = user.Name, Success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        return BadRequest(ModelState);
    }

    private async Task Authenticate(string userName)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok();
    }
}
