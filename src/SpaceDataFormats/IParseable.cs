namespace NickSpace.SpaceDataFormats
{
    internal interface IParseable<T>
    {
        bool TryParse(string text, out T? value)
        {
            value = default;
            return false;
        }
        bool TryParse(Stream stream, out T? value)
        {
            value = default;
            return false;
        }
        Task<(bool Result, T? Data)> TryParseAsync(string text) => Task.FromResult((Result: false, Data: default(T)));
        Task<(bool Result, T? Data)> TryParseAsync(Stream stream) => Task.FromResult((Result: false, Data: default(T)));
        T? Parse(string text) => default;
        T? Parse(Stream stream) => default;
        Task<T?> ParseAsync(string text) => Task.FromResult(default(T));
        Task<T?> ParseAsync(Stream stream) => Task.FromResult(default(T));
    }
}
