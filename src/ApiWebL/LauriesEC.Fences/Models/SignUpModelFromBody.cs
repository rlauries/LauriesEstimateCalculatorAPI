namespace LauriesEC.Fence.Models
{
    public class SignUpModelFromBody
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CustomerId { get; set; }
        public const int RoleId = 1;
    }
}
