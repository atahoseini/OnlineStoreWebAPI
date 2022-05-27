namespace OnlineStoreWebAPI.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public string? ProvinceName { get; set; }
        public string Address  { get; set; }

    }
}
