using NickSpace.SpaceDataFormats.Ussf;
using System.Reflection.Metadata.Ecma335;
using UnitsNet;

namespace NickSpace.SpaceDataFormats
{
    public interface ILoadable<T>
    {
        bool TryLoad(string filePath, out T? twolineElement)
        {
            twolineElement = default;
            return false;
        }
        Task<(bool Result, T? Data)> TryLoadAsync(string filePath) => Task.FromResult((Result: false, Data: default(T)));
        T? Load(string filePath) => default;
        Task<T?> LoadAsync(string filePath) => Task.FromResult(default(T));
    }
}