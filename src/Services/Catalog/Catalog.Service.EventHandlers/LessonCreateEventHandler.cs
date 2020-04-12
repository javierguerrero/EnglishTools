using Catalog.Domain;
using Catalog.Persistence;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Service.EventHandlers
{
    public class LessonCreateEventHandler : INotificationHandler<LessonCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LessonCreateEventHandler> _logger;

        public LessonCreateEventHandler(
            ApplicationDbContext context,
            ILogger<LessonCreateEventHandler> logger)
        {
            _context = context;
        }

        public async Task Handle(LessonCreateCommand notification, CancellationToken cancellationToken)
        {
            using (var trx = await _context.Database.BeginTransactionAsync())
            {
                var lesson = new Lesson();
                lesson.Name = notification.Name;
                lesson.Description = notification.Description;

                // save lesson
                await _context.Lessons.AddAsync(lesson);
                await _context.SaveChangesAsync();

                // save dialogues
                List<Dialogue> dialogues = new List<Dialogue>();
                foreach (var item in notification.Dialogues)
                {
                    var dialog = new Dialogue();
                    dialog.LessonId = lesson.LessonId;
                    dialog.CharacterId = item.CharacterId;
                    dialog.Text = item.Text;
                    dialog.Order = 1;

                    dialogues.Add(dialog);
                }
                await _context.Dialogues.AddRangeAsync(dialogues);
                await _context.SaveChangesAsync();

                //
                await trx.CommitAsync();
            }
        }
    }
}