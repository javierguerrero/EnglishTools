using EnglishConversations.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishConversations.Persistence.Configuration
{
    public class CharacterConfiguration
    {
        public CharacterConfiguration(EntityTypeBuilder<Character> entityBuilder)
        {
            entityBuilder.HasKey(x => x.CharacterId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}