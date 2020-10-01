using ApiPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPractice.Data
{
    public class ApiPracticeContext : DbContext
    {
        public ApiPracticeContext(DbContextOptions<ApiPracticeContext> opt) : base(opt)
        {

        }

        public DbSet<Command> Commands { get; set; }
    }
}