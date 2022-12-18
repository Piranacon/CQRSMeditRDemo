using CSharpFunctionalExtensions;
using CQRSMeditRDemo.Data;
using CQRSMeditRDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMeditRDemo.Repositories;

public class StudentRepository: Interfaces.IStudentRepository
{
    private readonly DbContextClass _dbContext;

	public StudentRepository(DbContextClass context)
	{
        _dbContext = context;
	}

    public async Task<Result<StudentDetails>> AddStudentAsync(StudentDetails details)
    {
        var result = _dbContext.Add(details);
        await _dbContext.SaveChangesAsync();
        return Result.Success(result.Entity);
    }

    public async Task<Result<int>> DeleteStudentAsync(int id)
    {
        var filteredData = _dbContext.Students.Where(x => x.Id == id).FirstOrDefault();
        if(filteredData == null)
        {
            return Result.Failure<int>("Student Not found");
        }
        _dbContext.Students.Remove(filteredData);
        return Result.Success(await _dbContext.SaveChangesAsync());
    }

    public async Task<Result<Maybe<StudentDetails>>> GetStudentByIdAsync(int id)
    {
        var result = await _dbContext.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
        if(result == null)
        {
            return Result.Success(Maybe<StudentDetails>.None);
        }
        return Result.Success(Maybe.From(result));
    }

    public async Task<Result<List<StudentDetails>>> GetStudentListAsync()
    {
        return Result.Success(await _dbContext.Students.ToListAsync());
    }

    public async Task<Result<int>> UpdateStudentAsync(StudentDetails studentDetails)
    {
        _dbContext.Students.Update(studentDetails);
        return await _dbContext.SaveChangesAsync();
    }
}

