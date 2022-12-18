using CSharpFunctionalExtensions;
using CQRSMeditRDemo.Models;
using MediatR;

namespace CQRSMeditRDemo.Queries;

public class GetStudentListQuery : IRequest<Result<List<StudentDetails>>> { }

