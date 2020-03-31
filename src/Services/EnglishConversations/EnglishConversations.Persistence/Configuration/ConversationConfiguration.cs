using EnglishConversations.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishConversations.Persistence.Configuration
{
    public class ConversationConfiguration
    {
        public ConversationConfiguration(EntityTypeBuilder<Conversation> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ConversationId);
            entityBuilder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.VideoUrl).IsRequired().HasMaxLength(255);
        }
    }
}
