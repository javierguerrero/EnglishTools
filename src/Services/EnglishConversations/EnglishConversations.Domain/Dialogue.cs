using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishConversations.Domain
{
    public class Dialogue
    {
        public int DialogueId { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
