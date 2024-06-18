using Microsoft.EntityFrameworkCore;
using UserRegistrationAPI.Models;

namespace UserRegistrationAPI.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
