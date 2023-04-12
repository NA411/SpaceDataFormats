namespace NickSpace.SpaceDataFormats.Ussf
{
    public class TwoLineElementCatalog : IParseable<TwoLineElementCatalog>
    {
        public IEnumerable<TwoLineElementCatalog> Catalog { get; set; } = Enumerable.Empty<TwoLineElementCatalog>();
    }
}
