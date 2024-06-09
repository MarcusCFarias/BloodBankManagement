using BloodBankManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Infrastructure.Persistence.Extensions
{
    public static class MediaRExtension
    {
        public static void DispatchDomainEvents(this IMediator mediator, ApplicationDbContext context)
        {
            var entities = context
                .ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents.Any())
                .ToList();

            var domainEvents = entities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEvents.ForEach(async domainEvent =>
            {
                await mediator.Publish(domainEvent);
            });
        }
    }
}
