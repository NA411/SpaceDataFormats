using NickSpace.SpaceDataFormats.Ussf;
using System.Reflection.Metadata.Ecma335;
using UnitsNet;

namespace NickSpace.SpaceDataFormats
{
    internal interface ILoadable<T>
    {
        public bool TryLoad(string filePath, out T? value)
        {
            value = default;
            return false;
        }
        public Task<bool> TryLoadAsync(string filePath, out T? value)
        {
            value = default;
            return (Task<bool>)Task.CompletedTask;
        }
        public T? Load(string filePath) => default;
        public Task<T> LoadAsync(string filePath) => (Task<T>)Task.CompletedTask;
    }
}