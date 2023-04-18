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
        Task<bool> TryParseAsync(string text, out T? value)
        {
            value = default;
            return (Task<bool>)Task.CompletedTask;
        }
        Task<bool> TryParseAsync(Stream stream, out T? value)
        {
            value = default;
            return (Task<bool>)Task.CompletedTask;
        }
        T? Parse(string text) => default;
        T? Parse(Stream stream) => default;
        Task<T?> ParseAsync(string text) => (Task<T?>)Task.CompletedTask;
        Task<T?> ParseAsync(Stream stream) => (Task<T?>)Task.CompletedTask;
    }
}
