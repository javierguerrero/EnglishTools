using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.EventHandlers.Commands
{
    public class LessonCreateCommand : INotification
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public IEnumerable<DialogueCreate> Dialogues { get; set; } = new List<DialogueCreate>();
    }

    public class DialogueCreate
    {
        public int CharacterId { get; set; }
        public string Text { get; set; }
    }
}
