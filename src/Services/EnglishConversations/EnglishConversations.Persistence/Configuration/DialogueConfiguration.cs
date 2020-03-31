using EnglishConversations.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishConversations.Persistence.Configuration
{
    public class DialogueConfiguration
    {
        public DialogueConfiguration(EntityTypeBuilder<Dialogue> entityBuilder)
        {
            entityBuilder.HasKey(x => x.DialogueId);
            entityBuilder.Property(x => x.Text).IsRequired().HasMaxLength(1000);
            entityBuilder.Property(x => x.Order).IsRequired();
        }
    }
}
