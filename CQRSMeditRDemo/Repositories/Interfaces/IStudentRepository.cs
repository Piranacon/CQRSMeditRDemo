using CSharpFunctionalExtensions;
using CQRSMeditRDemo.Models;

namespace CQRSMeditRDemo.Repositories.Interfaces;

public interface IStudentRepository
{
    /// <summary>
    /// Gets a list of all students
    /// </summary>
    /// <returns>A List of all the students</returns>
    Task<Result<List<StudentDetails>>> GetStudentListAsync();

    Task<Result<Maybe<StudentDetails>>> GetStudentByIdAsync(int id);

    Task<Result<StudentDetails>> AddStudentAsync(StudentDetails details);

    Task<Result<int>> DeleteStudentAsync(int id);

    Task<Result<int>> UpdateStudentAsync(StudentDetails studentDetails);
}

