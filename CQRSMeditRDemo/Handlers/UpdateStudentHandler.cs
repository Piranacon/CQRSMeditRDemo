using CSharpFunctionalExtensions;
using CQRSMeditRDemo.Commands;
using CQRSMeditRDemo.Repositories.Interfaces;
using MediatR;

namespace CQRSMeditRDemo.Handlers;

public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Result<int>>
{
    private readonly IStudentRepository _studentRepository;

    public UpdateStudentHandler(IStudentRepository repo)
    {
        _studentRepository = repo;
    }

    public async Task<Result<int>> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
    {
        var studentDetails = await _studentRepository.GetStudentByIdAsync(command.Id);
        if (studentDetails.IsFailure || studentDetails.Value.HasNoValue)
            return default;
        var student = studentDetails.Value.Value;

        student.StudentName = command.StudentName;
        student.StudentEmail = command.StudentEmail;
        student.StudentAddress = command.StudentAddress;
        student.StudentAge = command.StudentAge;

        return await _studentRepository.UpdateStudentAsync(student);
    }
}

