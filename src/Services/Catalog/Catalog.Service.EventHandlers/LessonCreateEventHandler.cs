using Catalog.Domain;
using Catalog.Persistence;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
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
                var entry = new Lesson();
                entry.Name = notification.Name;
                entry.Description = notification.Description;

                await _context.Lessons.AddAsync(entry);
                await _context.SaveChangesAsync();

                await trx.CommitAsync();
            }
        }
    }
}
