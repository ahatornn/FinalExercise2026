using FinalExercise.Common;
using FinalExercise.Dal.Contracts.Repositories;

namespace FinalExercise.Api.Implementations;

public class DbWriterContext(IWriter writer) : IDbWriterContext
{
    public IWriter Writer => writer;
    public IDateTimeProvider DateTimeProvider { get; }
    public IIdentityProvider IdentityProvider { get; }
}
