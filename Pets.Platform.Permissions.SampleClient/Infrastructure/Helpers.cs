namespace Pets.Platform.Permissions.SampleClient.Infrastructure;

public static class Helpers
{
    public static string ExecutionEnvironment =>
        Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

    public static IConfiguration GetConfiguration() => 
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile("appsettings." + Helpers.ExecutionEnvironment + ".json", true)
            .AddEnvironmentVariables()
            .Build();
}

public static partial class AsyncEnumerable
{
    /// <summary>
    /// Returns an empty async-enumerable sequence.
    /// </summary>
    /// <typeparam name="TValue">The type used for the <see cref="IAsyncEnumerable{T}"/> type parameter of the resulting sequence.</typeparam>
    /// <returns>An async-enumerable sequence with no elements.</returns>
    public static IAsyncEnumerable<TValue> Empty<TValue>() => EmptyAsyncEnumerator<TValue>.Instance;
    
    private class EmptyAsyncEnumerator<T> : IAsyncEnumerator<T>, IAsyncEnumerable<T>
    {
        public static readonly EmptyAsyncEnumerator<T> Instance = new EmptyAsyncEnumerator<T>();
        public T Current => default;
        public ValueTask DisposeAsync() => default;
        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return this;
        }
        public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(false);
    }
}