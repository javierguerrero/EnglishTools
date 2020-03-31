using System;
using System.Collections.Generic;

namespace EffortlessEnglish.Domain
{
    public class Level
    {
        public int LevelId { get; set; }
        public string Name { get; set; }
        public List<Class> Classes  { get; set; }
    }
}