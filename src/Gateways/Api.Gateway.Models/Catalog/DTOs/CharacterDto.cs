using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Gateway.Models.Catalog.DTOs
{
    public class CharacterDto
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
