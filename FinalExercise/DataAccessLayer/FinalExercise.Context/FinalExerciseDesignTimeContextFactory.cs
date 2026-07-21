using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinalExercise.Context;

/// <summary>
/// Фабрика для создания контекста в DesignTime
/// </summary>
public class FinalExerciseDesignTimeContextFactory : IDesignTimeDbContextFactory<FinalExerciseContext>
{
    /// <summary>
    /// Creates a new instance of a derived context
    /// </summary>
    /// <remarks>
    /// 1) dotnet tool install --global dotnet-ef
    /// 2) dotnet tool update --global dotnet-ef
    /// 3) dotnet ef migrations add [name] --project DataAccessLayer/FinalExercise.Context/FinalExercise.Context.csproj
    /// 4) dotnet ef database update --project DataAccessLayer/FinalExercise.Context/FinalExercise.Context.csproj
    /// 5) dotnet ef database update [targetMigrationName] --project DataAccessLayer/FinalExercise.Context/FinalExercise.Context.csproj
    /// </remarks>
    public FinalExerciseContext CreateDbContext(string[] args)
    {
        var connectionString = "Host=localhost;Port=5432;Database=FinalExercise;Username=postgres;Password=Qwerty123456!";
        var options = new DbContextOptionsBuilder<FinalExerciseContext>()
            .UseNpgsql(connectionString)
            .LogTo(Console.WriteLine)
            .Options;

        return new FinalExerciseContext(options);
    }
}
