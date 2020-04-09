using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Configuration
{
    public class DialogueConfiguration
    {
        public DialogueConfiguration(EntityTypeBuilder<Dialogue> entityBuilder)
        {
            entityBuilder.HasKey(x => x.DialogueId);
            entityBuilder.Property(x => x.Text).IsRequired().HasMaxLength(1000);
        }
    }
}