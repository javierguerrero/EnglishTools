using Catalog.Domain;
using Catalog.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;


// https://code-maze.com/migrations-and-seed-data-efcore/

namespace Catalog.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Level> Levels { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Dialogue> Dialogues { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Model Contraints
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new LevelConfiguration(modelBuilder.Entity<Level>());
            new LessonConfiguration(modelBuilder.Entity<Lesson>());
            new DialogueConfiguration(modelBuilder.Entity<Dialogue>());
            new CharacterConfiguration(modelBuilder.Entity<Character>());
        }
    }
}