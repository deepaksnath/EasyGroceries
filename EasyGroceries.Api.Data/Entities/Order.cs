using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGroceries.Api.Data.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        [NotMapped]
        public bool IsLoyaltyMembershipAdded { get; set; }
    }
}
