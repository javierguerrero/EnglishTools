using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain
{
    public class Conversation
    {
        public int ConversationId { get; set; }
        public Lesson Lesson { get; set; }
        public string VideoUrl { get; set; }
        public ICollection<Dialogue> Dialogues { get; set; }
    }
}
