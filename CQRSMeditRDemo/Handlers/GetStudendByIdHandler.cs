using CSharpFunctionalExtensions;
using CQRSMeditRDemo.Models;
using CQRSMeditRDemo.Queries;
using CQRSMeditRDemo.Repositories.Interfaces;
using MediatR;

namespace CQRSMeditRDemo.Handlers;

public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Result<Maybe<StudentDetails>>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Result<Maybe<StudentDetails>>> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetStudentByIdAsync(query.Id);
    }
}