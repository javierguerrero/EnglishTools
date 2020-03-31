using EffortlessEnglish.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EffortlessEnglish.Persistence.Configuration
{
    public class LevelConfiguration
    {
        public LevelConfiguration(EntityTypeBuilder<Level> entityBuilder)
        {
            entityBuilder.HasKey(x => x.LevelId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            entityBuilder.HasData(
                new Level
                {
                    LevelId = 1,
                    Name = "Level 1"
                },
                new Level
                {
                    LevelId = 2,
                    Name = "Level 2"
                },
                new Level
                {
                    LevelId = 3,
                    Name = "Level 3"
                },
                new Level
                {
                    LevelId = 4,
                    Name = "Level 4"
                }
            );
        }
    }
}