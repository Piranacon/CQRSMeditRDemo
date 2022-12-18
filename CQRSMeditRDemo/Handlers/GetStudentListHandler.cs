using CSharpFunctionalExtensions;
using CQRSMeditRDemo.Models;
using CQRSMeditRDemo.Queries;
using CQRSMeditRDemo.Repositories;
using CQRSMeditRDemo.Repositories.Interfaces;

using MediatR;

namespace CQRSMeditRDemo.Handlers;

	public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, Result<List<StudentDetails>>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentListHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Result<List<StudentDetails>>> Handle(GetStudentListQuery query, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetStudentListAsync();
    }
}