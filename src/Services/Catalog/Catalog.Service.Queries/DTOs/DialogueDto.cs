using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Queries.DTOs
{
    public class DialogueDto
    {
        public int DialogueId { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public CharacterDto Character { get; set; }
    }
}
