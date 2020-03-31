using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishConversations.Domain
{
    public class Conversation
    {
        public int ConversationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public DateTime Created { get; set; }
        public ICollection<Dialogue> Dialogues { get; set; }
    }
}
