using System;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application;

[ApiController]
[Route("[controller]")]

public class PatientController : Controller
{
    public IMediator Mediator { get; set; }

    public PatientController(IMediator mediator)
    {
        this.Mediator = mediator;
    }

    [HttpGet]
    [Authorize]

    public async Task<ActionResult<List<PatientsDTO>>> getPatients([FromQuery] Application.List.Query query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<PatientsDTO>> getPatientsById(string id)
    {

        return await Mediator.Send(new Application.ListById.Query { PatientId = id });
    }

}
