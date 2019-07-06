using Keepa.NET_Core.Enums;

namespace Keepa.NET_Core.Entities
{
    public class Promotion
    {
        public PromotionType Type { get; set; }
        public string EligibilityRequirementDescription { get; set; }
        public string BenefitDescription { get; set; }
        public string PromotionId { get; set; }
    }
}