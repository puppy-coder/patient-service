using System;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security;

[ApiController]
[Route("[controller]")]

public class AuthController : Controller
{
    public IMediator Mediator { get; set; }
    public ITokenHandler tokenHandler { get; set; }

    public AuthController(IMediator mediator, ITokenHandler tokenHandler)
    {
        this.Mediator = mediator;
        this.tokenHandler = tokenHandler;
    }

    [HttpPost]
    public async Task<ActionResult> login([FromBody] Application.Login.Command command)
    {
        var user = await Mediator.Send(command);

        if (user != null)
        {
            var token = tokenHandler.CreateTokenAsync(user);
            return Ok(token);
        }

        return Unauthorized("Username or password is incorrect");
    }

}
