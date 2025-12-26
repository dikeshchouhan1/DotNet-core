namespace ecommerce.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }=string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string Password { get; set; }=string.Empty;

        public ICollection<UserRole>? UserRoles { get; set; }
    }
}
