using FinalExercise.Common;
using FinalExercise.Dal.Contracts.Repositories;
using Moq;

namespace FinalExercise.Context.Tests;

/// <inheritdoc />
public class TestWriterContext : IDbWriterContext
{
    private readonly Mock<IDateTimeProvider> dateTimeProviderMock;
    private readonly Mock<IIdentityProvider> identityProviderMock;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="TestWriterContext"/>
    /// </summary>
    public TestWriterContext(IWriter writer)
    {
        Writer = writer;
        dateTimeProviderMock = new Mock<IDateTimeProvider>();
        dateTimeProviderMock.Setup(x => x.UtcNow).Returns(DateTimeOffset.UtcNow);

        identityProviderMock = new Mock<IIdentityProvider>();
        identityProviderMock.Setup(x => x.Name).Returns("test@test-identity");
    }

    public IWriter Writer { get; }
    public IDateTimeProvider DateTimeProvider => dateTimeProviderMock.Object;
    public IIdentityProvider IdentityProvider => identityProviderMock.Object;
}
