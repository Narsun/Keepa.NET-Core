namespace Keepa.NET_Core.Entities
{
    public class Variation
    {
        /** Variation ASIN **/
        public string Asin { get; set; }
        /** This variation ASIN's dimension attributes **/
        public VariationAttribute[] Attributes { get; set; }
    }
}