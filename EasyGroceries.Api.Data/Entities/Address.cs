namespace EasyGroceries.Api.Data.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = "Shipping";
        public string? DoorNumber { get; set; }
        public string? BuildingNumer { get; set; }
        public string? StreetName { get; set; }
        public string? LocalityName { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        public string? PIN { get; set; }
    }
}
