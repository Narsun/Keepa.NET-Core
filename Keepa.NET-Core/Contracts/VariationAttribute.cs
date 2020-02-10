namespace Keepa.NET_Core.Contracts
{
    public class VariationAttribute
    {
        /** dimension type, e.g. Color **/
        public string Dimension { get; set; }
        /** dimension value, e.g. Red **/
        public string Value { get; set; }
    }
}