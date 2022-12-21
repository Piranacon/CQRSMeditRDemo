using CQRSMeditRDemo.Commands;
using CQRSMeditRDemo.Models;
using CQRSMeditRDemo.Queries;
using CQRSMeditRDemo.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CQRSMeditRDemo.Controllers;

[ApiController, Route("Api/[Controller]")]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<StudentDetails>>> GetDetailsListAsync()
    {
        var studentDetailsResult = await _mediator.Send(new GetStudentListQuery());
        if (studentDetailsResult.IsFailure)
        {
            return Problem(studentDetailsResult.Error);
        }
        return studentDetailsResult.Value;
    }

    [HttpGet("studentId")]
    public async Task<ActionResult<StudentDetails>> GetStudentByIdAsync(int studentId)
    {
        var studentDetailsResult = await _mediator.Send(new GetStudentByIdQuery { Id = studentId });
        if (studentDetailsResult.IsFailure)
        {
            return Problem(studentDetailsResult.Error);
        }
        return studentDetailsResult.Value.Value; 
    }

    [HttpPost]
    public async Task<ActionResult<StudentDetails>> AddStudentAsync(StudentDetails details)
    {
        var studentDetailsResult = await _mediator.Send(new CreateStudentCommand(details.StudentName, details.StudentEmail, details.StudentAddress, details.StudentAge));

        if (studentDetailsResult.IsFailure)
        {
            return Problem(studentDetailsResult.Error);
        }

        return studentDetailsResult.Value;
    }

    [HttpPut]
    public async Task<ActionResult<int>> UpdateStudentAsync(StudentDetails studentDetails)
    {
        var isStudentDetailUpdated = await _mediator.Send(new UpdateStudentCommand(
           studentDetails.Id,
           studentDetails.StudentName,
           studentDetails.StudentEmail,
           studentDetails.StudentAddress,
           studentDetails.StudentAge));
        if (isStudentDetailUpdated.IsFailure)
        {
            return Problem(isStudentDetailUpdated.Error);
        }
        return isStudentDetailUpdated.Value;
    }

    [HttpDelete]
    public async Task<ActionResult<int>> DeleteStudentAsync(int Id)
    {
        var result = await _mediator.Send(new DeleteStudentCommand() { Id = Id });
        if (result.IsFailure)
        {
            return Problem(result.Error);
        }
        return result.Value;
    }

}

