namespace NickSpace.SpaceDataFormats.Ussf
{
    public class ElementSetCatalog : IParseable<ElementSetCatalog>
    {
        public IEnumerable<ElementSetCatalog> Catalog { get; set; } = Enumerable.Empty<ElementSetCatalog>();
    }
}
