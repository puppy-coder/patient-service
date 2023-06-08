using System;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    public async Task<ActionResult<List<Patients>>> getPatients([FromQuery] Application.List.Query query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Patients>> getPatientsById(Guid id)
    {

        return await Mediator.Send(new Application.ListById.Query { PatientId = id });
    }

}
