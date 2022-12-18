using CSharpFunctionalExtensions;
using CQRSMeditRDemo.Models;
using MediatR;

namespace CQRSMeditRDemo.Queries;

public class GetStudentByIdQuery : IRequest<Result<Maybe<StudentDetails>>>
{
    public int Id { get; set; }
}

