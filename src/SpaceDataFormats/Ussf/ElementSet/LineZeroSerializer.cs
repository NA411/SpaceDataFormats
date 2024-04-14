namespace NickSpace.SpaceDataFormats.Ussf.TwoLineElement
{
    internal class LineZeroSerializer
    {
        internal TwoLineElementSetLine LineNumber = TwoLineElementSetLine.LineZero;
        internal char LineIdentifier;
        public string SatelliteName { get; set; } = string.Empty;
    }
}
