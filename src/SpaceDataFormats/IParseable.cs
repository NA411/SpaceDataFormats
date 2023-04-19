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
        Task<(bool Result, T? Data)> TryParseAsync(string text) => (Task<(bool Result, T? Data)>)Task.CompletedTask;
        Task<(bool Result, T? Data)> TryParseAsync(Stream stream) => (Task<(bool Result, T? Data)>)Task.CompletedTask;
        T? Parse(string text) => default;
        T? Parse(Stream stream) => default;
        Task<T?> ParseAsync(string text) => (Task<T?>)Task.CompletedTask;
        Task<T?> ParseAsync(Stream stream) => (Task<T?>)Task.CompletedTask;
    }
}
