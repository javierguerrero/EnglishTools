using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain
{
    public class Dialogue
    {
        public int DialogueId { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
