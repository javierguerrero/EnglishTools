using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Configuration
{
    public class LessonConfiguration
    {
        public LessonConfiguration(EntityTypeBuilder<Lesson> entityBuilder)
        {
            entityBuilder.HasKey(x => x.LessonId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(255);


            entityBuilder.HasData(
                new Lesson
                {
                    LessonId = 1,
                    Name = "Kramer's take about life",
                    Description = "This card has supporting text below as a natural lead-in to additional content."
                }
            );


        }
    }
}