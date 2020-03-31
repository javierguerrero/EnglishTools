using EnglishConversations.Domain;
using EnglishConversations.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EnglishConversations.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Dialogue> Dialogues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ConversationConfiguration(modelBuilder.Entity<Conversation>());
        }
    }
}