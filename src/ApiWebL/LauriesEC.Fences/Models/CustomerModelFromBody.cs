using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Models
{
    public class CustomerModelFromBody
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int ZipCode { get; set; }


        public CustomerModelFromBody(int id,
                             string name,
                             string lastName,
                             string email,
                             string phoneNumber,
                             string address,
                             string city,
                             string state,
                             int zipCode)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;

        }
        public CustomerModelFromBody()
        {
            
        }
    }
}
