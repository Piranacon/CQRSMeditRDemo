using CSharpFunctionalExtensions;
using CQRSMeditRDemo.Commands;
using CQRSMeditRDemo.Models;
using CQRSMeditRDemo.Repositories.Interfaces;
using MediatR;

namespace CQRSMeditRDemo.Handlers;

public class CreateStudentHandler: IRequestHandler<CreateStudentCommand, Result<StudentDetails>>
{
	private readonly IStudentRepository _studentRepository;

	public CreateStudentHandler(IStudentRepository repo)
	{
		_studentRepository = repo;
	}

    public async Task<Result<StudentDetails>> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        var studentDetails = new StudentDetails()
        {
            StudentName = command.StudentName,
            StudentEmail = command.StudentEmail,
            StudentAddress = command.StudentAddress,
            StudentAge = command.StudentAge
        };

        return await _studentRepository.AddStudentAsync(studentDetails);
    }
}

