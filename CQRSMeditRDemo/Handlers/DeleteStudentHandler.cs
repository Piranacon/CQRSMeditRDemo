using CSharpFunctionalExtensions;
using CQRSMeditRDemo.Commands;
using CQRSMeditRDemo.Repositories;
using CQRSMeditRDemo.Repositories.Interfaces;
using MediatR;

namespace CQRSMeditRDemo.Handlers;

public class DeleteStudentHandler: IRequestHandler<DeleteStudentCommand, Result<int>>
{
	private readonly IStudentRepository _studentRepository;

	public DeleteStudentHandler(IStudentRepository repository)
	{
		_studentRepository = repository;
	}

	public async Task<Result<int>> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
	{
		return await _studentRepository.DeleteStudentAsync(command.Id);
	}
}

