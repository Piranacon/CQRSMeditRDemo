using CSharpFunctionalExtensions;
using MediatR;
namespace CQRSMeditRDemo.Commands;

public class DeleteStudentCommand : IRequest<Result<int>>
{
    public int Id { get; set; }
}