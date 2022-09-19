using Microsoft.EntityFrameworkCore;

namespace GotwAPI.Context
{
    public class CommanderContext: DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options)
        { 
        }

        public DbSet<CommanderSkill> CommanderSkill { get; set; }
    }
}
