using System;
using System.Collections.Generic;
using System.Text;
using static Catalog.Common.Enums;

namespace EffortlessEnglish.Domain
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public LessonType Type { get; set; }
    }
}


