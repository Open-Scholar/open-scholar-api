using OpenScholarApp.Services.UserServices.Interfaces;
using System.Collections.Concurrent;

namespace OpenScholarApp.Services.UserServices.Implementations
{
    public class TokenProvider<T> : ITokenProvider<T>
    {
        private readonly ConcurrentDictionary<string, T?> Tokens = new();
        public Task<T?> GetTokenAsync(string key)
        {
            if (Tokens.TryGetValue(key, out var token))
                return Task.FromResult(token);
            return Task.FromResult(default(T));
        }

        public Task SetTokenAsync(string key, T value)
        {
            Tokens.TryAdd(key, value);
            return Task.CompletedTask;
        }
    }
}
