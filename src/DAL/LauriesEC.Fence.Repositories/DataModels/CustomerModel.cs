namespace Security.Models
{
    public class CustomerModel
    { 
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State {  get; set; }
        public int ZipCode{ get; set; }
        public string? ResultDescription { get; set; }

        public CustomerModel(int id,
                             string name, 
                             string companyName, 
                             string email, 
                             string phoneNumber,
                             string address, 
                             string city,
                             string state,
                             int zipCode)
        {
            Id = id;
            Name = name;
            CompanyName = companyName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            
        }
        public CustomerModel()
        {
            
        }
    }
}
