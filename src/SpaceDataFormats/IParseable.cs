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
        T? Parse(string text) => default;
        T? Parse(Stream stream) => default;
    }
}
