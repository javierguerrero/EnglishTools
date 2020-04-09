using System;
using System.Collections.Generic;

namespace Catalog.Domain
{
    public class Level
    {
        public int LevelId { get; set; }
        public string Name { get; set; }
        public List<Lesson> Lessons  { get; set; }
    }
}