using FinalExercise.Common;
using FinalExercise.Dal.Contracts.Repositories;

namespace FinalExercise.Api.Implementations;

public class DbWriterContext(IWriter writer, IDateTimeProvider dateTimeProvider, IIdentityProvider identityProvider) : IDbWriterContext
{
    public IWriter Writer => writer;

    public IDateTimeProvider DateTimeProvider => dateTimeProvider;

    public IIdentityProvider IdentityProvider => identityProvider;
}
