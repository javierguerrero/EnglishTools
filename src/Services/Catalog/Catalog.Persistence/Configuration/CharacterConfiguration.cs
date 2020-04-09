using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Configuration
{
    public class CharacterConfiguration
    {
        public CharacterConfiguration(EntityTypeBuilder<Character> entityBuilder)
        {
            entityBuilder.HasKey(x => x.CharacterId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).HasMaxLength(255);
        }
    }
}