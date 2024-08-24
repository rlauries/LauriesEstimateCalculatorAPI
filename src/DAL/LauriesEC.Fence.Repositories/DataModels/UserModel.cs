using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Security.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string HashPassword { get; set; }
        public byte[] Salty { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set;}
        public DateTime? LastLoginDate {  get; set; }
        public int CustomerId { get; set; }
        public int RoleId { get; set; } = 1;
        public string? ResultDescription { get; set; }

        public UserModel(int id, 
                         string user, 
                         string password,
                         byte[] salty,
                         DateTime created, 
                         DateTime lastUpdated, 
                         DateTime lastLogin, 
                         int customerId)
        {
            Id = id;
            UserName = user;
            HashPassword = password;
            Salty = salty;
            CreatedDate = created;
            LastUpdatedDate = lastUpdated;
            LastLoginDate = lastLogin;
            CustomerId = customerId;
            RoleId = 1;
        }
        public UserModel()
        {
           
        }
    }
}
