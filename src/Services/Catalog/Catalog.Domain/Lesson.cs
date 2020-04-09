using System;
using System.Collections.Generic;
using System.Text;
using static Catalog.Common.Enums;

namespace Catalog.Domain
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Level Level { get; set; }
    }
}


